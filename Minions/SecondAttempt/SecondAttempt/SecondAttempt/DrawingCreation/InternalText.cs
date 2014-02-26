namespace SecondAttempt
{    
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Creats a text object at with specified text content, screen position and text color.
    /// </summary>
    public class FloatingText : IStringSize
    {
        public string Text { get; set; }
        public Vector2 Position { get; set; }
        public Color TextColor { get; set; }
        private string fontName;
        private ContentManager content;
        private SpriteFont font; 

        public FloatingText()
        {            
            fontName = "Fonts/Calibri";
            this.LoadContent();
        }

        /// <summary>
        /// Gets the width and height of a string object created using the fontName font.
        /// </summary>
        /// <returns></returns>
        public Vector2 StringSize()
        {
            return font.MeasureString(Text);
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

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, Text, Position, TextColor);
        }
    }
}
