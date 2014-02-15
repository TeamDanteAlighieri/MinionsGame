using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecondAttempt
{
    class Basooka : Gun
    {
        private const int ATTACKPowerAdder = 30;

        public Basooka(int attackPower, int speed, int attackPowerAdder)
            : base(attackPower,speed)
        { base.AttackPower+= ATTACKPowerAdder; }
    }
}
