
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

    public class BattleScreen : GameScreen
    {
        private Image background;
        private Minion character;
        private List<Enemy> enemies;
        Song backgroundMusic;

        /*
        public BattleScreen()
        {
            this.background = new Image();
            this.character = new Minion();
            this.enemies = new List<Enemy>();
        }
        /*
        public override void LoadContent(List<Enemy> enemies, Minion character, Image background)
        {
            base.LoadContent();
            this.background = background;
            this.character = character;
            this.enemies = enemies;
        }*/

        public override void LoadContent()
        {
            base.LoadContent();
            XmlManager<Image> backgroundLoader = new XmlManager<Image>();
            background = backgroundLoader.Load("Load/Battle/Background.xml");
            background.LoadContent();
            backgroundMusic = content.Load<Song>("Music/BattleTheme");
            MediaPlayer.Play(backgroundMusic);
            /*this.background = new Image();
            background.Path = "Gameplay/Battle/background";
            background.SourceRect = new Rectangle(0, 0, 640, 320);
            background.LoadContent();
            this.character = null;
            this.enemies = null;*/
        }


        public override void UnloadContent()
        {
            base.UnloadContent();
            background.UnloadContent();
            MediaPlayer.Stop();
            backgroundMusic.Dispose();
            /*
            if(character != null)character.UnloadContent() ;
            if (enemies != null ) foreach (var enemy in enemies)
            {
                enemy.UnloadContent();                
            }*/
        }

        
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);/*
            if (character != null) character.Update(gameTime);
            if (enemies != null) foreach (var enemy in enemies)
            {
                enemy.Update(gameTime);   
            }            */
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            background.Draw(spriteBatch);/*
            if (character != null) character.Draw(spriteBatch);
            if (enemies != null) foreach (var enemy in enemies)
            {
                enemy.Draw(spriteBatch);
            }            */
        }
    }
}
