using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecondAttempt
{
    public class Gun : Item
    {
        private int attackPower;
        private int speed;

        public Gun(int attackPower, int speed)
        {
            this.AttackPower = attackPower;
            this.Speed = speed;
        }

        public int AttackPower
        {
            get { return this.attackPower; }
            protected set { this.attackPower = value; }
        }

        public int Speed
        {
            get { return this.speed; }
            protected set { this.speed = value; }
        }

    }
}
