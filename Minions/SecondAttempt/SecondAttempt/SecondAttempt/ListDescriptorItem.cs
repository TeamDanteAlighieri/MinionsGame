namespace SecondAttempt
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Microsoft.Xna.Framework;

    class ListDescriptorItem
    {
        public InternalText Name;
        public InternalText Number;
        public bool IsActive { get; set; }

        public ListDescriptorItem()
        {
            this.Name = new InternalText();
            this.Number = new InternalText();
        }

        public ListDescriptorItem(string name, string number, Vector2 namePosition, Vector2 numberPosition) : this()
        {
            this.Name.Text = name;
            this.Name.Position = namePosition;
            this.Name.TextColor = Color.Gray;

            this.Number.Text = number;
            this.Number.Position = namePosition;
            this.Number.TextColor = Color.Gray;

            this.IsActive = false;
        }
    }
}
