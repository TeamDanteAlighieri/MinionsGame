using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SecondAttempt
{
    [Serializable()]
    public class SaveGameContent
    {
        //private XmlManager<Minion> minionSaver;
        //private Minion currentInstanceOfTheCharacter;
        [XmlElement("Player")]
        private Player playerToSave;
        
        public SaveGameContent()
        { }

        public SaveGameContent( Player playerToSave)
        {
            //this.currentInstanceOfTheCharacter = currentInstanceOfTheCharacter;
            this.playerToSave = playerToSave;
            //this.playerSaver = new XmlManager<Player>();
            //this.minionSaver = new XmlManager<Minion>();
        }

        public void Save(object TestObj)
        {

            // Create a new XmlSerializer instance with the type of the test class
            XmlSerializer SerializerObj = new XmlSerializer(typeof(SaveGameContent));

            // Create a new file stream to write the serialized object to a file
            TextWriter WriteFileStream = new StreamWriter("Load/Gameplay/SavedGames/Player2.xml");
            SerializerObj.Serialize(WriteFileStream, TestObj);

            // Cleanup
            WriteFileStream.Close();
        }


        /*public void Save()
        {
            XmlManager<Player> playerSaver = new XmlManager<Player>();
            playerSaver.Save("Load/Gameplay/SavedGames/positionsSaved.xml", playerToSave);
            //minionSaver.Save("Load/Gameplay/SavedGames/minionSaved.xml", minionSaver);
        }*/
        /*public void Load()
        {
        }*/
        
    }
}
