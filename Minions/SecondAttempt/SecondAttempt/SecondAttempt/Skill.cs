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
        public int Duration { get; protected set; }
        public int Power { get; protected set; }
        public int Accuracy { get; protected set; }
    }
}
