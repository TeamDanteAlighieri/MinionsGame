using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SecondAttempt
{
    public class OptionsScreen : GameScreen
    {
        private FrameBox boxFrame;
        private InternalText[] internalText;        
        private Rectangle rect;                
        private int activeOption;        

        public override void LoadContent()
        {
            base.LoadContent();
            activeOption = 0;
            rect = new Rectangle(20, (int) ScreenManager.Instance.Dimensions.Y - 170, 120, 150);
            boxFrame = new FrameBox();
            boxFrame.InternalRect = rect;
            boxFrame.BorderWidth = 5;
            boxFrame.InternalColor = Color.DarkBlue;
            boxFrame.LoadContent();

            internalText = new InternalText[4];
            for (int i = 0; i < 4; i++)
            {
                internalText[i] = new InternalText();
                internalText[i].Position = new Vector2(rect.Left + 15, rect.Top + 5 + 25 * i);
            }

            internalText[0].Text = "Attack";
            internalText[1].Text = "Ability";
            internalText[2].Text = "Item";
            internalText[3].Text = "Defend";

            internalText[0].TextColor = Color.White;
            internalText[1].TextColor = Color.Gray;
            internalText[2].TextColor = Color.Gray;
            internalText[3].TextColor = Color.Gray;

            foreach (var item in internalText)
            {
                item.LoadContent();
            }
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (InputManager.Instance.KeyPressed(Keys.Up) && --activeOption < 0) activeOption = 0;
            if (InputManager.Instance.KeyPressed(Keys.Down) && ++activeOption >= 4) activeOption = 3;
            for (int i = 0; i < 4; i++)
            {
                internalText[i].TextColor = Color.Gray;
            }
            internalText[activeOption].TextColor = Color.White;
            if (InputManager.Instance.KeyPressed(Keys.Back)) ScreenManager.Instance.ChangeScreens("TitleScreen");
            /*text.Update(gameTime);
            move += 0.01f;

            if (gameTime.TotalGameTime.Seconds > 5) color = Color.DarkBlue;
            if (gameTime.TotalGameTime.Seconds > 10) color = Color.Gray;*/
        }        

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            boxFrame.Draw(spriteBatch);
            foreach (var text in internalText)
            {
                text.Draw(spriteBatch);
            }
            /*
            text.Draw(spriteBatch);
            if (isVisible) spriteBatch.Draw(box, rect, null, color, 0f, Vector2.Zero, SpriteEffects.None, 0f); //spriteBatch.Draw(box, rect, null, color);
            if (isVisible) spriteBatch.Draw(box, rect2, null, color, 0f, Vector2.Zero, SpriteEffects.None, 0f);*/
        }
    }
}
