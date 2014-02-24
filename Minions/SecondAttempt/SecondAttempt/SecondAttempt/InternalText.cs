using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecondAttempt
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    class InternalText
    {
        public string Text { get; set; }
        public bool IsVisible { get; set; }
        public Vector2 Position { get; set; }
        public Color TextColor { get; set; }
        private string fontName;
        private ContentManager content;
        private SpriteFont font; 

        public InternalText()
        {
            IsVisible = true;
            fontName = "Fonts/Calibri";
        }

        public void LoadContent()
        {
            content = new ContentManager(ScreenManager.Instance.Content.ServiceProvider, "Content");
            font = content.Load<SpriteFont>(fontName);
        }

        public void UnloadContent()
        {
            content.Unload();            
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (IsVisible) spriteBatch.DrawString(font, Text, Position, TextColor);
        }
    }
}
