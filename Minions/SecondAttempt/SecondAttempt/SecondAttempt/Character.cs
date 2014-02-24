namespace SecondAttempt
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using System.Xml.Serialization;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

	public abstract class Character : IStats
	{
		public string Name;
        public int AttackPower { get; set; }
        public int Accuracy { get; set; }
        public int Defence { get; set; }
        public int Speed { get; set; }
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public int MaxMana { get; set; }
        public int CurrentMana { get; set; }
        public long Experience { get; set; }
        //[XmlElement("Skill")]
        //public List<Skill> Skills;        
        public Image SpriteImage {get; set;}
        public int Money { get; set; }
        public float ActionTimer { get; set; }


	}
}
