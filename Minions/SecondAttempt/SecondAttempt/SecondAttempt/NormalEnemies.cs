using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SecondAttempt
{
    public class NormalEnemies
    {
        private List<Enemy> regularEnemies;

        [XmlElement("RegularEnemy")]
        public List<Enemy> Collection { get; set; }
        //Readonly as we are not supposed to delete from the class once we load all available enemy types.
    }
}
