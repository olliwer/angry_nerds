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
        const int START_POSITION_X = 600;
        const int START_POSITION_Y = 500;
        public static Vector2 sikaPosition;
        public static Rectangle sikaRectangle = new Rectangle((int)sikaPosition.X, (int)sikaPosition.Y, 50, 60);


        public void LoadContent(ContentManager theContentManager)
        {
            Position = new Vector2(START_POSITION_X, START_POSITION_Y);
            base.LoadContent(theContentManager, "birdy");
            sikaPosition.X = START_POSITION_X;
            sikaPosition.Y = START_POSITION_Y;

        }

        public void Update(GameTime theGameTime)
        {
            Position = sikaPosition;
        }
    }


}
