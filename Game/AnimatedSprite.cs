using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    class AnimatedSprite : Sprite
    {
        float timer = 0f;
        float interval = 200f;
        int currentFrame = 0;
        int spriteWidth = 32;
        int spriteHeight = 48;
        int spriteSpeed;
        Rectangle sourceRect;
        Vector2 origin;

        public AnimatedSprite()
        {
        }

        public void HandleSourceRect(GameTime gameTime)
        {

            sourceRect = new Rectangle(currentFrame * spriteWidth, 0, spriteWidth, spriteHeight);                

            origin = new Vector2(sourceRect.Width / 2, sourceRect.Height / 2);
        }



        public Vector2 Position
        {
            get { return pos; }
            set { pos = value; }
        }

        public Vector2 Origin
        {
            get { return origin; }
            set { origin = value; }
        }

        public Texture2D Texture
        {
            get { return tex; }
            set { tex = value; }
        }

        public Rectangle SourceRect
        {
            get { return sourceRect; }
            set { sourceRect = value; }
        }


    }
}
