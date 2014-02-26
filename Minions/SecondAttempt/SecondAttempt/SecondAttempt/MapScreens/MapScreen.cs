namespace SecondAttempt
{    
    using System.Collections.Generic;
    
    using Microsoft.Xna.Framework;    
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Media;

    public class MapScreen : GameplayScreen
    {
        private OverworldSprite playerSprite;
        private Map map;
        private Song backgroundMusic;
        private float nextBattle;        
        

        public override void LoadContent()
        {
            base.LoadContent();

            //Load the player sprite;
            XmlManager<OverworldSprite> playerLoader = new XmlManager<OverworldSprite>();
            playerSprite = playerLoader.Load("Load/Gameplay/OverworldSprite.xml");
            playerSprite.LoadContent();

            //Load the map.
            XmlManager<Map> mapLoader = new XmlManager<Map>();
            map = mapLoader.Load("Load/Gameplay/Maps/Map1.xml");
            map.LoadContent();

            //Start the bgm.
            backgroundMusic = content.Load<Song>("Music/mainSong");
            BackgroundMusicPlayer.Play(backgroundMusic);
            nextBattle = (float) Constants.Random.Next(3, 5);            
        }

        public void ReloadMusic()
        {
            backgroundMusic = content.Load<Song>("Music/mainSong");
            BackgroundMusicPlayer.Play(backgroundMusic);
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
            if (InputManager.Instance.CancelKeyPressed()) ScreenManager.Instance.ChangeIngameScreens("IngameMenuScreen");
            if (nextBattle <= 0)
            {
                int enemiesCount = Constants.Random.Next(1, 4);
                int enemyType = Constants.Random.Next(0, RegEnemies.Collection.Count);
                List<Enemy> enemies = new List<Enemy>();
                for (int i = 0; i < enemiesCount; i++)
                {
                    enemies.Add((Enemy)RegEnemies.Collection[enemyType].Clone());
                }            
                ScreenManager.Instance.ChangeToBattleScreen(enemies);
                nextBattle = Constants.Random.Next(20, 30);
            }            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {            
            map.Draw(spriteBatch, "Underlay");
            playerSprite.Draw(spriteBatch);
            map.Draw(spriteBatch, "Overlay");
        }
    }
}
