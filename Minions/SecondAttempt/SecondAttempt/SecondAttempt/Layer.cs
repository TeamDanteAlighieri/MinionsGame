//containg the different layers on that map
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

    public class Layer
    {
        public class TileMap
        {
            [XmlElement("Row")]
            public List<string> Row;

            public TileMap()
            {
                Row = new List<string>();
            }
        }

        [XmlElement("TileMap")]
        public TileMap Tile;
        private List<Tile> tiles;

        public Layer()
        {

        }

        public void LoadContent(Vector2 tileDimensions)
        {
            foreach (var row in Tile.Row)
            {
                string[] split = row.Split(']'); //splitva ot xml faila na kartata po ]
                foreach(string s in split)
                { 
                    if(s != String.Empty)
                    {
                        string str = s.Replace("[", String.Empty);//after this the string should look like 0:0
                        int value1 = int.Parse(str.Substring(0, str.IndexOf(':')));
                        int value2 = int.Parse(str.Substring(str.IndexOf(':') + 1));
                    }
                }
            }
        }

        public void UnloadContent()
        {

        }

        public void Update(GameTime gameTime)
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
