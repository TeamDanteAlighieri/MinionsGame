namespace SecondAttempt
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

	public class Minion : Character 
	{
        public byte Level;
        public int NextLevel;              
        public bool UsedDefend;
        public bool IsActive;
        public bool IsAlive;
        public Inventory Inventory;

        private InternalText hpText;
        private Weapon equipedWeapon;
		
        public Minion() : base()
        {
            Inventory = new Inventory();
            ActionTimeCurrent = 0;
            UsedDefend = false;
            IsActive = false;
            IsAlive = true;
            hpText = new InternalText();
            equipedWeapon = null;
        }

        public void AddExperience(int experience)
        {
            this.Experience += experience;
            while (this.Experience > this.NextLevel) IncreaseLevel();
        }

        public void Equip(Equipment item)
        {
            if (item is Weapon)
            {
                Weapon toEquip = (Weapon)((Weapon)item).Clone();
                if (this.equipedWeapon == null) toEquip.Equip(this);
                else
                {
                    equipedWeapon.Unequip(this);
                    toEquip.Equip(this);
                }
            }
        }

        private void IncreaseLevel()
        {
            this.Level++;
            this.AttackPower += StaticConstants.Random.Next(1, 6);
            this.MaxHealth += StaticConstants.Random.Next(50, 100);
            this.MaxMana += StaticConstants.Random.Next(10, 20);
            this.Defence += StaticConstants.Random.Next(1, 6);
            if (this.Level%5 == 0) this.Speed += 1;
            this.NextLevel = (int)(this.NextLevel * 1.30);
        }

        public override void LoadContent()
        {
            base.LoadContent();
            hpText.Text = string.Format("{0}/{1}", CurrentHealth, MaxHealth);
            hpText.Position = SpriteImage.Position;
            hpText.TextColor = Color.White;
            SpriteImage.LoadContent();
        }

        public override void UnloadContent()
        {
            SpriteImage.UnloadContent();
            hpText.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (UsedDefend && ActionTimeCurrent >= ActionTimeGoal)
            {
                UsedDefend = false;
                this.Defence -= 10;
            }

            hpText.Text = string.Format("{0}/{1}", CurrentHealth, MaxHealth);
            hpText.Position = SpriteImage.Position + new Vector2(-30, 15);

            SpriteImage.Update(gameTime);
            if (this.CurrentHealth <= 0)
            {
                CurrentHealth = 0;
                IsAlive = false;
            }
        }

        public override void Draw(SpriteBatch spriteBatch) 
        {
            base.Draw(spriteBatch);
            hpText.Draw(spriteBatch);
            SpriteImage.Draw(spriteBatch);
        }
	}
}
