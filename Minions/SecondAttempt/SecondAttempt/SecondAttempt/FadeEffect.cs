namespace SecondAttempt
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Microsoft.Xna.Framework;

    public class FadeEffect : ImageEffect
    {
        public float FadeSpeed;
        public bool Increase;
        public float FadeMax;
        public float FadeMin;        

        public FadeEffect()
        {
            FadeSpeed = 1;
            Increase = false;
            FadeMax = 1;
            FadeMin = 0;
        }

        public override void LoadContent(Image Image)
        {
            base.LoadContent(Image);
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (image.IsActive)
            {
                if (!Increase)
                    image.Alpha -= FadeSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                else
                    image.Alpha += FadeSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (image.Alpha < FadeMin)
                {
                    Increase = true;
                    image.Alpha = FadeMin;
                }
                else if (image.Alpha > FadeMax)
                {
                    Increase = false;
                    image.Alpha = FadeMax;
                }
            }
            else
                image.Alpha = FadeMax;
        }
    }
}
