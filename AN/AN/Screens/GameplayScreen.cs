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

        //Xna examplen 
        ContentManager content;
        SpriteFont gameFont;

        Vector2 playerPosition = new Vector2(100, 100);
        Vector2 enemyPosition = new Vector2(100, 100);

        Random random = new Random();

        float pauseAlpha;
        //XNA example end




        Camera camera;
        KeyboardState current;
        GraphicsDeviceManager graphics;
   
        SpriteBatch spriteBatch;

        Nerd nerd;
        Sika target;
 

        Sprite mBackgroundOne;


  
   
        #endregion

        #region Initialization


        /// <summary>
        /// Constructor.
        /// </summary>
        public GameplayScreen()
        {
            TransitionOnTime = TimeSpan.FromSeconds(1.5);
            TransitionOffTime = TimeSpan.FromSeconds(0.5);
            
        }


        /// <summary>
        /// Load graphics content for the game.
        /// </summary>
        public override void LoadContent()
        {
            if (content == null)
            {
                content = new ContentManager(ScreenManager.Game.Services, "Content/GraphicsContent");
            }

            gameFont = content.Load<SpriteFont>("menufont");
           // spriteBatch = new SpriteBatch(GraphicsDevice);

 

            //m‰‰ritell‰‰n background
            mBackgroundOne = new Sprite();
            mBackgroundOne.LoadContent(this.content, "Background01");
            mBackgroundOne.Position = new Vector2(0, 0);
            mBackgroundOne.Scale = 1;

            //m‰‰rritell‰‰n tuxi
            nerd = new Nerd();
            nerd.LoadContent(this.content);
            nerd.Position.X = 800;
            nerd.Position.Y = 300;

            //tarkoitus tehd‰ t‰st‰ "possu"
            target = new Sika();
            target.LoadContent(this.content);
            target.Position.X = 900;
            target.Position.Y = 600;
            
           // mBackgroundTwo.LoadContent(this.content, "Background02");
           // mBackgroundTwo.Position = new Vector2(mBackgroundOne.Position.X + mBackgroundOne.Size.Width, 0);

            //mBackgroundThree.LoadContent(this.Content, "Background03");
            //mBackgroundThree.Position = new Vector2(mBackgroundTwo.Position.X + mBackgroundTwo.Size.Width, 0);

            //mBackgroundFour.LoadContent(this.Content, "Background04");
            //mBackgroundFour.Position = new Vector2(mBackgroundThree.Position.X + mBackgroundThree.Size.Width, 0);

            //mBackgroundFive.LoadContent(this.Content, "Background05");
            //mBackgroundFive.Position = new Vector2(mBackgroundFour.Position.X + mBackgroundFour.Size.Width, 0);


            //lintu



           //t‰m‰n voi poistaa lopullisesta, mutta antaa paremman fiiliksen kun load screeni n‰kyy hetken :)
            Thread.Sleep(1000);

            // once the load has finished, we use ResetElapsedTime to tell the game's
            // timing mechanism that we have just finished a very long frame, and that
            // it should not try to catch up.
            ScreenManager.Game.ResetElapsedTime();



            //vanhasta luokasta revitut d‰d‰t:

            // Create a new SpriteBatch, which can be used to draw textures.

            //mit‰ n‰ill‰ tehd‰‰n?
            //mSprite.LoadContent(this.Content, "birdy");
            //mSprite.Position = new Vector2(125, 245);

            //mSpriteTwo.LoadContent(this.Content, "birdy");
            //mSpriteTwo.Position.X = 300;
            //mSpriteTwo.Position.Y = 300;

  
        }


        /// <summary>
        /// Unload graphics content used by the game.
        /// </summary>
        public override void UnloadContent()
        {
            content.Unload();
        }

        #endregion

        #region Update and Draw


        /// <summary>
        /// Updates the state of the game. This method checks the GameScreen.IsActive
        /// property, so the game will stop updating when the pause menu is active,
        /// or if you tab away to a different application.
        /// </summary>
        public override void Update(GameTime gameTime, bool otherScreenHasFocus,
                                                       bool coveredByOtherScreen)
        {
            base.Update(gameTime, otherScreenHasFocus, false);

            // Gradually fade in or out depending on whether we are covered by the pause screen.
            if (coveredByOtherScreen)
                pauseAlpha = Math.Min(pauseAlpha + 1f / 32, 1);
            else
                pauseAlpha = Math.Max(pauseAlpha - 1f / 32, 0);

            if (IsActive)
            {
                // Apply some random jitter to make the enemy move around.
                const float randomization = 10;

                enemyPosition.X += (float)(random.NextDouble() - 0.5) * randomization;
                enemyPosition.Y += (float)(random.NextDouble() - 0.5) * randomization;

                // Apply a stabilizing force to stop the enemy moving off the screen.
                Vector2 targetPosition = new Vector2(ScreenManager.GraphicsDevice.Viewport.Width / 2 - gameFont.MeasureString("Insert Gameplay Here").X / 2, 200);

                enemyPosition = Vector2.Lerp(enemyPosition, targetPosition, 0.05f);

                // TODO: this game isn't very fun! You could probably improve
                // it by inserting something more interesting in this space :-)

                current = Keyboard.GetState();
                Camera.Update(current);


                // TODO: Add your update logic here
                nerd.Update(gameTime);
                target.Update(gameTime);



                Vector2 aDirection = new Vector2(-1, 0);
                Vector2 aSpeed = new Vector2(160, 0);

            }



   
           


            //base.Update(gameTime);
        
        }


        /// <summary>
        /// Lets the game respond to player input. Unlike the Update method,
        /// this will only be called when the gameplay screen is active.
        /// </summary>
        public override void HandleInput(InputState input)
        {
            if (input == null)
                throw new ArgumentNullException("input");

            // Look up inputs for the active player profile.
            int playerIndex = (int)ControllingPlayer.Value;

            KeyboardState keyboardState = input.CurrentKeyboardStates[playerIndex];
            GamePadState gamePadState = input.CurrentGamePadStates[playerIndex];

            // The game pauses either if the user presses the pause button, or if
            // they unplug the active gamepad. This requires us to keep track of
            // whether a gamepad was ever plugged in, because we don't want to pause
            // on PC if they are playing with a keyboard and have no gamepad at all!
            bool gamePadDisconnected = !gamePadState.IsConnected &&
                                       input.GamePadWasConnected[playerIndex];

            if (input.IsPauseGame(ControllingPlayer) || gamePadDisconnected)
            {
                ScreenManager.AddScreen(new PauseMenuScreen(), ControllingPlayer);
            }
            else
            {
                // Otherwise move the player position.
                Vector2 movement = Vector2.Zero;

                if (keyboardState.IsKeyDown(Keys.Left))
                    movement.X--;

                if (keyboardState.IsKeyDown(Keys.Right))
                    movement.X++;

                if (keyboardState.IsKeyDown(Keys.Up))
                    movement.Y--;

                if (keyboardState.IsKeyDown(Keys.Down))
                    movement.Y++;

                Vector2 thumbstick = gamePadState.ThumbSticks.Left;

                movement.X += thumbstick.X;
                movement.Y -= thumbstick.Y;

                if (movement.Length() > 1)
                    movement.Normalize();

                playerPosition += movement * 2;
            }
        }







        /// <summary>
        /// Draws the gameplay screen.
        /// </summary>
        public override void Draw(GameTime gameTime)
        {
         

            
            SpriteBatch spriteBatch = ScreenManager.SpriteBatch;
           
            spriteBatch.Begin();
            //piirret‰‰n nˆrtti ja tausta.. t‰h‰n voisi v‰‰nt‰‰ sellaisen systeemin ett‰ pistet‰‰n kaikki piirrett‰v‰t systeemit listaan ja iteroidaan niille piirtofunktio
            
            mBackgroundOne.Draw(spriteBatch);
            nerd.Draw(spriteBatch);
            target.Draw(spriteBatch);

            spriteBatch.End();




            // If the game is transitioning on or off, fade it out to black.
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
