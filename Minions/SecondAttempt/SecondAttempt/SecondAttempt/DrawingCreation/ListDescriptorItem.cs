namespace SecondAttempt
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Holds a two FloatingText objects that are simultaneously selectable.    
    /// </summary>
    public class ListDescriptorItem
    {
        public FloatingText Name;
        public FloatingText Number;
        public bool IsActive { get; set; }

        public ListDescriptorItem()
        {
            this.Name = new FloatingText();
            this.Number = new FloatingText();
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
