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
            this.Frame = new FrameBox();           
            this.IsVisible = false;
            this.activeElement = 0;
        }

        public ListBox(List<Item> content) : this()
        {            
            foreach (var item in content)
            {
                ListDescriptorItem toAdd = new ListDescriptorItem();
                toAdd.Name.Text = item.Name;
                toAdd.Number.Text = item.Quantity.ToString();
            }
        }

        public virtual void LoadContent()
        {

        }
    }
}
