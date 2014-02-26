namespace SecondAttempt
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;    

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// Used to store a players battle command menu.
    /// </summary>
    public class CommandsBox
    {        
        /// <summary>
        /// The visual box frame.
        /// </summary>
        public FrameBox Frame { get; set; }        
        /// <summary>
        /// Contains the available commands for a character.
        /// </summary>
        public CommandBoxItem[] Items { get; set; }        
        /// <summary>
        /// Indicates if the CommandBos is currently active.
        /// </summary>
        public bool IsVisible { get; set; }
        /// <summary>
        /// Internal storage of the currently active element.
        /// </summary>
        private int activeElement;
        /// <summary>
        /// Indicates the axial orientation of the box. X - horizontal, Y - vertical.
        /// </summary>
        private char axis;

        public CommandsBox(char axis)
        {
            this.Frame = new FrameBox();
            this.activeElement = 0;
            this.IsVisible = false;
            this.axis = axis;
        }

        protected virtual void OnSelectEntry()
        {
            Items[activeElement].OnSelectEntry();
        }

        protected virtual void OnCancel()
        {

        }

        public virtual void InterpetCommands(string[] commandArguments, Character target)
        {

        }

        public virtual void LoadContent()
        {
            foreach (var text in Items)
            {
                text.LoadContent();                
            }

            if (axis == 'y')
            {
                for (int i = 0; i < Items.Length; i++)
                {
                    Items[i].Position = new Vector2(Frame.InternalRect.Left + 5, Frame.InternalRect.Top + 5 + 20 * i);
                }
            }
            else if (axis == 'x')
            {
                Items[0].Position = new Vector2(Frame.InternalRect.Left + 10, this.Frame.InternalRect.Top + 5);
                for (int i = 1; i < Items.Length; i++)
                {
                    Items[i].Position = Items[i - 1].Position + new Vector2(Items[i - 1].StringSize().X + 10, 0);
                }
            }
        }

        public virtual void UnloadContent()
        {
            foreach (var item in Items)
            {
                item.UnloadContent();
            }
        }

        public virtual void Update(GameTime gameTime)
        {
            if (IsVisible)
            {
                Items[activeElement].IsActive = false;
                if (axis == 'y')
                {
                    if (InputManager.Instance.KeyPressed(Keys.Up) && --activeElement < 0)
                        activeElement = Items.Length - 1;
                    if (InputManager.Instance.KeyPressed(Keys.Down) && ++activeElement >= Items.Length)
                        activeElement = 0;
                }
                else if (axis == 'x')
                {
                    if (InputManager.Instance.KeyPressed(Keys.Left) && --activeElement < 0)
                        activeElement = 0;
                    if (InputManager.Instance.KeyPressed(Keys.Right) && ++activeElement >= Items.Length)
                        activeElement = Items.Length - 1;
                }
                Items[activeElement].IsActive = true;

                foreach (var item in Items)
                {
                    item.Update(gameTime);
                }

                if (InputManager.Instance.KeyPressed(Keys.Enter) || InputManager.Instance.KeyPressed(Keys.A))
                {
                    OnSelectEntry();
                }

                if (InputManager.Instance.CancelKeyPressed())
                {
                    OnCancel();
                }
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (IsVisible)
            {
                Frame.Draw(spriteBatch);
                foreach (var text in Items)
                {
                    text.Draw(spriteBatch);
                }
            }
        }
    }
}
