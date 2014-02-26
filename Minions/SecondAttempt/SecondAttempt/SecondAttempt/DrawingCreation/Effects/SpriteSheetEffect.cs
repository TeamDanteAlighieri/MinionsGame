namespace SecondAttempt
{
    using Microsoft.Xna.Framework;

    public class SpriteSheetEffect : ImageEffect
    {
        public int FrameCounter;
        public int SwitchFrame;
        public Vector2 CurrentFrame;
        public Vector2 AmountOfFrames;

        public int FrameWidth
        {
            get
            {
                if (image.Texture != null)
                    return image.Texture.Width / (int)AmountOfFrames.X;
                return 0;
            }
        }

        public int FrameHeight
        {
            get
            {
                if (image.Texture != null)
                    return image.Texture.Height / (int)AmountOfFrames.Y;
                return 0;
            }
        }
        public SpriteSheetEffect()//here we adjust the walking animation of the hero
        {
            AmountOfFrames = new Vector2(3, 4);//how many frames are in the hero picture
            CurrentFrame = new Vector2(1, 0);
            SwitchFrame = 100;
            FrameCounter = 0;
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
                //increasing the frame value
                FrameCounter += (int)gameTime.ElapsedGameTime.TotalMilliseconds; //calculating the time to switch the frame
                if (FrameCounter >= SwitchFrame)
                {
                    FrameCounter = 0;
                    CurrentFrame.X++;
                    //cycling through the "walking" animations on the line
                    if (CurrentFrame.X * FrameWidth >= image.Texture.Width)
                        CurrentFrame.X = 0;
                }
            }
            else
                CurrentFrame.X = 1;
            //cropping from the hero's image only those "little dudes" which is neeeded for the animation
            image.SourceRect = new Rectangle((int)CurrentFrame.X * FrameWidth,
                (int)CurrentFrame.Y * FrameHeight, FrameWidth, FrameHeight);

        }
    }
}
