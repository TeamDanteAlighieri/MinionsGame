﻿namespace SecondAttempt
{
    using Microsoft.Xna.Framework;

    public class ImageEffect
    {
        protected Image image;
        public bool IsActive;

        public ImageEffect()
        {
            IsActive = false;
        }

        public virtual void LoadContent(Image Image)
        {
            this.image = Image;
        }

        public virtual void UnloadContent()
        { 
        }
        public virtual void Update(GameTime gameTime)
        {
        }
    }
}
