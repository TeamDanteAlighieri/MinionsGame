
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
        private Image background;
        private List<Enemy> enemies;
        private Song backgroundMusic;
        private Vector2 startingPosition;

        public override void LoadContent()
        {
            base.LoadContent();
            XmlManager<Image> backgroundLoader = new XmlManager<Image>();
            background = backgroundLoader.Load("Load/Battle/Background.xml");
            background.LoadContent();
            startingPosition = PlayerChar.SpriteImage.Position;
            PlayerChar.SpriteImage.Position = StaticProperties.PlayerPosition1;
            backgroundMusic = content.Load<Song>("Music/BattleTheme");
            BackgroundMusicPlayer.Play(backgroundMusic);            
        }


        public override void UnloadContent()
        {
            base.UnloadContent();
            background.UnloadContent();
            BackgroundMusicPlayer.Stop();
            backgroundMusic.Dispose();
            PlayerChar.SpriteImage.Position = startingPosition;
            /*
            if ( character != null ) character.UnloadContent();
            if ( enemies != null ) foreach (var enemy in enemies)
            {
                enemy.UnloadContent();                
            }*/
        }

        
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            PlayerChar.Update(gameTime);
            PlayerChar.SpriteImage.SpriteSheetEffect.CurrentFrame.Y = 2;
            /*
            if (character != null) character.Update(gameTime);
            if (enemies != null) foreach (var enemy in enemies)
            {
                enemy.Update(gameTime);   
            }            */
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            background.Draw(spriteBatch);
            PlayerChar.Draw(spriteBatch);            
            /*
            if (character != null) character.Draw(spriteBatch);
            if (enemies != null) foreach (var enemy in enemies)
            {
                enemy.Draw(spriteBatch);
            }            */
        }
    }
}
