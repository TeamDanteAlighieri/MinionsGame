using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecondAttempt
{
    public class Vegetable
    {
        private VegetableType vegetableType;
        private int hp ;

         public Vegetable(VegetableType vegetableType)
        {
            this.vegetableType = vegetableType;
            this.hp += (int)vegetableType;
        }

        public VegetableType VegetableType
        {
            get { return this.vegetableType; }
            private set { this.vegetableType = value; }
        }

    }
}
