
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
        Player playerSprite;
        Map map;
        Song backgroundMusic;
        float nextBattle;
        static Random generator = new Random();
        

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
            nextBattle = generator.Next(9999, 10000);
            SaveGameContent saveLoadGenerator = new SaveGameContent(playerSprite);
            saveLoadGenerator.Save(saveLoadGenerator);
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
            map.Update(gameTime, ref playerSprite);
            nextBattle -= (float) gameTime.ElapsedGameTime.TotalMilliseconds / 1000;
            if (nextBattle <= 0)
            {
                ScreenManager.Instance.ChangeIngameScreens("BattleScreen");
                nextBattle = generator.Next(9999, 10000);
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
