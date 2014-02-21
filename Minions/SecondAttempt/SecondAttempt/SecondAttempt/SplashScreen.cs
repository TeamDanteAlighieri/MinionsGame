namespace SecondAttempt
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class SplashScreen : GameScreen
    {
        public Image Image;        
        private bool transitionStarted;

        
        public override void LoadContent()
        {
            base.LoadContent();
            Image.LoadContent();
            transitionStarted = false;
            //Image.FadeEffect.FadeSpeed = 0.5f;
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            Image.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Image.Update(gameTime);

            if ((gameTime.TotalGameTime.Seconds >= 1 && transitionStarted == false) || InputManager.Instance.KeyPressed(Keys.Enter, Keys.Z))
            {
                transitionStarted = true;
                ScreenManager.Instance.ChangeScreens("TitleScreen");// this have to be the same name as the class
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            Image.Draw(spriteBatch);
        }
    }
}
