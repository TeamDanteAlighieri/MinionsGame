using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecondAttempt
{
    public class Equipment : Item, IEquipable
    {
        public bool IsEquiped;


        public void Equip(Character target)
        {
            if (!IsEquiped)
            {
                
            }
        }
    }
}
