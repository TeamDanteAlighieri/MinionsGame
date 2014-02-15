using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecondAttempt
{
    public class Fruit
    {
        private FruitType fruitType;
        private int mana;

        public Fruit(FruitType fruitType)
        {
            this.fruitType = fruitType;
            this.mana += (int)fruitType;
        }

        public FruitType FruitType
        {
            get { return this.fruitType; }
            private set { this.fruitType = value; }
        }
    }
}
