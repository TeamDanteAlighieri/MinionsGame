namespace SecondAttempt
{
    using System;
 
    /// <summary>
    /// Dummy class.
    /// </summary>
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
