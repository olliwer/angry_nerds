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
        public int value;
        Vector2 sikaPosition;
        public Rectangle sikaRectangle;
        public bool sikaHit = false;

 
        public void LoadContent(ContentManager theContentManager, int x, int y)
        {
            Position = new Vector2(x, y);
            base.LoadContent(theContentManager, "birdy");
            sikaPosition.X = x;
            sikaPosition.Y = y;
            sikaRectangle = new Rectangle((int)sikaPosition.X, (int)sikaPosition.Y, 50, 100);

        }

        public void Update(GameTime theGameTime)
        {

            Position = sikaPosition;
        }
    }


}
