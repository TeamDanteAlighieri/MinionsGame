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
		public int Money;
		public int Mana;
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
            //content = new ContentManager(ScreenManager.Instance.Content.ServiceProvider, "Content");


        }

        public void UnloadContent() { }

        public void Update(GameTime gameTime) { }        

        public void Draw(SpriteBatch spriteBatch) { }
	}
}
