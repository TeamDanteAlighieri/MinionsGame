namespace SecondAttempt
{   
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Displays the ingame menu. Called by using the CancelKeyPressed in the MapScreen.
    /// </summary>
    public class IngameMenuScreen : GameplayScreen
    {
        private IngameMenuCommands commands;
        public ListBox SelectionBox;
        public bool Delay;
        public string Caller;
        private int delayCounter;
        

        public override void LoadContent()
        {            
            base.LoadContent();
            commands = new IngameMenuCommands(this, Player);
            SelectionBox = new ListBox();
        }

        public override void UnloadContent()
        {
            commands.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (Delay)
            {
                delayCounter++;
                if (delayCounter > 10)
                {
                    Delay = false;
                    delayCounter = 0;
                }
            }
            else if (commands.IsActive) commands.Update(gameTime);            
            else if (SelectionBox.IsVisible)
            {
                SelectionBox.Update(gameTime);
                string item = SelectionBox.CheckSelection();
                if (item != string.Empty)
                {
                    Delay = true;
                    if (Caller == "Use") commands.OnUse(item);
                    else if (Caller == "Equip") commands.OnEquip(item);
                    SelectionBox.IsVisible = false;
                    commands.IsActive = true;
                } 
                if (InputManager.Instance.CancelKeyPressed())
                {
                    SelectionBox.IsVisible = false;
                    commands.IsActive = true;
                    Delay = true;
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            commands.Draw(spriteBatch);
            SelectionBox.Draw(spriteBatch);
        }
    }
}
