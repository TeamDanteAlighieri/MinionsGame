namespace SecondAttempt
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    public class TileMap
    {
        [XmlElement("Row")]
        public List<string> Row;

        public TileMap()
        {
            Row = new List<string>();
        }
    }
}
