using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace WindowsGame1
{
    class Sprite
    {
 
        //The current position of the Sprite
        protected Vector2 pos = new Vector2(0, 0);

        //The texture object used when drawing the sprite
        protected Texture2D tex;

        //The asset name for the Sprite's Texture
        public string assetName;

        //The Size of the Sprite (with scale applied)
        public Rectangle size;

        //The amount to increase/decrease the size of the original sprite. 
        private float mScale = 1.0f;
        

        //When the scale is modified through the property, the Size of the 
        //sprite is recalculated with the new scale applied.
        public float Scale
        {
            get { return mScale; }
            set
            {
                mScale = value;
                //Recalculate the Size of the Sprite with the new scale
                size = new Rectangle(0, 0, (int)(tex.Width * Scale), (int)(tex.Height * Scale));
            }
        }


        public void LoadContent(ContentManager theContentManager, string theAssetName)
        {
            tex = theContentManager.Load<Texture2D>(theAssetName);
            assetName = theAssetName;
            size = new Rectangle(0, 0, (int)(tex.Width * Scale), (int)(tex.Height * Scale));
        }

        //Update the Sprite and change it's position based on the passed in speed, direction and elapsed time.
        public void Update(GameTime theGameTime, Vector2 theSpeed, Vector2 theDirection)
        {
            pos += theDirection * theSpeed * (float)theGameTime.ElapsedGameTime.TotalSeconds;
        }

        //Draw the sprite to the screen
        public void Draw(SpriteBatch theSpriteBatch)
        {
            theSpriteBatch.Draw(tex, pos,
                new Rectangle(0, 0, tex.Width, tex.Height),
                Color.White, 0.0f, Vector2.Zero, Scale, SpriteEffects.None, 0);
        }

        public void updatePos(Vector2 newPos)
        {
            pos = newPos;
        }

        internal void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }


        //For testing
        public Vector2 getPos()
        {
            return pos;
        }

        //For testing
        public Texture2D getTex()
        {
            return tex;
        }
    }
}
