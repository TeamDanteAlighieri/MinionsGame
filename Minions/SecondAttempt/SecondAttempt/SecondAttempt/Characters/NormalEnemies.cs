namespace SecondAttempt
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    public class NormalEnemies
    {        
        [XmlElement("RegularEnemy")]
        public List<Enemy> Collection { get; set; }
    }
}
