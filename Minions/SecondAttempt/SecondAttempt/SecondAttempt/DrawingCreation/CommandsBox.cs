namespace SecondAttempt
{   
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
        /// The rectangular box from.
        /// </summary>
        public FrameBox Frame { get; set; }        
        /// <summary>
        /// Contains the available commands to select from.
        /// </summary>
        public CommandBoxItem[] Items { get; set; }        
        /// <summary>
        /// Indicates if the CommandBos is currently visible. Depending on screen logic can also indicate if its active.
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

        /// <summary>
        /// When a CommandBoxItem is selected, triggers the appropriate selection event for the entry.
        /// </summary>
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
           
        }

        public virtual void UnloadContent()
        {
            foreach (var item in Items)
            {
                item.UnloadContent();
            }
        }

        /// <summary>
        /// Handles player input when object is active.
        /// </summary>
        /// <param name="gameTime"></param>
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
