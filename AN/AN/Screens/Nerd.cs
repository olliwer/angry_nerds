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
        public int positionX;
        public int positionY;
        const int NERD_SPEED = 160;

        Boolean painettuna = false;
        Boolean ammuttu = false;
        Boolean maassa = false;
        Vector2 mouseStart;
        Vector2 mouseEnd;
        public static Vector2 nerdPosition;
        Vector2 liike;

        float vauhti = 0;
        double aika = 0;
		int testi;

       public  Boolean osui = false; //checks if game is in state where it should move to next level.

        //Luodaan nerdin ympärille rectangle, jolla toteutetaan osuminen.
        public Rectangle nerdRectangle = new Rectangle((int)nerdPosition.X, (int)nerdPosition.Y, 5, 6);



        Vector2 mDirection = Vector2.Zero;
        Vector2 mSpeed = Vector2.Zero;

        KeyboardState mPreviousKeyboardState;
        
        #endregion

        #region load

        public void LoadContent(ContentManager theContentManager, int x, int y)
        {
            Position = new Vector2(positionX, positionY);
            base.LoadContent(theContentManager, "tux");
            nerdPosition.X = x;
            nerdPosition.Y = y;

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
                // Effect for shooting tux. now tux doesnt move as much as mouse, so it maybe feels little bit more like pulling a sling.            
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
            if (ammuttu == true && maassa == true)
            {

            }
         
        }      
        private void laskeliike()
        {
            liike.X = Math.Abs(mouseStart.X - mouseEnd.X)/8;
            liike.Y = Math.Abs(mouseStart.Y - mouseEnd.Y)/8;     
        }
        private void laskeAmmuksenLentorata()
        {                         
            double painovoimakiihtyvyys = 2;

            nerdPosition.Y = (int)(-(liike.Y * aika) + 645 + (aika * aika * painovoimakiihtyvyys));           
            nerdPosition.X = (int)(liike.X * aika+125);           

           //kertoo ammuksen nopeuden ajan suhteen. tämän voisi fixata toimimaan gametimen perusteella, mutta on nyt vakio testausta varten
           aika= (aika+0.16);

           //onko ammus maassa?
           if (nerdPosition.Y > 700)
           {
               maassa = true;
               nerdPosition.Y = 700;
           }
        }

        public void toNextLevel(){
           // GameplayScreen.nextlevel();

        }


        #endregion

    }
}
