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

    class CommandsBox
    {        
        public FrameBox Frame { get; set; }        
        public CommandBoxItem[] Items { get; set; }        
        public bool IsVisible { get; set; }
        private int activeElement;

        public CommandsBox()
        {
            this.Frame = new FrameBox();
            this.activeElement = 0;
            this.IsVisible = false;
        }

        public void LoadContent()
        {
            foreach (var text in Items)
            {
                text.LoadContent();
            }
          
            for (int i = 0; i < Items.Length; i++)
            {
                Items[i].Position = new Vector2(Frame.InternalRect.Left + 5, Frame.InternalRect.Top + 5 + 20 * i);
            }            
        }

        public void Update(GameTime gameTime)
        {
            if (IsVisible)
            {
                Items[activeElement].IsActive = false;
                if (InputManager.Instance.KeyPressed(Keys.Up) && --activeElement < 0)
                    activeElement = Items.Length - 1;
                if (InputManager.Instance.KeyPressed(Keys.Down) && ++activeElement >= Items.Length) 
                    activeElement = 0;
                Items[activeElement].IsActive = true;

                foreach (var item in Items)
                {
                    item.Update(gameTime);
                }

                if (InputManager.Instance.KeyPressed(Keys.Enter) || InputManager.Instance.KeyPressed(Keys.A))
                {
                    OnSelectEntry();
                }
            }
        }

        protected virtual void OnSelectEntry()
        {
            Items[activeElement].OnSelectEntry();
        }

        public virtual void InterpetCommands(string[] commandArguments, Character target)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
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
