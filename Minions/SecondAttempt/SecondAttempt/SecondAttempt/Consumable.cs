using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecondAttempt
{
    public enum EffectType { Instant, Timed};

    public class Consumable : Item, IUsable
    {
        public EffectType EffectType;
        public int Duration;

        public void UseItem(Character target)
        {
            if (this.EffectType == EffectType.Instant)
            {
                //Apply effects
                target.Accuracy += this.Accuracy;
                target.AttackPower += this.AttackPower;
                target.CurrentHealth += this.CurrentHealth;                
                target.CurrentMana += this.CurrentMana;
                target.Defence += this.Defence;
                target.MaxHealth += this.MaxHealth;
                target.MaxMana += this.MaxMana;
                target.Speed += this.Speed;

                //Reset max mana and health if they overflowed.
                if (target.CurrentMana > target.MaxMana) target.CurrentMana = target.MaxMana;
                if (target.CurrentHealth > target.MaxHealth) target.CurrentHealth = target.MaxHealth;

                Quantity--;
            }
            else if (this.EffectType == EffectType.Timed)
            {
                //Timed logic goes here.
            }
        }
    }
}
