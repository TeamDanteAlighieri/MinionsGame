namespace SecondAttempt
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

	public class Minion : Character 
	{
        public byte Level;
        public Item[] Items;
        public bool UsedDefend;
        public bool IsActive;
        public bool IsAlive;
        private InternalText HPText;
		
        public Minion() : base()
        {            
            Items = new Item[16];
            ActionTimeCurrent = 0;
            UsedDefend = false;
            IsActive = false;
            IsAlive = true;
            HPText = new InternalText();
        }

        public override void LoadContent() 
        {
            base.LoadContent();
            HPText.Text = string.Format("{0}/{1}", CurrentHealth, MaxHealth);
            HPText.Position = SpriteImage.Position;
            HPText.TextColor = Color.White;
            SpriteImage.LoadContent();
        }

        public override void UnloadContent() 
        {            
            SpriteImage.UnloadContent();
            HPText.UnloadContent();
        }

        public override void Update(GameTime gameTime) 
        {
            base.Update(gameTime);
            UsedDefend = false;

            HPText.Text = string.Format("{0}/{1}", CurrentHealth, MaxHealth);
            HPText.Position = SpriteImage.Position + new Vector2(-30, 15);

            SpriteImage.Update(gameTime);            
            if (this.CurrentHealth <= 0)
            {
                CurrentHealth = 0;
                IsAlive = false;
            }
        }        

        public override void Draw(SpriteBatch spriteBatch) 
        {
            base.Draw(spriteBatch);
            HPText.Draw(spriteBatch);
            SpriteImage.Draw(spriteBatch);
        }
	}
}
