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
	public class Enemy : Character
	{
        public Enemy() : base() { }

		/*public Enemy(string name, int attackPower, int speed, int blood, Location location)
			: base(name, attackPower, speed, blood, location)
		{
		}*/

        public void UnloadContent() {}

        public void Update(GameTime gameTime) { }

        public void Draw(SpriteBatch spriteBatch) { }
	}
}
