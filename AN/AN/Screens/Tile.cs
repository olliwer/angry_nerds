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
        public bool sikaHit = false;


        public void LoadContent(ContentManager theContentManager, int x, int y, String assetName)
        {
            Position = new Vector2(x, y);
            base.LoadContent(theContentManager, assetName, x, y);
            tilePosition.X = x;
            tilePosition.Y = y;
        }

        public void Update(GameTime theGameTime)
        {
            tileRectangle = new Rectangle((int)tilePosition.X, (int)tilePosition.Y, 5, 6);
        }
    }
}
