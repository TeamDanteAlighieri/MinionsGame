﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SecondAttempt
{
    public class NormalEnemies
    {        
        [XmlElement("RegularEnemy")]
        public List<Enemy> Collection { get; set; }
    }
}
