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
		
        public Minion()
        {
            Items = new Item[16];
            ActionTimeCurrent = 0;
            UsedDefend = false;
            IsActive = false;
            IsAlive = true;
        }

        public override void LoadContent() 
        {
            base.LoadContent();
            SpriteImage.LoadContent();
        }

        public void UnloadContent() 
        {
            SpriteImage.UnloadContent();
        }

        public override void Update(GameTime gameTime) 
        {
            base.Update(gameTime);
            SpriteImage.Update(gameTime);
            if (this.CurrentHealth <= 0)
            {
                CurrentHealth = 0;
                IsAlive = false;
            }
        }        

        public override void Draw(SpriteBatch spriteBatch) 
        {
            SpriteImage.Draw(spriteBatch);
        }
	}
}
