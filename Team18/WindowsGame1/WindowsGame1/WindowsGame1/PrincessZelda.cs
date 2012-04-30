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
    class PrincessZelda : AnimatedSprite
    {
        const string CHARACTER_ASSETNAME = "Zelda1";
        const int START_POSITION_X = 700;
        const int START_POSITION_Y = 300;
        const int CHARACTER_SPEED = 140;
        const int MOVE_UP = -1;
        const int MOVE_DOWN = 1;
        const int MOVE_LEFT = -1;
        const int MOVE_RIGHT = 1;
        Vector2 TargetPos;
        Vector2 LastPosition1;
        Vector2 LastPosition2;
        Vector2 LastDecision = new Vector2(0, 0);
        Vector2 StuckedDecision = new Vector2(0, 0);


        //State Indicating Character status
        enum State
        {
            Walking, Chasing, Stationary
        }

        //GameState indicate Zelda to wait the player or Chase the player
        public enum GameState
        {
            Escape, Waiting
        }

        //CharacterStatus indicate if player plays(1), moves to next level(2),
        //Or win the game(3), lose(4). First, set as playing.
        private int characterStatus = 1;

        public int status
        {
            get { return characterStatus; }
            set { characterStatus = value; }
        }

        State mCurrentState = State.Walking;

        //Zrlda may wait for player or follow the player
        public GameState gState = GameState.Escape;

        //Direction and Speed are used for character movement
        Vector2 mDirection = Vector2.Zero;
        Vector2 mSpeed = Vector2.Zero;

        //TargetPosition is usually player position
        public Vector2 TargetPosition
        {
            get { return TargetPos; }
            set { TargetPos = value; }
        }


        //LoadCcontent from texture
        public void LoadContent(ContentManager theContentManager)
        {
            pos = new Vector2(START_POSITION_X, START_POSITION_Y);
            base.LoadContent(theContentManager, CHARACTER_ASSETNAME);
        }


        //Update positon with some movement
        public void ZeldaUpdate(GameTime theGameTime)
        {
            UpdateMovement();
            LastDecision = mDirection;
            LastPosition2 = pos; // Before Move
            base.Update(theGameTime, mSpeed, mDirection);
            LastPosition1 = pos; // After Move
        }

        //UpdateMovement will detect inputs, then assign speed and direction
        //Enemy AI function included
        private void UpdateMovement()
        {
            currentRow = 1;

            mSpeed = Vector2.Zero;
            mDirection = Vector2.Zero;

            if (gState == GameState.Escape)
            {

                //Keep last moving decision for stucking
                if (LastDecision.X != 0)
                    StuckedDecision.X = LastDecision.X;
                if (LastDecision.Y != 0)
                    StuckedDecision.Y = LastDecision.Y;

                //Position did not change before movement that
                //indicating stuck on object, state goes to stationary
                //Then, use last 2 dimentional move to get out from stuck
                if (LastPosition2 == pos)
                {
                    mCurrentState = State.Stationary;
                    mSpeed = new Vector2(CHARACTER_SPEED, CHARACTER_SPEED);
                    mDirection = StuckedDecision;
                }

                //Position is same as the after move. Successfuly moved.
                //Indicating got out from stuck, change state to walking
                if (LastPosition1 == pos)
                    mCurrentState = State.Walking;

                //Close enought to player
                if (pos.X <= TargetPos.X + 15 * 1.7f && pos.X >= TargetPos.X - 35 * 1.7f
                        && pos.Y <= TargetPos.Y + 15 * 1.7f && pos.Y >= TargetPos.Y - 45 * 1.7f)
                {
                    currentRow = 1;
                    mSpeed = Vector2.Zero;
                    mDirection = Vector2.Zero;
                }
                else if (mCurrentState != State.Stationary)
                {
                    if (pos.X > TargetPos.X - 15)
                    {
                        currentRow = 0;
                        mSpeed.X = CHARACTER_SPEED;
                        mDirection.X = MOVE_LEFT;
                    }
                    else if (pos.X <= TargetPos.X -12 && pos.X >= TargetPos.X - 18)
                    {
                        //DO NOTHING
                    }
                    else
                    {
                        currentRow = 4;
                        mSpeed.X = CHARACTER_SPEED;
                        mDirection.X = MOVE_RIGHT;
                    }

                    if (pos.Y > TargetPos.Y - 15)
                    {
                        currentRow = 2;
                        mSpeed.Y = CHARACTER_SPEED;
                        mDirection.Y = MOVE_UP;
                    }
                    else if (pos.Y <= TargetPos.Y -12 && pos.Y >= TargetPos.Y - 18)
                    {
                        //DO NOTHING
                    }               
                    else
                    {
                        currentRow = 1;
                        mSpeed.Y = CHARACTER_SPEED;
                        mDirection.Y = MOVE_DOWN;
                    }                   
                }

                if (characterStatus == 4)
                {
                    currentRow = 3;
                    mSpeed = Vector2.Zero;
                    mDirection = Vector2.Zero;
                    mCurrentState = State.Walking;
                }

                if (characterStatus == 5)
                {
                    currentRow = 1;
                    mSpeed = Vector2.Zero;
                    mDirection = Vector2.Zero;
                    mCurrentState = State.Walking;
                }


            }
        }

    }
}
