namespace SecondAttempt
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

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
            this.Items = new List<ListDescriptorItem>(content.Capacity);
            for (int i = 0; i < content.Count; i++)
            {
                ListDescriptorItem toAdd = new ListDescriptorItem();
                toAdd.Name.Text = content[i].Name;                
                toAdd.Number.Text = content[i].Quantity.ToString();

                if (i != 0)
                {                    
                    toAdd.Name.Position = Items[i - 1].Name.Position + new Vector2(0, Items[i - 1].Name.StringSize().Y + 5);
                    toAdd.Number.Position = new Vector2(StaticConstants.ListBoxRight - Items[i - 1].Number.StringSize().X - 5,
                        Items[i - 1].Number.StringSize().Y + 5 + Items[i - 1].Number.Position.Y);
                }

                else
                {
                    toAdd.Name.Position = new Vector2(StaticConstants.ListBoxLeft + 5, StaticConstants.ListBoxTop + 5);
                    toAdd.Number.Position = new Vector2(StaticConstants.ListBoxRight - 5 - Items[0].Number.StringSize().X, StaticConstants.ListBoxTop + 5);
                }

                Items.Add(toAdd);
            }            
        }

        public ListBox(List<Consumable> content)
            : this()
        {
            this.Items = new List<ListDescriptorItem>(content.Capacity);
            for (int i = 0; i < content.Count; i++)
            {
                ListDescriptorItem toAdd = new ListDescriptorItem();
                toAdd.Name.Text = content[i].Name;
                toAdd.Number.Text = content[i].Quantity.ToString();

                if (i != 0)
                {
                    toAdd.Name.Position = Items[i - 1].Name.Position + new Vector2(0, Items[i - 1].Name.StringSize().Y + 5);
                    toAdd.Number.Position = new Vector2(StaticConstants.ListBoxRight - Items[i - 1].Number.StringSize().X - 5,
                        Items[i - 1].Number.StringSize().Y + 5 + Items[i - 1].Number.Position.Y);
                }

                else
                {
                    toAdd.Name.Position = new Vector2(StaticConstants.ListBoxLeft + 5, StaticConstants.ListBoxTop + 5);
                    toAdd.Number.Position = new Vector2(StaticConstants.ListBoxRight - 5 - toAdd.Number.StringSize().X, StaticConstants.ListBoxTop + 5);
                }

                Items.Add(toAdd);
            }
        }

        public ListBox(List<Equipment> content)
            : this()
        {
            this.Items = new List<ListDescriptorItem>(content.Capacity);
            for (int i = 0; i < content.Count; i++)
            {
                ListDescriptorItem toAdd = new ListDescriptorItem();
                toAdd.Name.Text = content[i].Name;
                toAdd.Number.Text = content[i].Quantity.ToString();

                if (i != 0)
                {
                    toAdd.Name.Position = Items[i - 1].Name.Position + new Vector2(0, Items[i - 1].Name.StringSize().Y + 5);
                    toAdd.Number.Position = new Vector2(StaticConstants.ListBoxRight - Items[i - 1].Number.StringSize().X - 5,
                        Items[i - 1].Number.StringSize().Y + 5 + Items[i - 1].Number.Position.Y);
                }

                else
                {
                    toAdd.Name.Position = new Vector2(StaticConstants.ListBoxLeft + 5, StaticConstants.ListBoxTop + 5);
                    toAdd.Number.Position = new Vector2(StaticConstants.ListBoxRight - 5 - toAdd.Number.StringSize().X, StaticConstants.ListBoxTop + 5);
                }

                Items.Add(toAdd);
            }
        }

        public string CheckSelection()
        {
            if (InputManager.Instance.ActionKeyPressed() && this.Items.Count > 0)
            {
                return Items[activeElement].Name.Text;
            }
            return string.Empty;
        }        

        public virtual void UnloadContent()
        {
            foreach (var item in Items)
            {
                item.UnloadContent();
            }
        }

        public virtual void Update(GameTime gameTime)
        {
            if (IsVisible)
            {
                if (this.Items.Count > 0)
                {
                    Items[activeElement].IsActive = false;
                    if (InputManager.Instance.KeyPressed(Keys.Up) && --activeElement < 0)
                        activeElement = Items.Count - 1;
                    if (InputManager.Instance.KeyPressed(Keys.Down) && ++activeElement >= Items.Count)
                        activeElement = 0;
                    Items[activeElement].IsActive = true;

                    foreach (var item in Items)
                    {
                        item.Update(gameTime);
                    }
                }
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (IsVisible)
            {
                Frame.Draw(spriteBatch);
                foreach (var item in Items)
                {
                    item.Draw(spriteBatch);
                }
            }
        }
    }
}
