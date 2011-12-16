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
        const int START_POSITION_Y = 645;
        const int NERD_SPEED = 160;

        Boolean painettuna = false;
        Boolean ammuttu = false;
        Boolean maassa = false;
        Vector2 mouseStart;
        Vector2 mouseEnd;
        public static Vector2 nerdPosition;
        Vector2 liike;

        float vauhti = 0;
        double aika = -5;
		int testi;

       public  Boolean osui = false; //checks if game is in state where it should move to next level.

        //Luodaan nerdin ympärille rectangle, jolla toteutetaan osuminen.
        public static Rectangle nerdRectangle = new Rectangle((int)nerdPosition.X, (int)nerdPosition.Y, 50, 60);



        enum State
        {
            Walking
        }

        Vector2 mDirection = Vector2.Zero;
        Vector2 mSpeed = Vector2.Zero;

        KeyboardState mPreviousKeyboardState;
        
        #endregion

        #region load

        public void LoadContent(ContentManager theContentManager)
        {
            Position = new Vector2(START_POSITION_X, START_POSITION_Y);
            base.LoadContent(theContentManager, "tux");
            nerdPosition.X = START_POSITION_X;
            nerdPosition.Y = START_POSITION_Y;

        }

        #endregion

        #region UpdateMethods

        public void Update(GameTime theGameTime)
        {
            KeyboardState aCurrentKeyboardState = Keyboard.GetState();
            MouseState aCurrentMouseState = Mouse.GetState();

            UpdateMouseMovement(aCurrentMouseState);
            Position = nerdPosition;
            mPreviousKeyboardState = aCurrentKeyboardState;

            //base.Update(theGameTime, mSpeed, mDirection);
        }

  
        

        //Checks mouse movements for shooting Nerd
        private void UpdateMouseMovement(MouseState aCurrentMouseState)
        {

            //jos hiiren vasen namikka alhaalla, niin aloitetaan virittäminen
            if (aCurrentMouseState.LeftButton == ButtonState.Pressed && painettuna == false && ammuttu ==false)
            {
                //sets mouse start position 
                mouseStart.X = aCurrentMouseState.X;
                mouseStart.Y = aCurrentMouseState.Y;

                //sets nerds start position
                nerdPosition.X = aCurrentMouseState.X;
                nerdPosition.Y = aCurrentMouseState.Y;

                painettuna = true;
            }


            // kun hiirin vasen namikka päästetään
            if (aCurrentMouseState.LeftButton == ButtonState.Released && painettuna == true && ammuttu == false)
            {
                mouseEnd.X = aCurrentMouseState.X;
                mouseEnd.Y = aCurrentMouseState.Y;

                painettuna = false;
                ammuttu = true;
                laskeliike();
            }

            //vielä yksi metodi lisää jossa painettuna on true, jotta saadaan nörtti liikkumaan hiiren mukana kun nappi painettuna
            if (aCurrentMouseState.LeftButton == ButtonState.Pressed && painettuna == true && ammuttu == false)
            {
                //nerdPosition.X = aCurrentMouseState.X;
                // Effect for shotoin tux. now tux doesnt move as much as mouse, so its maybe feels little bit more like pulling a sling.            
                int apuX = (int)(mouseStart.X - aCurrentMouseState.X)/2; // venymis efekti linkoon, jos halutaan että se on linko D: Voisi korvata jollain jännällä neliöjuurifunktiolla, jotta muutos menisi jossain kohti lähelle nollaa
                nerdPosition.X = mouseStart.X - apuX;
                if (nerdPosition.X > mouseStart.X) nerdPosition.X = mouseStart.X; // katsotaan ettei voi venytellä nerdiä kuin alas ja vasemmalla

                //nerdPosition.Y = aCurrentMouseState.Y;
                int apuY = (int)(aCurrentMouseState.Y - mouseStart.Y) / 2; 
                nerdPosition.Y = mouseStart.Y + apuY;
                
                if (nerdPosition.Y < mouseStart.Y) nerdPosition.Y = mouseStart.Y;
            }

            if ( ammuttu == true && maassa ==false)
            {
                laskeAmmuksenLentorata();
                    
            }
         
        }


        private void laskeliike()
        {
            liike.X = Math.Abs(mouseStart.X - mouseEnd.X)/5;
            liike.Y = Math.Abs(mouseStart.Y - mouseEnd.Y)/5;
            
         
        }

        private void laskeAmmuksenLentorata()
        {

            
            double x = 0;
            double y = 0;
            
            double painovoimakiihtyvyys = 0.98;
            liike.X = 2; //kertoo kuinka jyrkästi x-akselin suuntaan ammus lähtee.. mitä isompi niin sitä jyrkempi
            liike.Y = 30; //kertoo kuinka jyrkkään y akselin suuntaan ammus lähtee.. mitä pienempi arvo niin sitä jyrkempi

            int apuX = 0; //HelpIntegers to define angle of shot
            int apuY = 0;

            apuX  = (int)(mouseStart.X - mouseEnd.X) / 80;
            liike.X = apuX;

            apuY = (int)(mouseEnd.Y - mouseStart.Y)/2;
            liike.Y = apuY;

            // Ammuksen lentorata on paraabeli, jonka y-arvo lasketaan kaavalla:
            //y = t * ut
            x = ((liike.X * aika) * aika)+645;

            // ja x-arvo lasketaan kaavalla:
            y =  (painovoimakiihtyvyys * (aika * aika)) + (liike.Y * aika )-400 ;

           nerdPosition.Y = (int)x + mouseEnd.X;
           nerdPosition.X = (int)(y + mouseEnd.Y);


           //kertoo ammuksen nopeuden ajan suhteen. tämän voisi fixata toimimaan gametimen perusteella, mutta on nyt vakio testausta varten
           aika= (aika+0.08);

            //tähän pitäisi hahmotella jokin systeemi huomaamaan jos ammus on jo maassa.
           if (nerdPosition.Y == 800) maassa = true;
       
        }

        public void toNextLevel(){
           // GameplayScreen.nextlevel();

        }


        #endregion

    }
}
