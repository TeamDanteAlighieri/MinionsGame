namespace SecondAttempt
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Weapon : Equipment, ICloneable
    {
        public Weapon()
            : base()
        {

        }

        /// <summary>
        /// Returns a MemberwiseClone of the weapon object.
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
