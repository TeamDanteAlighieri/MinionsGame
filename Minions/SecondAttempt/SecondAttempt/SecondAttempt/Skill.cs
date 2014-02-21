using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecondAttempt
{
    class Skill
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public uint Duration { get; protected set; }
        public uint Power { get; protected set; }

        public Skill(string name, string description, uint duration, uint power)
        {
            this.Name = name;
            this.Description = description;
            this.Duration = duration;
            this.Power = power;
        }        
    }
}
