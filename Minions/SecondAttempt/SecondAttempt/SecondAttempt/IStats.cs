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

       /* public virtual void AddStats(IStats first, IStats second)
        {
            first.Accuracy += second.Accuracy;
            first.AttackPower += second.AttackPower;
            first.Defence += second.Defence;
            first.Speed += second.Speed;
            first.MaxHealth += second.MaxHealth;
            first.CurrentHealth += second.CurrentHealth;
            first.MaxMana += second.MaxMana;
            first.CurrentMana += second.CurrentMana;

            if (first.CurrentHealth > first.MaxHealth) first.CurrentHealth = first.MaxHealth;
            if (first.CurrentMana > first.MaxMana) first.CurrentMana = first.MaxMana;
        }*/
    }
}
