using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minions
{
	public class Minion : Character
	{
		private int experience;
		private int money;
		private int mana;

		/*public Minion(string name, int attackPower, int speed, int blood, Location location, int experience, int money, int mana)
			: base(name, attackPower, speed, blood, location)
		{
			this.Experience = experience;
			this.Money = money;
			this.Mana = mana;
		}*/

		public int Experience
		{
			get
			{
				return this.experience;
			}
			set
			{
				this.experience = value;
			}
		}
		public int Money
		{
			get
			{
				return this.money;
			}
			set
			{
				this.money = value;
			}
		}
		public int Mana
		{
			get
			{
				return this.mana;
			}
			set
			{
				this.mana = value;
			}
		}
	}
}
