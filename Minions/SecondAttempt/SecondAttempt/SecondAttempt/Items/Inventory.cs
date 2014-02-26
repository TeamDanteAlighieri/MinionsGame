namespace SecondAttempt
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using System.Xml.Serialization;

    /// <summary>
    /// Holds a list of equipment and consumable type objects. Can be used by minion(player) class to store their available items as well as the shopkeeper class to store his available wares.
    /// </summary>
    public class Inventory
    {
        [XmlElement("Equip")]
        public List<Equipment> Equipment;
        [XmlElement("Usable")]
        public List<Consumable> Consumables;

        public Inventory()
        {
            this.Equipment = new List<Equipment>();
            this.Consumables = new List<Consumable>();
        }

        public void AddItem(Item item)
        {
            if (item is Equipment)
            {
                int index = Equipment.FindIndex(x => x.Name == item.Name);
                if (index != -1) Equipment[index].Quantity += item.Quantity;
                else Equipment.Add((Equipment)item);
            }
            else if (item is Consumable)
            {
                int index = Consumables.FindIndex(x => x.Name == item.Name);
                if (index != -1) Consumables[index].Quantity += item.Quantity;
                else Consumables.Add((Consumable)item);
            }
        }

        public void DeleteItem(Item item)
        {
            int itemIndex = -1;
            if (item is Equipment)
            {
                itemIndex = Equipment.FindIndex(x => x.Name == item.Name);
                if (itemIndex >= 0)
                { 
                    Equipment[itemIndex].Quantity -= item.Quantity;
                    if (Equipment[itemIndex].Quantity <= 0)  Equipment.Remove((Equipment) item);
                }
                else throw new NoSuchItemException("Cannot remove item, it is not part of the inventory.", item);
            }
            else if (item is Consumable)
            {
                itemIndex = Consumables.FindIndex(x => x.Name == item.Name);
                if (itemIndex >= 0)
                { 
                    Consumables[itemIndex].Quantity -= item.Quantity;
                    if (Consumables[itemIndex].Quantity <= 0)  Consumables.Remove((Consumable) item);
                }
                else throw new NoSuchItemException("Cannot remove item, it is not part of the inventory.", item);
            }
        }

        public void AddItem(string itemName)
        {
            int itemIndex = -1;
            if ((itemIndex = Equipment.FindIndex(x => x.Name == itemName)) >= 0)
                Equipment[itemIndex].Quantity++;
            else if ((itemIndex = Consumables.FindIndex(x => x.Name == itemName)) >= 0)
                Consumables[itemIndex].Quantity++;
            else throw new NoSuchItemException(string.Format("Cannot add item {0}, it is not part of the inventory.", itemName));
        }

        /// <summary>
        /// Searches the inventory for an instance with property name == itemName.
        /// </summary>
        /// <param name="itemName"></param>
        /// <returns></returns>
        public Item GetItem(string itemName)                    
        {            
            int itemIndex = -1;
            Item result = null;
            if ((itemIndex = Equipment.FindIndex(x => x.Name == itemName)) >= 0)
            {                
                result = Equipment[itemIndex];                
                if (Equipment[itemIndex].Quantity <= 0) Equipment.RemoveAt(itemIndex);                
            }
            else if ((itemIndex = Consumables.FindIndex(x => x.Name == itemName)) >= 0)
            {                
                result = Consumables[itemIndex];
                if (Consumables[itemIndex].Quantity <= 0) Consumables.RemoveAt(itemIndex);
            }
            else throw new NoSuchItemException(string.Format("Cannot remove item {0}, it is not part of the inventory.", itemName));
            return result;
        }

        /// <summary>
        /// Checks if any inventory item has negative or zero quantity. If that is the case, deletes the item from the inventory.
        /// </summary>
        public void CheckConsistency()
        {
            Item checker = null;
            while ((checker = Equipment.Find(x => x.Quantity <= 0)) != null) Equipment.Remove((Equipment)checker);
            while ((checker = Consumables.Find(x => x.Quantity <= 0)) != null) Consumables.Remove((Consumable)checker);
        }
    }
}
