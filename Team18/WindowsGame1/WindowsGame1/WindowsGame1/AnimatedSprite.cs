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
        //Sprite Texture
        Texture2D sprite;
        //A Timer variable
        //float timer = 0f;
        //The interval (100 milliseconds)
        float interval  = 250f;
        //Current frame holder (start at 1)
        int currentFrame = 1;
      public  int currentRow;
        //Width of a single sprite image, not the whole Sprite Sheet
        int frameWidth ;
        //Height of a single sprite image, not the whole Sprite Sheet
        int frameHeight;
        //A rectangle to store which 'frame' is currently being shown
        int NumberOfFrames;
        // Rectangle sourceRect;
        //The centre of the current 'frame'
        Vector2 origin;

        //Direction and Speed are used for character movement
        Vector2 mDirection = Vector2.Zero;
        Vector2 mSpeed = Vector2.Zero;
       // const string CHARACTER_ASSETNAME = "Player_SpriteSheet";
       public AnimatedSprite()
       {
       
       
       
       
       
       }
       public void Animation(ContentManager content, string assetName, int spriteWidth, int spriteHeight, int numberOfFrames)
       
        {
            sprite = content.Load<Texture2D>(assetName);
            frameWidth = spriteWidth; 
            frameHeight = spriteHeight ;
           // framesPerRow = sprite.Width / frameWidth;
           // fps = framesPerSecond;
           // FPSDisplay = asset + " FPS:  " + fps.ToString();
            NumberOfFrames = numberOfFrames;
           // repeating = false;
            //delayed = false;
         
        }

        public void HandleSourceRect(GameTime gameTime)
        {

            //Increase the timer by the number of milliseconds since update was last called
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
             //Check the timer is more than the chosen interval
            if (timer > interval)
            {
                //Show the next frame
                currentFrame++;
                //Reset the timer
                timer = 0f;
            }
            //If we are on the last frame, reset back to the one before the first frame (because currentframe++ is called next so the next frame will be 1!)
            if (currentFrame == NumberOfFrames)
            {
                currentFrame = 0;
            }
            if (currentRow == 0) 
            {   

               
                sourceRect = new Rectangle(currentFrame * frameWidth, frameHeight*currentRow, frameWidth, frameHeight);
                origin = new Vector2(sourceRect.Width / 2, sourceRect.Height / 2);
            
            }
            if (currentRow == 1)
            {
               // currentRow = frameHeight*2;
                sourceRect = new Rectangle(currentFrame * frameWidth, frameHeight * currentRow, frameWidth, frameHeight);
               origin = new Vector2(sourceRect.Width / 2, sourceRect.Height / 2);
            

            }
            if (currentRow == 2)
            {
                sourceRect = new Rectangle(currentFrame * frameWidth, frameHeight * currentRow, frameWidth, frameHeight);
                origin = new Vector2(sourceRect.Width / 2, sourceRect.Height / 2);

            }
            if (currentRow == 3)
            {
                sourceRect = new Rectangle(currentFrame * frameWidth, frameHeight * currentRow, frameWidth, frameHeight);
                origin = new Vector2(sourceRect.Width / 2, sourceRect.Height / 2);

            }
            if (currentRow == 4)
            {
                sourceRect = new Rectangle(currentFrame * frameWidth, frameHeight * currentRow, frameWidth, frameHeight);
                origin = new Vector2(sourceRect.Width / 2, sourceRect.Height / 2);

            }
        //base.Update(gameTime);
           base.Update(gameTime, mSpeed, mDirection);
        }

        public void animateDraw(SpriteBatch theSpriteBatch)
        {
           
            
             theSpriteBatch.Draw(tex, pos,
               sourceRect,
               Color.White, 0.0f, Vector2.Zero, Scale, SpriteEffects.None, 0);
        
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

        //public Rectangle SourceRect
        //{
        //    get { return sourceRect; }
        //    set { sourceRect = value; }
        //}
       

    }
}
