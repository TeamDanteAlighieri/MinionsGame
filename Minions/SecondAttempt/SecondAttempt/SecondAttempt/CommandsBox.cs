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
    using Microsoft.Xna.Framework.Input;
    class CommandsBox
    {
        public char Axis { get; set; }
        public BoxFrame Frame { get; set; }
        [XmlElement("TextVar")]
        public InternalText[] TextContent { get; set; }
        public bool IsActive { get; set; }
        public bool IsVisible { get; set; }
        private int activeElement;

        public CommandsBox(char axis)
        {
            this.Axis = axis;
            this.activeElement = 0;
            this.IsActive = false;
            this.IsVisible = true;
        }

        public CommandsBox(InternalText[] textContent, char axis) : this (axis)
        {
            this.TextContent = textContent;
        }

        public void LoadContent()
        {
            Frame.LoadContent();
            foreach (var text in TextContent)
            {
                text.LoadContent();
            }

            if (Axis == 'x')
            {
                for (int i = 0; i < TextContent.Length; i++)
                {
                    TextContent[i].Position = new Vector2(Frame.InternalRect.Left + 5 + 5 * i, Frame.InternalRect.Top + 5);
                }
            }
            else if (Axis == 'y')
            {
                for (int i = 0; i < TextContent.Length; i++)
                {
                    TextContent[i].Position = new Vector2(Frame.InternalRect.Left + 5, Frame.InternalRect.Top + 5 + 20 * i);
                }
            }
        }

        public void UnloadContent()
        {

        }

        public void Update()
        {
            if (IsActive)
            {
                if (Axis == 'X')
                {
                    if (InputManager.Instance.KeyPressed(Keys.Left) && --activeElement < 0) activeElement = 0;
                    if (InputManager.Instance.KeyPressed(Keys.Right) && ++activeElement >= TextContent.Length) activeElement = TextContent.Length - 1;
                }
                else if (Axis == 'Y')
                {
                    if (InputManager.Instance.KeyPressed(Keys.Up) && --activeElement < 0) activeElement = 0;
                    if (InputManager.Instance.KeyPressed(Keys.Down) && ++activeElement >= TextContent.Length) activeElement = TextContent.Length - 1;
                }
                for (int i = 0; i < 4; i++)
                {
                    TextContent[i].TextColor = Color.Gray;
                }
                TextContent[activeElement].TextColor = Color.White;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (IsVisible)
            {
                Frame.Draw(spriteBatch);
                foreach (var text in TextContent)
                {
                    text.Draw(spriteBatch);
                }
            }
        }
    }
}
