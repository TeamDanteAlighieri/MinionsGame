
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

    public class MapScreen : GameplayScreen
    {
        private Player playerSprite;
        private Map map;
        private Song backgroundMusic;
        private float nextBattle;
        //static Random generator = new Random();
        

        public override void LoadContent()
        {
            base.LoadContent();
            XmlManager<Player> playerLoader = new XmlManager<Player>();
            XmlManager<Map> mapLoader = new XmlManager<Map>();
            playerSprite = playerLoader.Load("Load/Gameplay/Player.xml");
            map = mapLoader.Load("Load/Gameplay/Maps/Map1.xml");
            playerSprite.LoadContent();
            map.LoadContent();
            backgroundMusic = content.Load<Song>("Music/mainSong");
            BackgroundMusicPlayer.Play(backgroundMusic);
            nextBattle = (float) StaticProperties.Random.Next(3, 5);
            //Testing the save method of saveGameContent here
            //SaveGameContent saveLoadGenerator = new SaveGameContent(playerSprite);
            //saveLoadGenerator.Save();
            //playerSprite = saveLoadGenerator.Load();
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            playerSprite.UnloadContent();
            map.UnloadContent();
            BackgroundMusicPlayer.Stop();
            backgroundMusic.Dispose();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            playerSprite.Update(gameTime);
            map.Update(gameTime, playerSprite);
            nextBattle -= (float) gameTime.ElapsedGameTime.TotalMilliseconds / 1000;
            if (nextBattle <= 0)
            {
                ScreenManager.Instance.ChangeIngameScreens("BattleScreen");
                nextBattle = StaticProperties.Random.Next(3, 5);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            map.Draw(spriteBatch, "Underlay");
            playerSprite.Draw(spriteBatch);
            map.Draw(spriteBatch, "Overlay");
        }
    }
}
