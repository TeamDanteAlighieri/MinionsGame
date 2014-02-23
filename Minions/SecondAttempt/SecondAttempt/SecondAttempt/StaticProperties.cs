using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml.Serialization;
using Microsoft.Xna.Framework;

namespace SecondAttempt
{
    class StaticProperties
    {
        public static Random Random = new Random();
        public static readonly Vector2 EnemyPosition1 = new Vector2(120f, 120f);
        public static readonly Vector2 EnemyPosition2 = new Vector2(160f, 220f);
        public static readonly Vector2 EnemyPosition3 = new Vector2(120f, 320f);
        public static readonly Vector2 PlayerPosition1 = new Vector2(480f, 220f);
        //public static List<Item>();
        /*
        [XmlElement("Item")]        
        public static List<Enemy> RegularEnemies;*/

    }
}
