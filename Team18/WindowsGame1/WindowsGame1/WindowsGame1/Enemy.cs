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
    class EnemyCharacter : AnimatedSprite
    {
        const string CHARACTER_ASSETNAME = "Enemy";
        const int START_POSITION_X = 600;
        const int START_POSITION_Y = 250;
        const int CHARACTER_SPEED = 100;
        const int MOVE_UP = -1;
        const int MOVE_DOWN = 1;
        const int MOVE_LEFT = -1;
        const int MOVE_RIGHT = 1;

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
        public void Update(GameTime theGameTime)
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

                if (aCurrentKeyboardState.IsKeyDown(Keys.Left) == true)
                {
                    mSpeed.X = CHARACTER_SPEED;
                    mDirection.X = MOVE_LEFT;
                }
                else if (aCurrentKeyboardState.IsKeyDown(Keys.Right) == true)
                {
                    mSpeed.X = CHARACTER_SPEED;
                    mDirection.X = MOVE_RIGHT;
                }

                if (aCurrentKeyboardState.IsKeyDown(Keys.Up) == true)
                {
                    mSpeed.Y = CHARACTER_SPEED;
                    mDirection.Y = MOVE_UP;
                }
                else if (aCurrentKeyboardState.IsKeyDown(Keys.Down) == true)
                {
                    mSpeed.Y = CHARACTER_SPEED;
                    mDirection.Y = MOVE_DOWN;
                }
            }
        }



    }
}
