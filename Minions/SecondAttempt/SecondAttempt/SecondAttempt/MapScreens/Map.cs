﻿//this is gonna be the current map that we are on (displaying the map that we are on)
//goona store the dimensions on each of the tiles in that current map and then gonna
//pass it to the layer
namespace SecondAttempt
{    
    using System.Collections.Generic;

    using System.Xml.Serialization;

    using Microsoft.Xna.Framework;    
    using Microsoft.Xna.Framework.Graphics;

    public class Map
    {
        [XmlElement("Layer")]
        public List<Layer> Layer;
        public Vector2 TileDimensions;

        public Map()
        {
            Layer = new List<Layer>();            
            TileDimensions = Vector2.One * 32;
        }

        public void LoadContent()
        {
            foreach (Layer l in Layer)
                l.LoadContent(TileDimensions);
        }

        public void UnloadContent()
        {
            foreach (Layer l in Layer)
                l.UnloadContent();
        }

        public void Update(GameTime gameTime, OverworldSprite player)
        {
            foreach (Layer l in Layer)
                l.Update(gameTime, player);
        }

        public void Draw(SpriteBatch spriteBatch, string drawType)
        {
            foreach (Layer l in Layer)
                l.Draw(spriteBatch, drawType);
        }
    }
}
