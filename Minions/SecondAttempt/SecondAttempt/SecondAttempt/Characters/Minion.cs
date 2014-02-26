namespace SecondAttempt
{    
    using Microsoft.Xna.Framework;    
    using Microsoft.Xna.Framework.Graphics;

	public class Minion : Character, IEquip 
	{
        public byte Level;
        public int NextLevelExp;              
        public bool UsedDefend;
        public bool IsActive;
        public bool IsAlive;
        public Inventory Inventory;

        /// <summary>
        /// Battle current hp text.
        /// </summary>
        private FloatingText hpText;
        private Equipment equipedWeapon;
		
        public Minion() : base()
        {
            Inventory = new Inventory();
            ActionTimeCurrent = 0;
            UsedDefend = false;
            IsActive = false;
            IsAlive = true;
            hpText = new FloatingText();
            equipedWeapon = null;
        }
        
        /// <summary>
        /// Adds a set amount of experience to the player and triggers level increase if necessary.
        /// </summary>
        /// <param name="experience"></param>
        public void AddExperience(int experience)
        {
            this.Experience += experience;
            while (this.Experience > this.NextLevelExp) IncreaseLevel();
        }

        /// <summary>
        /// Equips the specified equipment item.
        /// </summary>
        /// <param name="item"></param>
        public void Equip(Equipment item)
        {            
            Equipment toEquip = (Equipment)item.Clone();
            toEquip.Quantity = 1;
            item.Quantity--;
            if (this.equipedWeapon == null) toEquip.Equip(this);                
            else 
            {
                Inventory.AddItem(equipedWeapon);
                equipedWeapon.Unequip(this);
                toEquip.Equip(this);
            }
            equipedWeapon = toEquip;
        }

        /// <summary>
        /// Increases player level and provides a random stat boost. 
        /// </summary>
        private void IncreaseLevel()
        {
            this.Level++;
            this.AttackPower += Constants.Random.Next(1, 6);
            this.MaxHealth += Constants.Random.Next(50, 100);
            this.MaxMana += Constants.Random.Next(10, 20);
            this.Defence += Constants.Random.Next(1, 6);
            if (this.Level%5 == 0) this.Speed += 1;
            this.Experience -= NextLevelExp;
            this.NextLevelExp = (int)(this.NextLevelExp * 1.30);            
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
            hpText.Position = SpriteImage.Position + Constants.MiniongHealthOffset;

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
