namespace SecondAttempt
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using System.Xml.Serialization;

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

        public void DeleteItem(string itemName)                    
        {
            int itemIndex = -1;
            if ((itemIndex = Equipment.FindIndex(x => x.Name == itemName)) >= 0)
            {
                Equipment[itemIndex].Quantity--;
                if (Equipment[itemIndex].Quantity <= 0) Equipment.RemoveAt(itemIndex);
            }
            else if ((itemIndex = Consumables.FindIndex(x => x.Name == itemName)) >= 0)
            {
                Consumables[itemIndex].Quantity--;
                if (Consumables[itemIndex].Quantity <= 0) Consumables.RemoveAt(itemIndex);
            }
            else throw new NoSuchItemException(string.Format("Cannot remove item {0}, it is not part of the inventory.", itemName));        
        }
    }
}
