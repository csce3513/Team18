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
    class Character : AnimatedSprite
    {
        const string CHARACTER_ASSETNAME = "Player";
        const int START_POSITION_X = 400;
        const int START_POSITION_Y = 250;
        const int CHARACTER_SPEED = 150;
        const int MOVE_UP = -1;
        const int MOVE_DOWN = 1;
        const int MOVE_LEFT = -1;
        const int MOVE_RIGHT = 1;

        //CharacterStatus indicate if player plays(1), moves to next level(2),
        //Or win the game(3), lose(4). First, set as playing.
        
        private int characterStatus = 1;

        public int status
        {
            get { return characterStatus; }
            set { characterStatus = value; }
        }

      //  AnimatedSprite Animate = new AnimatedSprite();
      //  public int currentRow;
     
        //State Indicating Character status
        enum State
        {
            Walking, Running, Stationary
        }

        State mCurrentState = State.Walking;

        //Direction and Speed are used for character movement
        Vector2 mDirection = Vector2.Zero;
        Vector2 mSpeed = Vector2.Zero;

        KeyboardState mPreviousKeyboardState;

        //LoadCcontent from texture
        public void LoadContent(ContentManager theContentManager)
        {
            pos = new Vector2(START_POSITION_X, START_POSITION_Y);
            base.LoadContent(theContentManager, CHARACTER_ASSETNAME);
        }

        //Update positon with some movement
        public void CharacterUpdate(GameTime theGameTime)
        {
            KeyboardState aCurrentKeyboardState = Keyboard.GetState();

            UpdateMovement(aCurrentKeyboardState);

            mPreviousKeyboardState = aCurrentKeyboardState;

      
            base.Update(theGameTime, mSpeed, mDirection);
        }

        //UpdateMovement will detect inputs, then assign speed and direction
        private void UpdateMovement(KeyboardState aCurrentKeyboardState)
        {
            if (mCurrentState == State.Walking)
            {
                mSpeed = Vector2.Zero;
                mDirection = Vector2.Zero;

                currentRow = 0;

                if (aCurrentKeyboardState.IsKeyDown(Keys.Left) == true)
                {
                    currentRow = 3;
                    mSpeed.X = CHARACTER_SPEED;
                    mDirection.X = MOVE_LEFT;
                }
                else if (aCurrentKeyboardState.IsKeyDown(Keys.Right) == true)
                {
                    currentRow = 1;
                    mSpeed.X = CHARACTER_SPEED;
                    mDirection.X = MOVE_RIGHT;
                }

                if (aCurrentKeyboardState.IsKeyDown(Keys.Up) == true)
                {
                    currentRow = 2;
                    mSpeed.Y = CHARACTER_SPEED;
                    mDirection.Y = MOVE_UP;
                }
                else if (aCurrentKeyboardState.IsKeyDown(Keys.Down) == true)
                {
                    currentRow = 0;
                    mSpeed.Y = CHARACTER_SPEED;
                    mDirection.Y = MOVE_DOWN;
                }
                
            }

            if (characterStatus == 4)
            {
                currentRow = 4;
                mSpeed = Vector2.Zero;
                mDirection = Vector2.Zero;                
            }

            if (characterStatus == 5)
            {
                currentRow = 5;
                mSpeed = Vector2.Zero;
                mDirection = Vector2.Zero; 
            }

            if (characterStatus == 6)
            {
                currentRow = 0;
                mSpeed = Vector2.Zero;
                mDirection = Vector2.Zero;
            }

        }

       

    }
}
