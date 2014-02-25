namespace SecondAttempt
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Microsoft.Xna.Framework;

    class MinionCommandBox : CommandsBox
    {
        private BattleScreen screenInstance;
        private Minion minion;

        public MinionCommandBox(BattleScreen screenInstance, Minion minion) : base()
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
        
        public override void InterpetCommands(string[] commandSequnce, Character target)
        {
            if (commandSequnce[0] == "Attack") OnAttack(target);
            else if (commandSequnce[0] == "Skill") OnSkill(target) ;
            else if (commandSequnce[0] == "Item") OnItem(target) ;
        }

        public void AttackCommandSelected(object sender, EventArgs e)
        {
            screenInstance.SelectTarget = true;
            screenInstance.CommandSequence[0] = this.Items[0].Text;
            this.IsVisible = false;
        }

        public void OnAttack(Character target)
        {
            if (StaticConstants.Random.Next(1, 101) < minion.Accuracy)
                target.CurrentHealth += target.Defence - minion.AttackPower;
            screenInstance.SelectTarget = false;
            //Action text box text goes here.
        }

        public void DefendCommandSelected(object sender, EventArgs e)
        {
            this.IsVisible = false;
            OnDefend();
        }

        private void OnDefend()
        {
            minion.Defence += 10;
            minion.UsedDefend = true;
            screenInstance.RestartActionTime = false;
            //Action text box text goes here.
        }

        public void SkillCommandSelected(object sender, EventArgs e)
        {
            //Skill event logic here (pop skill menu to select skill to use)
        }

        public void OnSkill(Character target)
        {
            //Skill effect here. (pop actual skill effect - would involve target selection)
        }

        public void ItemCommandSelected(object sender, EventArgs e)
        {
            //Item event logic here (pop item menu to select item to use)
        }

        public void OnItem(Character target)
        {
            //Item effect here.
        }

        public void OnCancel()
        {
            this.IsVisible = true;
        }
    }
}
