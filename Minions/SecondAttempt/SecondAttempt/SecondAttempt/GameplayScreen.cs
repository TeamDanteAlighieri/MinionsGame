namespace SecondAttempt
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class GameplayScreen : GameScreen
    {
        public static Minion player;

        public override void LoadContent()
        {
            base.LoadContent();
            XmlManager<Minion> playerLoader = new XmlManager<Minion>();
            //player = playerLoader.Load("Gameplay/Player/Info.xml");
            //player.LoadContent();
            //Logic for player load goes here;
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            //Logic for player clear goes here.
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            //Player update logic goes here (if necessary)
        }

        public override void Draw(SpriteBatch spriteBatch)
        {            
        }
    }
}
