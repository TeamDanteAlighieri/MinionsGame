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
        public Image Image;// give image to our sprite sheet
        List<Tile> tiles;


        public Layer()
        {
            Image = new Image();
            tiles = new List<Tile>();
        }

        public void LoadContent(Vector2 tileDimensions)
        {
            Vector2 position = tileDimensions - new Vector2(32, 32);
            foreach (var row in Tile.Row)
            {
                string[] split = row.Split(']'); //splitva ot xml faila na kartata po ]
                position.Y += tileDimensions.Y;
                foreach (string s in split)
                {

                    if (s != String.Empty)
                    {
                        position.X += tileDimensions.X;
                        tiles.Add(new Tile());


                        string str = s.Replace("[", String.Empty);//after this the string should look like 0:0
                        int value1 = int.Parse(str.Substring(0, str.IndexOf(':')));
                        int value2 = int.Parse(str.Substring(str.IndexOf(':') + 1));

                        /*tiles[tiles.Count - 1].LoadContent(position, new Rectangle(
                            value1 * (int)tileDimensions.X, value2 * (int)tileDimensions.Y,
                            (int)tileDimensions.X, (int)tileDimensions.Y));*/
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
