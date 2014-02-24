﻿
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
        

        public override void LoadContent()
        {
            base.LoadContent();

            //Load the player sprite;
            XmlManager<Player> playerLoader = new XmlManager<Player>();
            playerSprite = playerLoader.Load("Load/Gameplay/Player.xml");
            playerSprite.LoadContent();

            //Load the map.
            XmlManager<Map> mapLoader = new XmlManager<Map>();
            map = mapLoader.Load("Load/Gameplay/Maps/Map1.xml");
            map.LoadContent();

            //Start the bgm.
            backgroundMusic = content.Load<Song>("Music/mainSong");
            BackgroundMusicPlayer.Play(backgroundMusic);
            nextBattle = (float) StaticProperties.Random.Next(3, 5);

            //Testing the save method of saveGameContent here
            SaveGameContent saveLoadGenerator = new SaveGameContent(playerSprite);
            saveLoadGenerator.Save();
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
            if (playerSprite.Velocity != Vector2.Zero) nextBattle -= (float) gameTime.ElapsedGameTime.TotalMilliseconds / 1000;
            if (nextBattle <= 0)
            {
                int enemiesCount = StaticProperties.Random.Next(1, 4);
                int enemyType = StaticProperties.Random.Next(0, RegEnemies.Collection.Count);
                List<Enemy> enemies = new List<Enemy>();
                for (int i = 0; i < enemiesCount; i++)
                {
                    enemies.Add((Enemy)RegEnemies.Collection[enemyType].Clone());
                }            
                ScreenManager.Instance.ChangeToRandomBattle(enemies);
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
