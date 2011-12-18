#region File Description
//-----------------------------------------------------------------------------
// GameplayScreen.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using AN;
#endregion

namespace GameStateManagement
{
    /// <summary>
    /// This screen implements the actual game logic. It is just a
    /// placeholder to get the idea across: you'll probably want to
    /// put some more interesting gameplay in here!
    /// </summary>
    class GameplayScreen : GameScreen
    {


        #region Fields

        /*
         * Fonts and content
         */ 
        ContentManager content;
        SpriteFont gameFont;

        /*
         * Points and projectiles
         */
        int points = 0;
        int ammukset = 0;
        
        /*
         * Current objects and backgrounds
         */ 
        Nerd nerd;
        Sika target, target2, target3, target4, target5;
        Tile wall, wall2, wall3, wall4, wall5, wall6, wall7;
        Sprite mBackgroundOne;

        /*
         * Rest
         */ 
        Random random = new Random();
        float pauseAlpha;
        KeyboardState current;

        #endregion

        #region Initialization


 
        /// Constructor.

        public GameplayScreen()
        {
            TransitionOnTime = TimeSpan.FromSeconds(1.5);
            TransitionOffTime = TimeSpan.FromSeconds(0.5);
            
        }


        /*
         * Load graphics content for the game.
         */
        public override void LoadContent()
        {
            if (content == null)
            {
                content = new ContentManager(ScreenManager.Game.Services, "Content/GraphicsContent");
            }
            gameFont = content.Load<SpriteFont>("menufont");
            /*
             * Adding the background
             */
            mBackgroundOne = new Sprite();
            mBackgroundOne.LoadContent(this.content, "Background01");
            mBackgroundOne.Position = new Vector2(0, 0);
            mBackgroundOne.Scale = 1;

            /*
             * Adding the projectile penguin
             */
            nerd = new Nerd();
            nerd.LoadContent(this.content, 150, 600);
            ammukset = nerd.ammukset;
            
            /*
             * Adding the walls and targets
             */
            target = new Sika();
            target.Scale = 0.3F;
            target.value = 3;
            target.LoadContent(this.content, 800, 500, "birdy");

            target2 = new Sika();
            target2.Scale = 0.3F;
            target2.value = 5;
            target2.LoadContent(this.content, 700, 600, "birdy");

            target3 = new Sika();
            target3.Scale = 0.3F;
            target3.value = 7;
            target3.LoadContent(this.content, 700, 300, "birdy");
            
            target4 = new Sika();
            target4.Scale = 0.3F;
            target4.value = 10;
            target4.LoadContent(this.content, 480, 550, "birdy");
            
            target5 = new Sika();
            target5.Scale = 0.3F;
            target5.value = 8;
            target5.LoadContent(this.content, 500, 200, "birdy");

            wall = new Tile();

            wall.LoadContent(this.content, 400, 500, "tile2");
            

            wall.LoadContent(this.content, 400, 500, "tile3");

            wall2 = new Tile();
            wall2.LoadContent(this.content, 400, 530, "tile3");

            wall3 = new Tile();
            wall3.LoadContent(this.content, 400, 560, "tile3");

            wall4 = new Tile();
            wall4.LoadContent(this.content, 400, 590, "tile3");

            wall5 = new Tile();
            wall5.LoadContent(this.content, 400, 620, "tile3");

            wall6 = new Tile();
            wall6.LoadContent(this.content, 400, 650, "tile3");

            wall7 = new Tile();
            wall7.LoadContent(this.content, 400, 680, "tile3");
               
    



           /*
            * A super cool one second wait when the load is finished to make the illusion our game is heavy
            */
            Thread.Sleep(1000);
            
            ScreenManager.Game.ResetElapsedTime();

        }


         /*
          * Unload graphics content used by the game.
          */
        public override void UnloadContent()
        {
            content.Unload();
        }

        #endregion

        #region Update and Draw


