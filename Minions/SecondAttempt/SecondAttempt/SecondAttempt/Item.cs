using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecondAttempt
{
   public abstract class Item : IStats
    {
       //TODO: Methodfor show in the menu. 
       public int Quantity { get; set; }       
       public int AttackPower { get; set; }
       public int Accuracy { get; set; }
       public int Defence { get; set; }
       public int Speed { get; set; }
       public int MaxHealth { get; set; }
       public int CurrentHealth { get; set; }
       public int MaxMana { get; set; }
       public int CurrentMana { get; set; }
    }
}
