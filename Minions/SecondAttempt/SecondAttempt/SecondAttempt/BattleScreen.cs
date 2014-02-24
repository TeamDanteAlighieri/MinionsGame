
namespace SecondAttempt
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Media;

    public class BattleScreen : GameplayScreen
    {
        //Sprites
        private List<Enemy> enemies;
        private Image background;
        private Song backgroundMusic;
        private Vector2 startingPosition;

        private bool playerAction;
        private Skill selectedSkill;
        private Item selectedItem;

        public BattleScreen(List<Enemy> enemies)
        {
            this.enemies = enemies;
            playerAction = false;
        }

        public override void LoadContent()
        {
            base.LoadContent();

            //Load enemies images.
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].LoadContent();
                enemies[i].SpriteImage.Position = StaticProperties.EnemyPositions[i];
            }

            //Load background.
            XmlManager<Image> backgroundLoader = new XmlManager<Image>();
            background = backgroundLoader.Load("Load/Battle/Background.xml");
            background.LoadContent();

            //Load player.
            startingPosition = PlayerChar.SpriteImage.Position;
            PlayerChar.SpriteImage.Position = StaticProperties.PlayerPosition1;

            //Start music
            backgroundMusic = content.Load<Song>("Music/BattleTheme");
            BackgroundMusicPlayer.Play(backgroundMusic);            

            //Seed both enemies and player with a random action slice

            //PlayerChar.ActionTimer = StaticProperties.Random.NextDouble()
        }


        public override void UnloadContent()
        {
            base.UnloadContent();
            background.UnloadContent();
            BackgroundMusicPlayer.Stop();
            backgroundMusic.Dispose();
            PlayerChar.SpriteImage.Position = startingPosition;
            if ( enemies != null ) foreach (var enemy in enemies)
            {
                enemy.UnloadContent();                
            }
        }

        
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            PlayerChar.Update(gameTime);
            foreach (var enemy in enemies)
            {
                enemy.Update(gameTime);
            }
           
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            background.Draw(spriteBatch);
            PlayerChar.Draw(spriteBatch);
            foreach (var enemy in enemies)
            {
                enemy.Draw(spriteBatch);
            }           
        }
    }
}
