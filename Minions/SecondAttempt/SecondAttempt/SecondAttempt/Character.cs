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

	public abstract class Character
	{
		public string Name;
		public int AttackPower;
		public int Speed;
		public int Health;
        public long Experience;
        [XmlElement("Skill")]
        //public List<Skill> Skills;        
        public Image SpriteImage;
	}
}
