namespace SecondAttempt
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class ListBox
    {
        public FrameBox Frame;
        public List<ListDescriptorItem> Items;
        public bool IsVisible;

        private int activeElement;        

        public ListBox()
        {
            this.Frame = new FrameBox(StaticConstants.BordeWidth, StaticConstants.ListBoxDimensions, Color.DarkBlue);           
            this.IsVisible = false;
            this.activeElement = 0;
        }

        public ListBox(List<Item> content) : this()
        {
            for (int i = 0; i < content.Count; i++)
            {
                ListDescriptorItem toAdd = new ListDescriptorItem();
                toAdd.Name.Text = content[i].Name;                
                toAdd.Number.Text = content[i].Quantity.ToString();
                if (i != 0)
                {
                    toAdd.Name.Position = Items[i - 1].Name.Position + new Vector2(0, Items[i - 1].Name.StringSize().Y + 5);
                }
            }            
        }

        public virtual void LoadContent()
        {

        }
    }
}
