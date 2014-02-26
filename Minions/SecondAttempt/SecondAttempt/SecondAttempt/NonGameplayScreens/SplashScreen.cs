namespace SecondAttempt
{
    using Microsoft.Xna.Framework;    
    using Microsoft.Xna.Framework.Graphics;    

    /// <summary>
    /// Creates the initial fading splash screen. Dissapears automatically after 2 seconds or if an action key is pressed.
    /// </summary>
    public class SplashScreen : GameScreen
    {
        public Image Image;        
        private bool transitionStarted;

        
        public override void LoadContent()
        {
            base.LoadContent();
            Image.LoadContent();
            transitionStarted = false;            
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

            if ((gameTime.TotalGameTime.Seconds >= 2 && transitionStarted == false) || InputManager.Instance.ActionKeyPressed())
            {
                transitionStarted = true;
                ScreenManager.Instance.ChangeScreens("TitleScreen");// this has to be the same name as the class
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            Image.Draw(spriteBatch);
        }
    }
}
