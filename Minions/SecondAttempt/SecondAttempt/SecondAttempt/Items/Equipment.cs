﻿namespace SecondAttempt
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Equipment : Item, IEquipable, IComparable<Equipment>, ICloneable
    {

        public Equipment() 
            : base() 
        { 

        }

        public virtual void Equip(Minion target)
        {          
            //Apply effects
            ApplyTo(target);
            
            //Reset max mana and health if they overflowed.
            if (target.CurrentMana > target.MaxMana) target.CurrentMana = target.MaxMana;
            if (target.CurrentHealth > target.MaxHealth) target.CurrentHealth = target.MaxHealth;
        }

        public int CompareTo(Equipment equipment)
        {
            return this.Name.CompareTo(equipment.Name);
        }


        public void Unequip(Minion target)
        {
            //Apply effects
            SubstractFrom(target);

            //Reset max mana and health if they overflowed.
            if (target.CurrentMana > target.MaxMana) target.CurrentMana = target.MaxMana;
            if (target.CurrentHealth > target.MaxHealth) target.CurrentHealth = target.MaxHealth;
        }
            
        public virtual object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
