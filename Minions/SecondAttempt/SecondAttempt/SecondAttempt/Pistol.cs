using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecondAttempt
{
    class Pistol : Gun
    {
        private const int addSpeed = 30;


        public Pistol(int attackPower, int speed)
            : base(attackPower, speed)
        {
            base.Speed += addSpeed;
        }


    }
}
