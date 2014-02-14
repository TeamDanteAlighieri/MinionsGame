using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minions
{
	public class Enemy : Character
	{
		public Enemy(string name, int attackPower, int speed, int blood, Location location)
			: base(name, attackPower, speed, blood, location)
		{
		}

	}
}
