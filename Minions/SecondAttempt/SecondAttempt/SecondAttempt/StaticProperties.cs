using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml.Serialization;
using Microsoft.Xna.Framework;

namespace SecondAttempt
{
    public class StaticProperties
    {
        [XmlIgnore]
        public static Random Random = new Random();
        [XmlIgnore]
        public static readonly Vector2[] EnemyPositions = new Vector2[] { new Vector2(120f, 120f), new Vector2(160f, 220f), new Vector2(120f, 320f) };
        [XmlIgnore]
        public static readonly Vector2 PlayerPosition1 = new Vector2(480f, 220f);
        [XmlIgnore]
        public const float maxActionTimer = 25.0f;
        //public static List<Item>();
        /*
        [XmlElement("Item")]        
        public static List<Enemy> RegularEnemies;*/

    }
}
