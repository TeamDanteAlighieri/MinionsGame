namespace SecondAttempt
{
    using Microsoft.Xna.Framework;    
    using Microsoft.Xna.Framework.Graphics;

    public struct FrameBox
    {
        public int BorderWidth;
        public Color InternalColor;
        public Rectangle InternalRect;
        private Rectangle upperBorder;
        private Rectangle rightBorder;
        private Rectangle lowerBorder;
        private Rectangle leftBorder;        
        private Texture2D texture;

        public FrameBox(int borderWidth, Rectangle internalRect, Color internalColor)
        {
            this.BorderWidth = borderWidth;
            this.InternalRect = internalRect;
            this.InternalColor = internalColor;

            texture = new Texture2D(ScreenManager.Instance.GraphicsDevice, 1, 1);
            texture.SetData(new Color[] { Color.White });
            upperBorder = new Rectangle(this.InternalRect.Left, this.InternalRect.Top - BorderWidth, this.InternalRect.Width + BorderWidth, BorderWidth);
            rightBorder = new Rectangle(this.InternalRect.Right, this.InternalRect.Top, BorderWidth, this.InternalRect.Height + BorderWidth);
            lowerBorder = new Rectangle(this.InternalRect.Left - BorderWidth, this.InternalRect.Bottom, this.InternalRect.Width + BorderWidth, BorderWidth);
            leftBorder = new Rectangle(this.InternalRect.Left - BorderWidth, this.InternalRect.Top - BorderWidth, BorderWidth, this.InternalRect.Height + BorderWidth);
        }

        public void LoadContent()
        {
           
        }
      
        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {            
            spriteBatch.Draw(texture, InternalRect, null, InternalColor, 0f, Vector2.Zero, SpriteEffects.None, 0f);
            spriteBatch.Draw(texture, upperBorder, null, Color.WhiteSmoke, 0f, Vector2.Zero, SpriteEffects.None, 0f);
            spriteBatch.Draw(texture, rightBorder, null, Color.WhiteSmoke, 0f, Vector2.Zero, SpriteEffects.None, 0f);
            spriteBatch.Draw(texture, lowerBorder, null, Color.WhiteSmoke, 0f, Vector2.Zero, SpriteEffects.None, 0f);
            spriteBatch.Draw(texture, leftBorder, null, Color.WhiteSmoke, 0f, Vector2.Zero, SpriteEffects.None, 0f);
        }
    }
}
