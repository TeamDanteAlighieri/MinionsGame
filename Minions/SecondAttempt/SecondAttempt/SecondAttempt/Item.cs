using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecondAttempt
{
   public abstract class Item : IStats
    {
       //TODO: Methodfor show in the menu. 
       public string Name { get; set; }
       public string Description { get; set; }
       public int Price { get; set; }
       public int Quantity { get; set; }       
       public int AttackPower { get; set; }
       public int Accuracy { get; set; }
       public int Defence { get; set; }
       public int Speed { get; set; }
       public int MaxHealth { get; set; }
       public int CurrentHealth { get; set; }
       public int MaxMana { get; set; }
       public int CurrentMana { get; set; }

       public Item()
       {
           this.Name = string.Empty;
           this.Description = string.Empty;
           this.Price = 0;
           this.Quantity = 0;

           this.AttackPower = 0;
           this.Accuracy = 0;
           this.Defence = 0;
           this.Speed = 0;
           this.MaxHealth = 0;
           this.CurrentHealth = 0;
           this.MaxMana = 0;
           this.CurrentMana = 0;
       }

       public virtual void ApplyTo(Character target)
       {
           target.AttackPower += this.AttackPower;
           target.AttackPower += this.Accuracy;
           target.AttackPower += this.Defence;
           target.AttackPower += this.Speed;
           target.AttackPower += this.MaxHealth;
           target.AttackPower += this.CurrentHealth;
           target.AttackPower += this.MaxMana;
           target.AttackPower += this.CurrentMana;
       }

       public virtual void SubstractFrom(Character target)
       {
           target.AttackPower += this.AttackPower;
           target.AttackPower += this.Accuracy;
           target.AttackPower += this.Defence;
           target.AttackPower += this.Speed;
           target.AttackPower += this.MaxHealth;
           target.AttackPower += this.CurrentHealth;
           target.AttackPower += this.MaxMana;
           target.AttackPower += this.CurrentMana;
       }
    }
}
