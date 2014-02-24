namespace SecondAttempt
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using System.Xml.Serialization;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class GameplayScreen : GameScreen
    {
        public static Minion PlayerChar;
        public static NormalEnemies RegEnemies;

        public override void LoadContent()
        {
            base.LoadContent();
            if (PlayerChar == null)
            {
                XmlManager<Minion> playerLoad = new XmlManager<Minion>();
                PlayerChar = playerLoad.Load("Load/Gameplay/PlayerInfo.xml");
                PlayerChar.LoadContent();
                XmlManager<NormalEnemies> enemies = new XmlManager<NormalEnemies>();
                RegEnemies = enemies.Load("Load/Gameplay/RegularEnemies.xml");
            }
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
