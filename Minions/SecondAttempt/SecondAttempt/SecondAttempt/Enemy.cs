using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
namespace SecondAttempt
{
	public class Enemy : Character, ICloneable
	{
        //public LootTable Drops;
        public EnemyType Type { get; set; }
        public int SpecialMoveChance { get; set; }
        public bool IsAlive { get; set; }
        public string ImageLoadPath { get; set; }

        public Enemy()
        {
            IsAlive = true;
            ActionTimer = 0;
        }

        public void LoadContent() 
        {
            SpriteImage = new Image();
            XmlManager<Image> spriteLoader = new XmlManager<Image>();
            SpriteImage = spriteLoader.Load(this.ImageLoadPath);
            SpriteImage.LoadContent();
        }

        public void UnloadContent() 
        {
            SpriteImage.UnloadContent();
        }

        public void Update(GameTime gameTime) 
        {
            SpriteImage.Update(gameTime);
            if (CurrentHealth <= 0) IsAlive = false;
        }

        public void Draw(SpriteBatch spriteBatch) 
        {
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
