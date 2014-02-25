
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
        public bool RestartActionTime;
        public bool SelectTarget;
        public bool SelectItem;
        public bool SelectSkill;

        public string[] CommandSequence;


        public BattleScreen(List<Enemy> enemies)
        {
            this.enemies = enemies;

            RestartActionTime = false;
            playerIsTarget = false;
            delay = false;
            delayCount = 0;
            SelectTarget = false;
            SelectItem = false;
            SelectSkill = false;

            currentSelection = 0;
            currentSelectionMin = 0;
            currentSelectionMax = enemies.Count() - 1;          
            
            CommandSequence = new string[2];
            this.commandBox = new MinionCommandBox(this, PlayerChar);
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
            startingPosition = PlayerChar.SpriteImage.Position;
            PlayerChar.SpriteImage.Position = StaticConstants.PlayerPosition1;

            //Start music
            backgroundMusic = content.Load<Song>("Music/BattleTheme");
            BackgroundMusicPlayer.Play(backgroundMusic);            

            //Seed both enemies and player with a random action slice

            PlayerChar.ActionTimeCurrent = (StaticConstants.Random.Next(0, ((StaticConstants.maxActionTimer*10)/PlayerChar.Speed))/10f);
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

            if ( enemies != null ) foreach (var enemy in enemies)
            {
                enemy.UnloadContent();                
            }
        }

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
                PlayerChar.SpriteImage.IsActive = playerIsTarget;
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
                PlayerChar.SpriteImage.IsActive = false;
                return PlayerChar;
            }

            else
            {
                if (!playerIsTarget) enemies[currentSelection].SpriteImage.IsActive = true;
                else PlayerChar.IsActive = true;
            }
            return null;
        }

        public override void Update(GameTime gameTime)
        {
            //Battle victory condition.
            if (currentSelectionMin == -1) ScreenManager.Instance.ChangeIngameScreens("MapScreen");
            else if (!PlayerChar.IsAlive)
            {
                ScreenManager.Instance.ChangeIngameScreens("TitleScreen");
                return;
            }
            
            base.Update(gameTime);

            PlayerChar.Update(gameTime);
            foreach (var enemy in enemies)
            {
                enemy.Update(gameTime);
            }

            if (PlayerChar.ActionTimeCurrent >= PlayerChar.ActionTimeGoal || commandBox.IsVisible)
            {
                PlayerChar.ActionTimeCurrent = 0;
                RestartActionTime = true;
                commandBox.IsVisible = true;
                commandBox.Update(gameTime);
                if (SelectTarget)
                {
                    InputManager.Instance.Update();
                    delay = true;
                }
                
            }
            else if (delay)
            {
                if (++delayCount > 10)
                {
                    delayCount = 0;
                    delay = false;
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
                PlayerChar.ActionTimeCurrent += (float)gameTime.ElapsedGameTime.Milliseconds / 1000;
                /*
                foreach (var enemy in enemies)
                {
                    enemy.ActionTimeCurrent += (float)gameTime.ElapsedGameTime.Milliseconds / 1000;
                }*/
            }         

            currentSelectionMin = enemies.FindIndex(x => x.IsAlive);
            currentSelectionMax = enemies.FindLastIndex(x => x.IsAlive);            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            background.Draw(spriteBatch);
            PlayerChar.Draw(spriteBatch);

            foreach (var enemy in enemies)
            {
                if (enemy.IsAlive) enemy.Draw(spriteBatch);
            }
            commandBox.Draw(spriteBatch);
        }
    }
}
