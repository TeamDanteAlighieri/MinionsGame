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
	public abstract class Character
	{
		private string name;
		private int attackPower;
		private int speed;
		private int blood;

        public Character()
        {
            this.Name = string.Empty;
            this.attackPower = 0;
            this.speed = 0;
            this.blood = 0;
        }

        //public List<Skill> Skills { get; set; }
		//private Vector2 location;

		/*public Character(string name, int attackPower, int speed, int blood, Location location)
		{
			this.Name = name;
			this.AttackPower = attackPower;
			this.Speed = speed;
			this.Blood = blood;
			this.Location = location;
		}*/

		public string Name
		{
			get
			{
				return this.name;
			}
			set
			{
				this.name = value;
			}
		}

		public int AttackPower
		{
			get
			{
				return this.attackPower;
			}
			set
			{
				this.attackPower = value;
			}
		}
		public int Speed
		{
			get
			{
				return this.speed;
			}
			set
			{
				this.speed = value;
			}
		}
		public int Blood
		{
			get
			{
				return this.blood;
			}
			set
			{
				this.blood = value;
			}
		}

		/*public Location Location
		{
			get
			{
				return this.location;
			}
			set
			{
				this.location = value;
			}
		}*/
	}
}
