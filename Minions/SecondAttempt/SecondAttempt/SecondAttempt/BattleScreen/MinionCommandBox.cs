namespace SecondAttempt
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Microsoft.Xna.Framework;

    public class MinionCommandBox : CommandsBox
    {
        private BattleScreen screenInstance;
        private Minion minion;

        /// <summary>
        /// Creates a command box tailored to the minion class. Additional characters, once added should have a similar logic behind their implementation.
        /// </summary>
        /// <param name="screenInstance"></param>
        /// <param name="minion"></param>
        public MinionCommandBox(BattleScreen screenInstance, Minion minion) : base('y')
        {
            this.minion = minion;
            this.screenInstance = screenInstance;
            this.Frame = new FrameBox(StaticConstants.BordeWidth, StaticConstants.CommandBoxDimensions, Color.Blue);             
            this.Items = new CommandBoxItem[4] 
            { 
                new CommandBoxItem("Attack",
                    new Vector2(StaticConstants.CommandBoxDimensions.Left + 15, StaticConstants.CommandBoxDimensions.Top + 5), 
                    Color.Gray),
                new CommandBoxItem("Defend",
                    new Vector2(StaticConstants.CommandBoxDimensions.Left + 15, StaticConstants.CommandBoxDimensions.Top + 5 + 25), 
                    Color.Gray),
                new CommandBoxItem("Skill",
                    new Vector2(StaticConstants.CommandBoxDimensions.Left + 15, StaticConstants.CommandBoxDimensions.Top + 5 + 50), 
                    Color.Gray),
                new CommandBoxItem("Item",
                    new Vector2(StaticConstants.CommandBoxDimensions.Left + 15, StaticConstants.CommandBoxDimensions.Top + 5 + 75), 
                    Color.Gray)
            };

            this.Items[0].Selected += AttackCommandSelected;
            this.Items[1].Selected += DefendCommandSelected;
            this.Items[2].Selected += SkillCommandSelected;
            this.Items[3].Selected += ItemCommandSelected;
        }
        
        /// <summary>
        /// Interprets the result of commands that require additional exteranl input.
        /// </summary>
        /// <param name="commandSequnce"></param>
        /// <param name="target"></param>
        public override void InterpetCommands(string[] commandSequnce, Character target)
        {
            if (commandSequnce[0] == "Attack") OnAttack(target);
            else if (commandSequnce[0] == "Skill") OnSkill(target, commandSequnce[1]) ;
            else if (commandSequnce[0] == "Item") OnItem(target, commandSequnce[1]) ;
        }

        /// <summary>
        /// Initiates target selection for a command attack
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AttackCommandSelected(object sender, EventArgs e)
        {
            screenInstance.SelectTarget = true;
            screenInstance.CommandSequence[0] = this.Items[0].Text;
            this.IsVisible = false;
        }

        /// <summary>
        /// Actual attack logic once a target is selected.
        /// </summary>
        /// <param name="target"></param>
        public void OnAttack(Character target)
        {
            if (StaticConstants.Random.Next(1, 101) < minion.Accuracy)
            {
                int damage = minion.AttackPower - target.Defence;
                if (damage <= 0) damage = 1;
                target.CurrentHealth -= damage;
            }
            screenInstance.SelectTarget = false;            
        }

        protected void DefendCommandSelected(object sender, EventArgs e)
        {
            this.IsVisible = false;
            OnDefend();
        }

        private void OnDefend()
        {
            minion.Defence += 10;
            minion.UsedDefend = true;                        
        }

        /// <summary>
        /// Not yet implemented.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void SkillCommandSelected(object sender, EventArgs e)
        {
            //Skill event logic here (pop skill menu to select skill to use)
        }

        /// <summary>
        /// Not yet implemented
        /// </summary>
        /// <param name="target"></param>
        /// <param name="skill"></param>
        public void OnSkill(Character target, string skill)
        {
            //Skill effect here. (pop actual skill effect - would involve target selection)
        }

        /// <summary>
        /// Instantiates item selection.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ItemCommandSelected(object sender, EventArgs e)
        {
            screenInstance.ItemSelectionBox.IsVisible = true;
            screenInstance.CommandSequence[0] = this.Items[3].Text;
            this.IsVisible = false;            
        }

        /// <summary>
        /// Applies item effect
        /// </summary>
        /// <param name="target"></param>
        /// <param name="item"></param>
        public void OnItem(Character target, string itemName)
        {
            Consumable item = (Consumable) minion.Inventory.GetItem(itemName);
            item.UseItem(target);
            minion.Inventory.CheckConsistency();
            screenInstance.ItemSelectionBox.UnloadContent();
            screenInstance.ItemSelectionBox = new ListBox(minion.Inventory.Consumables);
            screenInstance.CommandSequence = new string[screenInstance.CommandSequence.Length];
            screenInstance.SelectTarget = false;            
        }

        protected override void OnCancel()
        {
            this.IsVisible = true;
        }
    }
}
