namespace SecondAttempt
{
    using System;
    using System.Collections.Generic;    
    using System.Xml.Serialization;
    using System.IO;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Holds the current active screen. Uses semi-singleton style interface - only one screen is active at any one time, but other screen types are preserved.
    /// </summary>
    public class ScreenManager
    {
        //Singleton class (design pattern)
        private static ScreenManager instance;
        [XmlIgnore]
        public Vector2 Dimensions { private set; get; }
        [XmlIgnore]
        public ContentManager Content { private set; get; }
        private XmlManager<GameScreen> xmlGameScreenManager;

        private GameScreen currentScreen, newScreen, overworldScreen;
        [XmlIgnore]
        public GraphicsDevice GraphicsDevice;
        [XmlIgnore]
        public SpriteBatch spriteBatch;

        public Image Image;
        [XmlIgnore]
        public bool IsTransitioning { get; private set; }

        //we are going to call our ScreenManager through his instance
        public static ScreenManager Instance
        {
            get
            {
                if (instance == null)
                {
                    XmlManager<ScreenManager> xml = new XmlManager<ScreenManager>();
                    instance = xml.Load("Load/ScreenManager.xml");
                }

                return instance;
            }
        }

        public void ChangeScreens(string screenName)
        {
            newScreen = (GameScreen)Activator.CreateInstance(Type.GetType("SecondAttempt." + screenName));            
            Image.IsActive = true;
            Image.FadeEffect.Increase = true;
            Image.Alpha = 0.0f;
            IsTransitioning = true;
        }

        /// <summary>
        /// Used to change screens ingame. Saves the map screen so that it shouldn't have to be reloaded every time a player wins a battle or exits the menu.
        /// </summary>
        /// <param name="screenName"></param>
        public void ChangeIngameScreens(string screenName)
        {
            newScreen = (GameScreen)Activator.CreateInstance(Type.GetType("SecondAttempt." + screenName));            
            if (currentScreen is MapScreen)
            {
                overworldScreen = currentScreen;
                currentScreen = newScreen;
                currentScreen.LoadContent();
            }
            else if (newScreen is TitleScreen)
            {
                currentScreen.UnloadContent();
                GameplayScreen.Player.UnloadContent();
                currentScreen = newScreen;
                newScreen.LoadContent();
            }
            else 
            {
                currentScreen.UnloadContent();
                currentScreen = overworldScreen;
                ((MapScreen)currentScreen).ReloadMusic();
            }
        }

        /// <summary>
        /// Uses the generated enemies to start a new battle.
        /// </summary>
        /// <param name="enemies"></param>
        public void ChangeToBattleScreen(List<Enemy> enemies)
        {
            newScreen = (GameScreen)new BattleScreen(enemies);
            
            overworldScreen = currentScreen;
            currentScreen = newScreen;
            currentScreen.LoadContent();
        }

        /// <summary>
        /// Enables the trasition fade effect between initial game screens.
        /// </summary>
        /// <param name="gameTime"></param>
        void Transition(GameTime gameTime)
        {
            if(IsTransitioning)
            {
                Image.Update(gameTime);
                if(Image.Alpha == 1.0f)
                {
                    currentScreen.UnloadContent();
                    currentScreen = newScreen;
                    xmlGameScreenManager.Type = currentScreen.Type;
                    if (File.Exists(currentScreen.XmlPath))
                        currentScreen = xmlGameScreenManager.Load(currentScreen.XmlPath);
                    currentScreen.LoadContent();
                }
                else if (Image.Alpha == 0.0f)
                {
                    Image.IsActive = false;
                    IsTransitioning = false;
                }
            }
        }
        
        public ScreenManager()
        {
            Dimensions = new Vector2(640, 480);
            currentScreen = new SplashScreen();            
            xmlGameScreenManager = new XmlManager<GameScreen>();
            xmlGameScreenManager.Type = currentScreen.Type;
            currentScreen = xmlGameScreenManager.Load("Load/SplashScreen.xml");
        }
        
        public void LoadContent(ContentManager Content)
        {
            this.Content = new ContentManager(Content.ServiceProvider, "Content");
            currentScreen.LoadContent();
            Image.LoadContent();
        }

        public void UnloadContent()
        {
            currentScreen.UnloadContent();
            Image.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            currentScreen.Update(gameTime);
            Transition(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentScreen.Draw(spriteBatch);
            if (IsTransitioning)
                Image.Draw(spriteBatch);
        }
    }
}
