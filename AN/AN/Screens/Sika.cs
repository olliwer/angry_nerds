using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

/*
 * Sika is the class for the targets.
 */
namespace AN
{
    class Sika : Sprite
    {
        public int value = 0;
        Vector2 sikaPosition;
        public Rectangle sikaRectangle;
        public bool sikaHit = false;

 
        public void LoadContent(ContentManager theContentManager, int x, int y, String assetName)
        {
            Position = new Vector2(x, y);
            base.LoadContent(theContentManager, assetName, x, y);
            sikaPosition.X = x;
            sikaPosition.Y = y;
        }

        public void hit(GameTime theGameTime){
            Position = new Vector2(sikaPosition.X, sikaPosition.Y);
            sikaHit = true;
            base.Update(theGameTime, 1, Position);
    
        }

        public void Update(GameTime theGameTime)
        {
            if (sikaHit == true)
            {
                base.Update(theGameTime, 3, Position);
                sikaPosition.X--;
                sikaPosition.Y--;
            }

            Position = sikaPosition;
            sikaRectangle = new Rectangle((int)sikaPosition.X, (int)sikaPosition.Y, 20, 60);
        }
    }


}
