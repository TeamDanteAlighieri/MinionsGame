namespace SecondAttempt
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class ListDescriptorItem
    {
        public InternalText Name;
        public InternalText Number;
        public bool IsActive { get; set; }

        public ListDescriptorItem()
        {
            this.Name = new InternalText();
            this.Number = new InternalText();
            this.Name.TextColor = Color.Gray;
            this.Number.TextColor = Color.Gray;
            IsActive = false;
        }       
        
        public virtual void UnloadContent()
        {
            Name.UnloadContent();
            Number.UnloadContent();
        }

        public virtual void Update(GameTime gameTime)
        {
            if (IsActive)
            {
                Name.TextColor = Color.White;
                Number.TextColor = Color.White;
            }
            else
            {
                Name.TextColor = Color.Gray;
                Number.TextColor = Color.Gray;
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Name.Draw(spriteBatch);
            Number.Draw(spriteBatch);
        }
    }
}
