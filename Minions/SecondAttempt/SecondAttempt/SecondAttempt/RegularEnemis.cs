using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SecondAttempt
{
    public class RegularEnemis
    {
        private List<Enemy> regularEnemies;

        [XmlIgnore]
        public ReadOnlyCollection<Enemy> RegularEnemies
        {
            get { return this.regularEnemies.AsReadOnly(); }
        }

        [XmlElement("Enemy")]
        public List<Enemy> RegularEnemiesSetter
        {
            get { return this.regularEnemies; }
            set { this.regularEnemies = value; }
        }
        //Readonly as we are not supposed to delete from the class once we load all available enemy types.
    }
}
