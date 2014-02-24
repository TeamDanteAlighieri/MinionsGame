namespace SecondAttempt
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class BoxFrame
    {
        public int BorderWidth { get; set; }
        public Rectangle InternalRect { get; set; }
        private Rectangle upperBorder;
        private Rectangle rightBorder;
        private Rectangle lowerBorder;
        private Rectangle leftBorder;
        public Color InternalColor { get; set; }
        public bool IsVisible { get; set; }
        private Texture2D texture;

        public BoxFrame()
        {
            IsVisible = true;
        }

        public void LoadContent()
        {
            texture = new Texture2D(ScreenManager.Instance.GraphicsDevice, 1, 1);
            texture.SetData(new Color[] { Color.White });
            upperBorder = new Rectangle(this.InternalRect.Left, this.InternalRect.Top - BorderWidth, this.InternalRect.Width + BorderWidth, BorderWidth);
            rightBorder = new Rectangle(this.InternalRect.Right, this.InternalRect.Top, BorderWidth, this.InternalRect.Height + BorderWidth);
            lowerBorder = new Rectangle(this.InternalRect.Left - BorderWidth, this.InternalRect.Bottom, this.InternalRect.Width + BorderWidth, BorderWidth);
            leftBorder = new Rectangle(this.InternalRect.Left - BorderWidth, this.InternalRect.Top - BorderWidth, BorderWidth, this.InternalRect.Height + BorderWidth);
        }

        public void UnloadContent()
        {
            texture.Dispose();
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (IsVisible)
            {
                spriteBatch.Draw(texture, InternalRect, null, InternalColor, 0f, Vector2.Zero, SpriteEffects.None, 0f);
                spriteBatch.Draw(texture, upperBorder, null, Color.WhiteSmoke, 0f, Vector2.Zero, SpriteEffects.None, 0f);
                spriteBatch.Draw(texture, rightBorder, null, Color.WhiteSmoke, 0f, Vector2.Zero, SpriteEffects.None, 0f);
                spriteBatch.Draw(texture, lowerBorder, null, Color.WhiteSmoke, 0f, Vector2.Zero, SpriteEffects.None, 0f);
                spriteBatch.Draw(texture, leftBorder, null, Color.WhiteSmoke, 0f, Vector2.Zero, SpriteEffects.None, 0f);
            }
        }
    }
}
