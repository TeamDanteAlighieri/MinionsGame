using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecondAttempt
{
    public interface IEquipable
    {
        void Equip(Minion target);

        void Unequip(Minion target);
    }
}
