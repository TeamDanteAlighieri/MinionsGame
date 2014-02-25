namespace SecondAttempt
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class InternalText : IStringSize
    {
        public string Text { get; set; }
        public Vector2 Position { get; set; }
        public Color TextColor { get; set; }
        private string fontName;
        private ContentManager content;
        private SpriteFont font; 

        public InternalText()
        {            
            fontName = "Fonts/Calibri";
            this.LoadContent();
        }

        public virtual void LoadContent()
        {
            content = new ContentManager(ScreenManager.Instance.Content.ServiceProvider, "Content");
            font = content.Load<SpriteFont>(fontName);
        }

        public virtual void UnloadContent()
        {
            content.Unload();            
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public Vector2 StringSize()
        {
            return font.MeasureString(Text);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, Text, Position, TextColor);
        }
    }
}
