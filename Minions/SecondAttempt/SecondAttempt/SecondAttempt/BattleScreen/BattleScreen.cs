
namespace SecondAttempt
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Media;
    using Microsoft.Xna.Framework.Input;
    
    public class BattleScreen : GameplayScreen
    {
        //Sprites
        private List<Enemy> enemies;        
        private Image background;
        private Song backgroundMusic;
        private Vector2 startingPosition;
        private MinionCommandBox commandBox;

        private int currentSelection;
        private int currentSelectionMin;
        private int currentSelectionMax;
        private int delayCount;
        private bool delay;
        private bool playerIsTarget;            
        
        public bool SelectTarget;        
        public bool SelectSkill;

        public string[] CommandSequence;
        public ListBox ItemSelectionBox;


        public BattleScreen(List<Enemy> enemies)
        {
            this.enemies = enemies;            
            
            playerIsTarget = false;
            delay = false;
            delayCount = 0;
            SelectTarget = false;
            //SelectItem = false;
            SelectSkill = false;

            currentSelection = 0;
            currentSelectionMin = 0;
            currentSelectionMax = enemies.Count() - 1;          
            
            CommandSequence = new string[2];
            this.commandBox = new MinionCommandBox(this, Player);
            this.ItemSelectionBox = new ListBox(Player.Inventory.Consumables);
        }

        /// <summary>
        /// Highlights current target (blinking sprite) and returns it when prompted.
        /// </summary>
        /// <returns></returns>
        public Character SelectTargetLogic()
        {
            if (!enemies[currentSelection].IsAlive) currentSelection = currentSelectionMin;
            if (InputManager.Instance.KeyPressed(Keys.Down) && !playerIsTarget)
            {
                enemies[currentSelection].SpriteImage.IsActive = false;
                currentSelection++;
                if (currentSelection > currentSelectionMax) currentSelection = currentSelectionMin;
                enemies[currentSelection].SpriteImage.IsActive = true;
            }

            else if (InputManager.Instance.KeyPressed(Keys.Up) && !playerIsTarget)
            {
                enemies[currentSelection].SpriteImage.IsActive = false;
                currentSelection--;
                if (currentSelection < currentSelectionMin) currentSelection = currentSelectionMax;
                enemies[currentSelection].SpriteImage.IsActive = true;
            }

            else if (InputManager.Instance.KeyPressed(Keys.Left) || InputManager.Instance.KeyPressed(Keys.Right))
            {
                enemies[currentSelection].SpriteImage.IsActive = false;
                playerIsTarget = !playerIsTarget;
                Player.SpriteImage.IsActive = playerIsTarget;
                enemies[currentSelection].SpriteImage.IsActive = !playerIsTarget;
            }

            else if (InputManager.Instance.ActionKeyPressed())
            {
                foreach (var enemy in enemies)
                {
                    if (enemy.SpriteImage.IsActive)
                    {
                        enemy.SpriteImage.IsActive = false;
                        return enemy;
                    }
                }
                Player.SpriteImage.IsActive = false;
                return Player;
            }
            else if (InputManager.Instance.CancelKeyPressed())
            {
                Player.SpriteImage.IsActive = false;
                enemies[currentSelection].SpriteImage.IsActive = false;
                SelectTarget = false;
                commandBox.IsVisible = true;
            }
            else
            {
                if (!playerIsTarget) enemies[currentSelection].SpriteImage.IsActive = true;
                else Player.IsActive = true;
            }
            return null;
        }

        public override void LoadContent()
        {
            base.LoadContent();

            //Load enemies images.
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].LoadContent();
                enemies[i].SpriteImage.Position = StaticConstants.EnemyPositions[i];
            }

            //Load background.
            XmlManager<Image> backgroundLoader = new XmlManager<Image>();
            background = backgroundLoader.Load("Load/Battle/Background.xml");
            background.LoadContent();

            //Load player.
            startingPosition = Player.SpriteImage.Position;
            Player.SpriteImage.Position = StaticConstants.PlayerPosition1;

            //Start music
            backgroundMusic = content.Load<Song>("Music/BattleTheme");
            BackgroundMusicPlayer.Play(backgroundMusic);            

            //Seed both enemies and player with a random action slice

            Player.ActionTimeCurrent = (StaticConstants.Random.Next(0, ((StaticConstants.maxActionTimer*10)/Player.Speed))/10f);
            foreach (var enemy in enemies)
            {
                enemy.ActionTimeCurrent = (StaticConstants.Random.Next(0, ((StaticConstants.maxActionTimer*10)/enemy.Speed))/10f);
            }
        }


        public override void UnloadContent()
        {
            base.UnloadContent();

            background.UnloadContent();
            BackgroundMusicPlayer.Stop();
            backgroundMusic.Dispose();

            foreach (var enemy in enemies)
            {
                enemy.UnloadContent();                
            }
            commandBox.UnloadContent();
            ItemSelectionBox.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            //Battle victory condition.
            if (currentSelectionMin == -1) ScreenManager.Instance.ChangeIngameScreens("MapScreen");
            else if (!Player.IsAlive)
            {
                ScreenManager.Instance.ChangeIngameScreens("TitleScreen");
                return;
            }
            
            base.Update(gameTime);

            Player.Update(gameTime);
            foreach (var enemy in enemies)
            {
                enemy.Update(gameTime);
            }

            if (Player.ActionTimeCurrent >= Player.ActionTimeGoal || commandBox.IsVisible)
            {
                Player.ActionTimeCurrent = 0;                
                commandBox.IsVisible = true;
                commandBox.Update(gameTime);
                if (CommandSequence[0] != string.Empty)
                {                    
                    delay = true;
                    this.playerIsTarget = false;                    
                }             
            }
            //Necessary to avoid instantaneous target selection.
            else if (delay)
            {
                if (++delayCount > 10)
                {
                    delayCount = 0;
                    delay = false;
                }
            }
            else if (ItemSelectionBox.IsVisible)
            {
                ItemSelectionBox.Update(gameTime);

                if (InputManager.Instance.CancelKeyPressed())
                {
                    ItemSelectionBox.IsVisible = false;
                    commandBox.IsVisible = true;
                }

                CommandSequence[1] = ItemSelectionBox.CheckSelection();
                if (CommandSequence[1] != string.Empty)
                {
                    ItemSelectionBox.IsVisible = false;
                    delay = true;
                    SelectTarget = true;
                }
            }
            else if (SelectTarget)
            {
                bool temp = InputManager.Instance.ActionKeyPressed();
                Character target = null;
                target = SelectTargetLogic();
                if (target != null)
                    commandBox.InterpetCommands(CommandSequence, target);
            }
            else
            {
                Player.ActionTimeCurrent += (float)gameTime.ElapsedGameTime.Milliseconds / 1000;
                
                foreach (var enemy in enemies)
                {
                    enemy.ActionTimeCurrent += (float)gameTime.ElapsedGameTime.Milliseconds / 1000;
                }
            }         

            currentSelectionMin = enemies.FindIndex(x => x.IsAlive);
            currentSelectionMax = enemies.FindLastIndex(x => x.IsAlive);            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            background.Draw(spriteBatch);
            Player.Draw(spriteBatch);

            foreach (var enemy in enemies)
            {
                if (enemy.IsAlive) enemy.Draw(spriteBatch);
            }
            commandBox.Draw(spriteBatch);
            ItemSelectionBox.Draw(spriteBatch);
        }
    }
}
