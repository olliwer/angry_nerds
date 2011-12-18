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
    class Tile : Sprite
    {
        Vector2 tilePosition;
        public Rectangle tileRectangle;
        public bool tileHit = false;
        public int positionY;

        public void LoadContent(ContentManager theContentManager, int x, int y, String assetName)
        {
            Position = new Vector2(x, y);
            base.LoadContent(theContentManager, assetName, x, y);
            tilePosition.X = x;
            tilePosition.Y = y;
        }

 
        public void reset(GameTime theGameTime)
        {
            tileHit = true;
            Position = new Vector2(tilePosition.X, tilePosition.Y);
            base.Update(theGameTime, 1, Position);
            positionY = (int)tilePosition.Y;
        }

        public void Update(GameTime theGameTime)
        {
            if (tileHit == true)
            {
                base.Update(theGameTime, 1, Position);
                
                //Position = new Vector2(-100, -100);
            }

            tileRectangle = new Rectangle((int)tilePosition.X, (int)tilePosition.Y, 20, 10);
        }
    }
}
