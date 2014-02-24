using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SecondAttempt
{
    [Serializable()]
    public class SaveGameContent : Player
    {
        //private XmlManager<Minion> minionSaver;
        //private Minion currentInstanceOfTheCharacter;
        
        //[XmlIgnore]
        private Player playerToSave;

        public SaveGameContent()
        { }

        public SaveGameContent( Player playerToSave)
        {
            //this.currentInstanceOfTheCharacter = currentInstanceOfTheCharacter;
            this.PlayerToSave = playerToSave;
            //this.playerSaver = new XmlManager<Player>();
            //this.minionSaver = new XmlManager<Minion>();
        }
        public Player PlayerToSave
        {
            get { return this.playerToSave; }
            set { this.playerToSave = value; }
        }       

        public void Save()
        {
            /*List<float> coordinates = new List<float>
            {
                playerToSave.Image.Position.X,
                playerToSave.Image.Position.Y
            };*/
            // Create a new XmlSerializer instance with the type of the test class
            XmlSerializer SerializerObj = new XmlSerializer(typeof(Player));

            // Create a new file stream to write the serialized object to a file
            TextWriter WriteFileStream = new StreamWriter("Load/Gameplay/SavedGames/Player2.xml");
            SerializerObj.Serialize(WriteFileStream, this.playerToSave);

            // Cleanup
            WriteFileStream.Close();
        }
        public Player Load()
        {
            Player playerToBeLoaded = new Player();
            XmlManager<Player> playerLoader = new XmlManager<Player>();
            playerToBeLoaded = playerLoader.Load("Load/Gameplay/SavedGames/Player4.xml");
            //playerToBeLoaded.Image = playerToSave.Image;
            return playerToBeLoaded;
        }
        
    }
}
