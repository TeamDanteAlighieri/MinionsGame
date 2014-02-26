namespace SecondAttempt
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Microsoft.Xna.Framework;

    /// <summary>
    /// Ingame menu box - allows the user to use and equip items, save the game(not yet implemented) and exit to title screen.
    /// </summary>
    public class IngameMenuCommands : CommandsBox
    {
        private Minion minion;
        private IngameMenuScreen screen;
        public bool IsActive;

        public IngameMenuCommands(IngameMenuScreen screen, Minion minion)
            : base('x')
        {
            this.minion = minion;
            this.screen = screen;
            this.Frame = new FrameBox(Constants.BordeWidth, Constants.IngameMenuDimensions, Color.Blue);
            this.Items = new CommandBoxItem[4] 
            { 
                new CommandBoxItem("Use",
                    new Vector2(Constants.IngameMenuDimensions.Left + 10, Constants.IngameMenuDimensions.Top + 5), 
                    Color.Gray),
                new CommandBoxItem("Equip",
                    new Vector2(Constants.IngameMenuDimensions.Left + 15, Constants.IngameMenuDimensions.Top + 5 + 25), 
                    Color.Gray),
                new CommandBoxItem("Save",
                    new Vector2(Constants.IngameMenuDimensions.Left + 15, Constants.IngameMenuDimensions.Top + 5 + 50), 
                    Color.Gray),
                new CommandBoxItem("Exit",
                    new Vector2(Constants.IngameMenuDimensions.Left + 15, Constants.IngameMenuDimensions.Top + 5 + 75), 
                    Color.Gray)
            };
            for (int i = 1; i < Items.Length; i++)
            {
                Items[i].Position = Items[i-1].Position + new Vector2(Items[i-1].StringSize().X + 10, 0);
            }

            this.Items[0].Selected += UseCommandSelected;
            this.Items[1].Selected += EquipCommandSelected;
            this.Items[2].Selected += SaveCommandSelected;
            this.Items[3].Selected += ExitCommandSelected;

            IsActive = true;
            IsVisible = true;
        }

        protected void UseCommandSelected(object sender, EventArgs e)
        {
            screen.SelectionBox = new ListBox(minion.Inventory.Consumables);
            screen.SelectionBox.IsVisible = true;
            IsActive = false;
            screen.Delay = true;
            screen.Caller = "Use";
        }

        public void OnUse(string item)
        {
            screen.SelectionBox.IsVisible = false;
            screen.SelectionBox.UnloadContent();
            Consumable toUse = (Consumable)minion.Inventory.GetItem(item);
            toUse.UseItem(minion);
            minion.Inventory.CheckConsistency();
            IsActive = true;
        }

        protected void EquipCommandSelected(object sender, EventArgs e)
        {
            screen.SelectionBox = new ListBox(minion.Inventory.Equipment);
            screen.SelectionBox.IsVisible = true;
            IsActive = false;
            screen.Delay = true;
            screen.Caller = "Equip";
        }

        public void OnEquip(string item)
        {
            screen.SelectionBox.IsVisible = false;
            screen.SelectionBox.UnloadContent();
            Equipment toEquip = (Equipment)minion.Inventory.GetItem(item);
            minion.Equip(toEquip);
            minion.Inventory.CheckConsistency();
            IsActive = true;
        }

        protected void SaveCommandSelected(object sender, EventArgs e)
        {
            //not implemented.
        }

        protected void ExitCommandSelected(object sender, EventArgs e)
        {
            ScreenManager.Instance.ChangeIngameScreens("TitleScreen");
        }

        protected override void OnCancel()
        {
            ScreenManager.Instance.ChangeIngameScreens("MapScreen");
        }
    }
}
