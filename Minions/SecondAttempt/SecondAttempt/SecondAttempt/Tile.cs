//the different tiles on that particular layer 
namespace SecondAttempt
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Tile
    {
        Vector2 position;
        Rectangle sourceRect;
        string state;

        public Rectangle SourceRect
        {
            get { return sourceRect; }
        }

        public Vector2 Position
        {
            get { return position; }
        }

        public void LoadContent(Vector2 position, Rectangle sourceRect, string state)
        {
            this.position = position;
            this.sourceRect = sourceRect;
            this.state = state;
        }

        public void UnloadContent()
        { }

        public void Update(GameTime gameTime, ref Player player)
        { 
            if(state == "Solid")
            {
                Rectangle tileRect = new Rectangle((int)Position.X + 8, (int)Position.Y + 8,
                    sourceRect.Width - 16, sourceRect.Height - 16);
                Rectangle playerRect = new Rectangle((int)player.Image.Position.X,
                    (int)player.Image.Position.Y, player.Image.SourceRect.Width, player.Image.SourceRect.Height);
                //here we implement the collision
                if(playerRect.Intersects(tileRect))
                {
                    //if the solid tile and the player's rectancgles collide we tell where to put the player in the next frame
                    if (player.Velocity.X < 0)//moving left
                        player.Image.Position.X = tileRect.Right;
                    else if (player.Velocity.X > 0)
                        player.Image.Position.X = tileRect.Left - player.Image.SourceRect.Width;
                    else if (player.Velocity.Y < 0)
                        player.Image.Position.Y = tileRect.Bottom;
                    else if (player.Velocity.Y > 0)
                        player.Image.Position.Y = tileRect.Top - player.Image.SourceRect.Height;

                    player.Velocity = Vector2.Zero;//???
                }
            }
        }

        /*public void Draw(SpriteBatch spriteBatch)
        { }*/
    }
}
