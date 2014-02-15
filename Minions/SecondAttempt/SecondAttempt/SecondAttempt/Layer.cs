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
        //[XmlElement("SolidTiles")]
        public string SolidTiles;
        List<Tile> tiles;
        string state;


        public Layer()
        {
            Image = new Image();
            tiles = new List<Tile>();
            SolidTiles = String.Empty;
        }

        public void LoadContent(Vector2 tileDimensions)
        {
            Image.LoadContent();
            Vector2 position = -tileDimensions;

            foreach (var row in Tile.Row)
            {
                string[] split = row.Split(']');
                position.X = -tileDimensions.X; // we are going to resset the x position every time we increase the y poss
                position.Y += tileDimensions.Y;
                foreach (string s in split)
                {
                    
                    if (s != String.Empty)
                    {
                        position.X += tileDimensions.X;
                        if (!s.Contains("x"))
                        {
                            state = "Passive";
                            tiles.Add(new Tile());


                            string str = s.Replace("[", String.Empty);//after this the string should look like 0:0
                            int value1 = int.Parse(str.Substring(0, str.IndexOf(':')));
                            int value2 = int.Parse(str.Substring(str.IndexOf(':') + 1));
                            //?
                            if(SolidTiles.Contains("[" + value1.ToString() + ":" + value2.ToString() + "]"))
                                state = "Solid";

                            tiles[tiles.Count - 1].LoadContent(position, new Rectangle(
                                value1 * (int)tileDimensions.X, value2 * (int)tileDimensions.Y,
                                (int)tileDimensions.X, (int)tileDimensions.Y), state);//we store the position of the current tile  
                        }
                    }
                }
            }
        }

        public void UnloadContent()
        {
            Image.UnloadContent();
        }

        public void Update(GameTime gameTime, ref Player player)
        {
            foreach (Tile tile in tiles)
                tile.Update(gameTime, ref player);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(Tile tile in tiles)
            {
                Image.Position = tile.Position;
                Image.SourceRect = tile.SourceRect;
                Image.Draw(spriteBatch);
            }

        }
    }
}
