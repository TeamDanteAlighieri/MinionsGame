using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
namespace SecondAttempt
{
	public class Minion : Character 
	{
        public byte Level;
        public Item[] Items;        
		
        public Minion()
        {
            Items = new Item[16];
            ActionTimer = 0;
        }

        public void LoadContent() 
        {
            SpriteImage.LoadContent();
        }

        public void UnloadContent() 
        {
            SpriteImage.UnloadContent();
        }

        public void Update(GameTime gameTime) 
        {
            SpriteImage.Update(gameTime);
            if (this.CurrentHealth <= 0)
            {
                CurrentHealth = 0;
                ScreenManager.Instance.ChangeScreens("TitleScreen");
            }
        }        

        public void Draw(SpriteBatch spriteBatch) 
        {
            SpriteImage.Draw(spriteBatch);
        }
	}
}