       /*
        * Updates the state of the game. This method checks the GameScreen.IsActive
        * property, so the game will stop updating when the pause menu is active,
        * or if you tab away to a different application.
        */
        public override void Update(GameTime gameTime, bool otherScreenHasFocus,
                                                       bool coveredByOtherScreen)
        {
            base.Update(gameTime, otherScreenHasFocus, false);



                        
            /*
             * Update the amount of projectiles
             */
            ammukset = nerd.ammukset;


            /*
             * Gradually fade in or out depending on whether we are covered by the pause screen.
             */
             if (coveredByOtherScreen)
                pauseAlpha = Math.Min(pauseAlpha + 1f / 32, 1);
            else
            {
                pauseAlpha = Math.Max(pauseAlpha - 1f / 32, 0);


                current = Keyboard.GetState();
                Camera.Update(current);



                /*
                 * Update the projectile, targets and objects
                 */ 
                nerd.Update(gameTime);
                target.Update(gameTime);
                target2.Update(gameTime);
                target3.Update(gameTime);
                target4.Update(gameTime);
                target5.Update(gameTime);
               
                 
                wall.Update(gameTime);
                wall2.Update(gameTime);
                wall3.Update(gameTime);
                wall4.Update(gameTime);
                wall5.Update(gameTime);
                wall6.Update(gameTime);
                wall7.Update(gameTime);
               
                 /*
                 * Collision detection
                 */

                if (target.sikaRectangle.Intersects(nerd.nerdRectangle) && !target.sikaHit)
                {
                    target.hit(gameTime);
                    points = points + target.value;
                }

                if (target2.sikaRectangle.Intersects(nerd.nerdRectangle) && !target2.sikaHit)
                {
                    target2.hit(gameTime);
                    points = points + target2.value;
                }
                if (target3.sikaRectangle.Intersects(nerd.nerdRectangle) && !target3.sikaHit)
                {
                    target3.hit(gameTime);
                    points = points + target3.value;
                }

                if (target4.sikaRectangle.Intersects(nerd.nerdRectangle) && !target4.sikaHit)
                {
                    target4.hit(gameTime);
                    points = points + target4.value;
                }
                
                 if (target5.sikaRectangle.Intersects(nerd.nerdRectangle) && !target5.sikaHit)
                {
                    target5.hit(gameTime);
                    points = points + target5.value;
                }



                if (wall.tileRectangle.Intersects(nerd.nerdRectangle))
                {
                    wall.reset(gameTime);
                    nerd.reset();
                }
                if (wall2.tileRectangle.Intersects(nerd.nerdRectangle))
                {
                    wall2.reset(gameTime);
                    nerd.reset();
                }
                if (wall3.tileRectangle.Intersects(nerd.nerdRectangle))
                {
                    wall3.reset(gameTime);
                    nerd.reset();
                }
                if (wall4.tileRectangle.Intersects(nerd.nerdRectangle))
                {
                    wall4.reset(gameTime);
                    nerd.reset();
                }
                if (wall5.tileRectangle.Intersects(nerd.nerdRectangle))
                {
                    wall5.reset(gameTime);
                    nerd.reset();
                }
                if (wall6.tileRectangle.Intersects(nerd.nerdRectangle))
                {
                    wall6.reset(gameTime);
                    nerd.reset();
                }
                if (wall7.tileRectangle.Intersects(nerd.nerdRectangle))
                {
                    wall7.reset(gameTime);
                    nerd.reset();
                }

                 /*
                  * Update the projectile amount
                  */
                ammukset = nerd.ammukset;


                /*
                 * To win the game you need over 10 points.
                 */
                if (points> 13)
                {
                    ScreenManager.AddScreen(new VictoryMenuScreen(), ControllingPlayer);
                }

                if (ammukset < 1)
                {
                    ScreenManager.AddScreen(new DefeatMenuScreen(), ControllingPlayer);
                }
                


                Vector2 aDirection = new Vector2(-1, 0);
                Vector2 aSpeed = new Vector2(160, 0);

                }     

            }
        

   
        /*
        void NextLevel(PlayerIndexEventArgs e)
        {
        LoadingScreen.Load(ScreenManager, true, e.PlayerIndex,
                                  new GameplayScreen());
        }
        */


        /*
         * Lets the game respond to player input. Unlike the Update method,
         * this will only be called when the gameplay screen is active.
         */
        public override void HandleInput(InputState input)
        {
            if (input == null)
                throw new ArgumentNullException("input");
            int playerIndex = (int)ControllingPlayer.Value;
            KeyboardState keyboardState = input.CurrentKeyboardStates[playerIndex];
            if (input.IsPauseGame(ControllingPlayer))
            {
                ScreenManager.AddScreen(new PauseMenuScreen(), ControllingPlayer);
            }
        }



        

        /*
         * Draw the gameplay screen
         */
        public override void Draw(GameTime gameTime)
        {
                 
            SpriteBatch spriteBatch = ScreenManager.SpriteBatch;      
            spriteBatch.Begin();

            /*
             * Draws the projectile, objects and targets
             */
            mBackgroundOne.Draw(spriteBatch);
            nerd.Draw(spriteBatch);
            target.Draw(spriteBatch);
            target2.Draw(spriteBatch);
            target3.Draw(spriteBatch);
            target4.Draw(spriteBatch);
            target5.Draw(spriteBatch);
            wall.Draw(spriteBatch);
            wall2.Draw(spriteBatch);
            wall3.Draw(spriteBatch);
            wall4.Draw(spriteBatch);
            wall5.Draw(spriteBatch);
            wall6.Draw(spriteBatch);
            wall7.Draw(spriteBatch);

            /*
             * Draws the String for points and projectiles
             */
            spriteBatch.DrawString( 
            gameFont, 
            "Points: " + points.ToString(),
            new Vector2( 
            700,
            10.0f),
            Color.Black);

            spriteBatch.DrawString(
            gameFont,
            "Projectiles: " + ammukset.ToString(),
            new Vector2(
            400,
            10.0f),
            Color.Black);

            spriteBatch.DrawString(
            gameFont,
            "Points to beat: " + 14,
            new Vector2(
            100,
            10.0f),
            Color.Black); 

            spriteBatch.End();
            /*
             * If the game is transitioning on or off, fade it out to black.
             */
            if (TransitionPosition > 0 || pauseAlpha > 0)
            {
                float alpha = MathHelper.Lerp(1f - TransitionAlpha, 1f, pauseAlpha / 2);

                ScreenManager.FadeBackBufferToBlack(alpha);
            }
        }


        #endregion

        public ContentManager Content { get; set; }
    }
}
