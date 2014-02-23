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
        //public List<Item> items;        

		/*public Minion(string name, int attackPower, int speed, int blood, Location location, int experience, int money, int mana)
			: base(name, attackPower, speed, blood, location)
		{
			this.Experience = experience;
			this.Money = money;
			this.Mana = mana;
		}*/

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
        }        

        public void Draw(SpriteBatch spriteBatch) 
        {
            SpriteImage.Draw(spriteBatch);
        }
	}
}
