using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace AN
{
    class Nerd : Sprite
    {

        #region properties 

        const string NERD_ASSETNAME = "tux";
        const int START_POSITION_X = 125;
        const int START_POSITION_Y = 245;
        const int NERD_SPEED = 160;
        const int MOVE_UP = -1;
        const int MOVE_DOWN = 1;
        const int MOVE_LEFT = -1;
        const int MOVE_RIGHT = 1;

		int testi;


        enum State
        {
            Walking
        }
        State mCurrentState = State.Walking;

        Vector2 mDirection = Vector2.Zero;
        Vector2 mSpeed = Vector2.Zero;

        KeyboardState mPreviousKeyboardState;
        
        #endregion

        #region load

        public void LoadContent(ContentManager theContentManager)
        {
            Position = new Vector2(START_POSITION_X, START_POSITION_Y);
            base.LoadContent(theContentManager, "tux");
        }

        #endregion

        #region UpdateMethods

        public void Update(GameTime theGameTime)
        {
            KeyboardState aCurrentKeyboardState = Keyboard.GetState();

            UpdateMovement(aCurrentKeyboardState);

            mPreviousKeyboardState = aCurrentKeyboardState;

            //base.Update(theGameTime, mSpeed, mDirection);
        }
        private void UpdateMovement(KeyboardState aCurrentKeyboardState)
        {
            if (mCurrentState == State.Walking)
            {
                mSpeed = Vector2.Zero;
                mDirection = Vector2.Zero;

                if (aCurrentKeyboardState.IsKeyDown(Keys.Left) == true)
                {
                    mSpeed.X = NERD_SPEED;
                    mDirection.X = MOVE_LEFT;
                }
                else if (aCurrentKeyboardState.IsKeyDown(Keys.Right) == true)
                {
                    mSpeed.X = NERD_SPEED;
                    mDirection.X = MOVE_RIGHT;
                }

                if (aCurrentKeyboardState.IsKeyDown(Keys.Up) == true)
                {
                    mSpeed.Y = NERD_SPEED;
                    mDirection.Y = MOVE_UP;
                }
                else if (aCurrentKeyboardState.IsKeyDown(Keys.Down) == true)
                {
                    mSpeed.Y = NERD_SPEED;
                    mDirection.Y = MOVE_DOWN;
                }
            }
        }
        #endregion

    }
}
