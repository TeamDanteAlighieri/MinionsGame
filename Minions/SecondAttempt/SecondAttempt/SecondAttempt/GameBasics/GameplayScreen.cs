namespace SecondAttempt
{
    using Microsoft.Xna.Framework;    
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// All gameplay screens should inherit this class.
    /// </summary>
    public class GameplayScreen : GameScreen
    {
        //Both are defined as static so that only on instance will be created.
        public static Minion Player;
        public static NormalEnemies RegEnemies;

        public override void LoadContent()
        {
            base.LoadContent();
            if (Player == null)
            {
                XmlManager<Minion> playerLoad = new XmlManager<Minion>();
                Player = playerLoad.Load("Load/Gameplay/PlayerInfo.xml");
                Player.LoadContent();
                XmlManager<NormalEnemies> enemies = new XmlManager<NormalEnemies>();
                RegEnemies = enemies.Load("Load/Gameplay/RegularEnemies.xml");
            }
        }

        public override void UnloadContent()
        {
            base.UnloadContent();            
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {            
        }
    }
}
