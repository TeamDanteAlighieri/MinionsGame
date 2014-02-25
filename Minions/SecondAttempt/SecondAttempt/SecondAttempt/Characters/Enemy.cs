namespace SecondAttempt
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

	public class Enemy : Character, ICloneable
	{
        //public LootTable Drops;
        public EnemyType Type { get; set; }
        public int SpecialMoveChance { get; set; }
        public bool IsAlive { get; set; }
        public string ImageLoadPath { get; set; }

        public Enemy() : base()
        {
            IsAlive = true;
            ActionTimeCurrent = 0;
        }

        public override void LoadContent() 
        {
            base.LoadContent();
            SpriteImage = new Image();
            XmlManager<Image> spriteLoader = new XmlManager<Image>();
            SpriteImage = spriteLoader.Load(this.ImageLoadPath);
            SpriteImage.LoadContent();
        }

        public override void UnloadContent() 
        {
            SpriteImage.UnloadContent();
        }

        public override void Update(GameTime gameTime) 
        {
            base.Update(gameTime);
            SpriteImage.Update(gameTime);
            if (IsAlive && ActionTimeCurrent >= ActionTimeGoal)
            {
                BattleLogic();
                ActionTimeCurrent = 0;
            }
            if (CurrentHealth <= 0) IsAlive = false;
        }

        /// <summary>
        /// Using virtual to allow future implementations of Enemy subtypes (Probably useful to create specific boss battle logics)
        /// </summary>
        public virtual void BattleLogic()
        {
            ActionTimeCurrent = 0;
            int actionSeed = StaticConstants.Random.Next(1, 101);
            //Normal attack logic.
            if (actionSeed > this.SpecialMoveChance)
            {
                if (StaticConstants.Random.Next(1, 101) <= Accuracy)
                {
                    int damage = this.AttackPower - GameplayScreen.Player.Defence;
                    if (damage <= 0) damage = 1;
                    GameplayScreen.Player.CurrentHealth -= damage;
                }
            }
            else
            {
                //Special move logic goes here.
            }
        }

        public override void Draw(SpriteBatch spriteBatch) 
        {
            base.Draw(spriteBatch);
            SpriteImage.Draw(spriteBatch);            
        }

        public object Clone()
        {
            Enemy result = new Enemy();

            result.Name = this.Name;
            result.Accuracy = this.Accuracy;
            result.AttackPower = this.AttackPower;
            result.CurrentHealth = this.CurrentHealth;
            result.CurrentMana = this.CurrentMana;
            result.Defence = this.Defence;
            result.Experience = this.Experience;
            result.IsAlive = this.IsAlive;
            result.MaxHealth = this.MaxHealth;
            result.MaxMana = this.MaxMana;
            result.SpecialMoveChance = this.SpecialMoveChance;
            result.Speed = this.Speed;
            result.Type = this.Type;
            result.ImageLoadPath = this.ImageLoadPath;            

            return result;
        }
    }
}
