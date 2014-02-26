namespace SecondAttempt
{
    using System;
    
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Creates a whole word selectable text object. Selection logic should be rerouted through the Selected event.
    /// </summary>
    public class CommandBoxItem : FloatingText
    {
        public bool IsActive { get; set; }        

        public CommandBoxItem()
            : base()
        {
            this.IsActive = false;
        }

        public CommandBoxItem(string text, Vector2 position, Color textColor)
        {
            this.Text = text;
            this.Position = position;
            this.TextColor = textColor;
            this.IsActive = false;
        }

        public event EventHandler<EventArgs> Selected;
        protected internal virtual void OnSelectEntry()
        {
            if (Selected != null)
                Selected(this, new EventArgs());
        }

        public override void Update(GameTime gameTime)
        {
            if (IsActive) this.TextColor = Color.White;
            else this.TextColor = Color.Gray;
        }        
    }
}
