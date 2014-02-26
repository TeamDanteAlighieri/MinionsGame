//the different tiles on that particular layer 
namespace SecondAttempt
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Holds the pixel position and image size for the creation of a map tile.
    /// </summary>
    public class Tile
    {
        private Vector2 position;
        private Rectangle sourceRect;
        private string state;
        private bool isShopkeeper;        

        public Rectangle SourceRect
        {
            get { return sourceRect; }
        }

        public Vector2 Position
        {
            get { return position; }
        }

        public void LoadContent(Vector2 position, Rectangle sourceRect, string state, bool isShopkeeper)
        {
            this.position = position;
            this.sourceRect = sourceRect;
            this.state = state;
            this.isShopkeeper = isShopkeeper;
        }

        public void UnloadContent()
        { }

        public void Update(GameTime gameTime, OverworldSprite player)
        { 
            if(state == "Solid")
            {
                Rectangle tileRect = new Rectangle((int)Position.X + 6, (int)Position.Y + 13,
                    sourceRect.Width - 12, sourceRect.Height - 12);
                Rectangle playerRect = new Rectangle((int)player.Image.Position.X,
                    (int)player.Image.Position.Y, player.Image.SourceRect.Width, player.Image.SourceRect.Height);
                //here we implement the collision
                if (playerRect.Intersects(tileRect))
                {
                    if (isShopkeeper)
                    {
                        //TO DO: IMPLEMENTATION
                        //trigger the event/open the trading screen
                    }
                    
                    //if the solid tile and the player's rectancgles collide we tell where to put the player in the next frame
                    if (player.Velocity.X < 0)//moving left
                        player.Image.Position.X = tileRect.Right;
                    else if (player.Velocity.X > 0)
                        player.Image.Position.X = tileRect.Left - player.Image.SourceRect.Width;
                    else if (player.Velocity.Y < 0)
                        player.Image.Position.Y = tileRect.Bottom;
                    else
                        player.Image.Position.Y = tileRect.Top - player.Image.SourceRect.Height;

                    //Stop the player from moving.
                    player.Velocity = Vector2.Zero;
                }
            }
        }

        /*public void Draw(SpriteBatch spriteBatch)
        { }*/
    }
}
