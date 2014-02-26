namespace SecondAttempt
{
    using System.Collections.Generic;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// Creates a vertical list to facilitate item and skill selection (once skill selection is implemented).
    /// </summary>
    public class ListBox
    {
        public FrameBox Frame;
        public List<ListDescriptorItem> Items;
        public bool IsVisible;

        private int activeElement;        

        public ListBox()
        {
            this.Frame = new FrameBox(Constants.BordeWidth, Constants.ListBoxDimensions, Color.DarkBlue);           
            this.IsVisible = false;
            this.activeElement = 0;
        }

        //Considered making the class generic to save on constructor duplication but that cause problems with the actual usage so left it as it is.
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
                    toAdd.Number.Position = new Vector2(Constants.ListBoxRight - toAdd.Number.StringSize().X - 5,
                        Items[i - 1].Number.StringSize().Y + 5 + Items[i - 1].Number.Position.Y);
                }

                else
                {
                    toAdd.Name.Position = new Vector2(Constants.ListBoxLeft + 5, Constants.ListBoxTop + 5);
                    toAdd.Number.Position = new Vector2(Constants.ListBoxRight - 5 - Items[0].Number.StringSize().X, Constants.ListBoxTop + 5);
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
                    toAdd.Number.Position = new Vector2(Constants.ListBoxRight - toAdd.Number.StringSize().X - 5,
                        Items[i - 1].Number.StringSize().Y + 5 + Items[i - 1].Number.Position.Y);
                }

                else
                {
                    toAdd.Name.Position = new Vector2(Constants.ListBoxLeft + 5, Constants.ListBoxTop + 5);
                    toAdd.Number.Position = new Vector2(Constants.ListBoxRight - 5 - toAdd.Number.StringSize().X, Constants.ListBoxTop + 5);
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
                    toAdd.Number.Position = new Vector2(Constants.ListBoxRight - toAdd.Number.StringSize().X - 5,
                        Items[i - 1].Number.StringSize().Y + 5 + Items[i - 1].Number.Position.Y);
                }

                else
                {
                    toAdd.Name.Position = new Vector2(Constants.ListBoxLeft + 5, Constants.ListBoxTop + 5);
                    toAdd.Number.Position = new Vector2(Constants.ListBoxRight - 5 - toAdd.Number.StringSize().X, Constants.ListBoxTop + 5);
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
