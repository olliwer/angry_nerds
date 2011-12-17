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
    class Sika : Sprite
    {
        int positionX;
        int positionY;
        public static Vector2 sikaPosition;
        public Rectangle sikaRectangle = new Rectangle((int)sikaPosition.X, (int)sikaPosition.Y, 5, 6);
        public bool sikaHit = false;

 
        public void LoadContent(ContentManager theContentManager, int x, int y)
        {
            Position = new Vector2(positionX, positionY);
            base.LoadContent(theContentManager, "birdy");
            sikaPosition.X = x;
            sikaPosition.Y = y;

        }

        public void Update(GameTime theGameTime)
        {

            Position = sikaPosition;
        }
    }


}
