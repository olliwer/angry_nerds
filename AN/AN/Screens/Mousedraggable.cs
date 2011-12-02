using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace AN
{

    //<Summary> Object is responsible for..? 

    class Mousedraggable : Sprite
    {

        #region properties 

        const string NERD_ASSETNAME = "tux";
        const int START_POSITION_X = 125;
        const int START_POSITION_Y = 245;
        MouseState oldState = Mouse.GetState();
        Boolean draggingBullet = false;
        Boolean mouseOverLaunchpad = false;
        Vector2 launchPadCoordinates = new Vector2(START_POSITION_X, START_POSITION_Y);
        Vector2 mouseLocation = Vector2.Zero;
        Vector2 bulletLocation = Vector2.Zero;
        Vector2 launchAngle = Vector2.Zero;
        public float launchPower = 0.0f;

        #endregion

        #region load

        public void LoadContent(ContentManager theContentManager)
        {
            Position = launchPadCoordinates;
            base.LoadContent(theContentManager, NERD_ASSETNAME);
        }

        #endregion

        #region UpdateMethods 

        public void Update(GameTime theGameTime)
        {
            UpdateMouse();
            UpdateDraggable();
            UpdateLaunchpad();
            base.Update(theGameTime, launchPower, launchAngle);
        }
        private void UpdateMouse()
        {
            MouseState state = Mouse.GetState();
            mouseLocation.X = state.X;
            mouseLocation.Y = state.Y;
        }
        private void UpdateDraggable()
        {
            if (Vector2.Distance(mouseLocation, launchPadCoordinates) < 100)
            {
                mouseOverLaunchpad = true;
            }
        }
        private void UpdateLaunchpad()
        {
            MouseState newState = Mouse.GetState();

            // Mouse left key being pressed
            if (newState.LeftButton == ButtonState.Pressed)
            {
                // Mouse left key has just been pressed
                if (oldState.LeftButton == ButtonState.Released)
                {
                    //grab the bullet
                    if (mouseOverLaunchpad)
                    {
                        draggingBullet = true;
                        //move the projectile if inside limits
                        if (Vector2.Distance(mouseLocation, launchPadCoordinates) < 100)
                        {
                            bulletLocation = mouseLocation;
                            Position = bulletLocation;
                        }                     
                    }
                }
                // Mouse left key not being pressed

            //Mouse left key has just been released
                else if (oldState.LeftButton == ButtonState.Pressed)
                {
                    //release the bullet
                    if (draggingBullet == true)
                    {
                        draggingBullet = false;
                        launchPower = Vector2.Distance(bulletLocation, launchPadCoordinates);
                        launchAngle = bulletLocation - launchPadCoordinates;
                    }
                }
                // Update saved state.
                oldState = newState;
            }

        }

        #endregion


    }
}
