namespace SecondAttempt
{    
    using Microsoft.Xna.Framework.Input;

    public class InputManager
    {
        KeyboardState currentKeyState, prevKeyState;

        //Singleton class (design pattern)
        private static InputManager instance;

        public static InputManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new InputManager();
                return instance;
            }
        }

        public void Update()
        {
            prevKeyState = currentKeyState;
            if (!ScreenManager.Instance.IsTransitioning)
                currentKeyState = Keyboard.GetState();
        }

        public bool KeyPressed(params Keys[] keys)
        {
            foreach(Keys key in keys)
            {
                if (currentKeyState.IsKeyDown(key) && prevKeyState.IsKeyUp(key))
                    return true;
            }
            return false;
        }

        public bool KeyReleased(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (currentKeyState.IsKeyUp(key) && prevKeyState.IsKeyDown(key))
                    return true;
            }
            return false;
        }

        public bool KeyDown(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (currentKeyState.IsKeyDown(key))
                    return true;
            }
            return false;
        }

        public bool ActionKeyPressed()
        {
            return ((currentKeyState.IsKeyDown(Keys.A) && prevKeyState.IsKeyUp(Keys.A))
                || (currentKeyState.IsKeyDown(Keys.Enter)) && prevKeyState.IsKeyUp(Keys.Enter));
        }

        public bool CancelKeyPressed()
        {
            return ((currentKeyState.IsKeyDown(Keys.F) && prevKeyState.IsKeyUp(Keys.F))
                || (currentKeyState.IsKeyDown(Keys.Back)) && prevKeyState.IsKeyUp(Keys.Back));
        }
    }
}
