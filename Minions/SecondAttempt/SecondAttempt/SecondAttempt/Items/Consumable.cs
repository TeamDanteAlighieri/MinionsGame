namespace SecondAttempt
{
    using System;
   
    public enum EffectType { Instant, Timed};

    public class Consumable : Item, IUsable, ICloneable
    {
        public EffectType EffectType;
        public int Duration;

        public Consumable() : base()
        {
            this.Duration = 0;
            this.EffectType = EffectType.Instant;            
        }

        public virtual void UseItem(Character target)
        {
            if (this.EffectType == EffectType.Instant)
            {
                //Apply effects
                ApplyTo(target);                

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

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
