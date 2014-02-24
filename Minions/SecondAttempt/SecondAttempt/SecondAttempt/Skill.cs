using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecondAttempt
{
    class Skill : IStats
    {
        //Skill specific properties
        public string Name { get; set; }
        public string Description { get; set; }
        public int ManaCost { get; set; }

        //IStats properties
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
