using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecondAttempt
{
    interface IStats
    {
        int AttackPower { get; set; }
        int Accuracy { get; set; }
        int Defence { get; set; }
        int Speed { get; set; }
        int MaxHealth { get; set; }
        int CurrentHealth { get; set; }
        int MaxMana { get; set; }
        int CurrentMana { get; set; }
    }
}
