﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    class Dragon : AnimatedSprite
    {
        const string CHARACTER_ASSETNAME = "finalflyingdragon";
        const int START_POSITION_X = 600;
        const int START_POSITION_Y = 250;
        const int CHARACTER_SPEED = 120;
        const int MOVE_UP = -1;
        const int MOVE_DOWN = 1;
        const int MOVE_LEFT = -1;
        const int MOVE_RIGHT = 1;
        Vector2 TargetPos = new Vector2(-999, -999);
        Vector2 LastPosition1;
        Vector2 LastPosition2;
        Vector2 LastDecision = new Vector2(0, 0);
        Vector2 StuckedDecision = new Vector2(0, 0);


        //State Indicating Character status
        enum State
        {
            Walking, Chasing, Stationary
        }

        State mCurrentState = State.Walking;

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
        public void EnemyUpdate(GameTime theGameTime)
        {
            UpdateMovement();
            LastDecision = mDirection;
            LastPosition2 = pos;
            base.Update(theGameTime, mSpeed, mDirection);
            LastPosition1 = pos;
         }

        //UpdateMovement will detect inputs, then assign speed and direction
        //Enemy AI function included
        private void UpdateMovement()
        {
           
                mSpeed = Vector2.Zero;
                mDirection = Vector2.Zero;

                //Keep last moving decision for stucking
                if (LastDecision.X != 0)
                    StuckedDecision.X = LastDecision.X;
                if (LastDecision.Y != 0)
                    StuckedDecision.Y = LastDecision.Y;

                //Indicating stuck on object, state goes to stationary
                //Then, use last 2 dimentional move to get out from stuck
                if (LastPosition2 == pos)
                {
                    mCurrentState = State.Stationary;
                    mSpeed = new Vector2(CHARACTER_SPEED, CHARACTER_SPEED);
                    mDirection = StuckedDecision;
                }

                //Indicating got out from stuck, change state to walking
                if (LastPosition1 == pos && LastDecision != Vector2.Zero)
                    mCurrentState = State.Walking;
                    

                //Position -999, -999 means no target found, stay on or move to its post
                if (TargetPosition == new Vector2(-999, -999))
                {
                    
                    //On the post, no movement needed
                    if (pos.X <= START_POSITION_X+5 && pos.Y <= START_POSITION_Y +5
                        && pos.X >= START_POSITION_X - 5 && pos.Y >= START_POSITION_Y - 5)
                    {
                        mSpeed = Vector2.Zero;
                        mDirection = Vector2.Zero;
                    }
                    //Out from post, need to go back to the post
                    //Obtain difference from the first Post, then move close to there
                    else if (mCurrentState != State.Stationary)
                    {
                        //Need some modification +2 or +1 to avoid moving back and forward in short time
                        if (pos.X > START_POSITION_X+2)
                        {
                            currentRow = 1;
                            mSpeed.X = CHARACTER_SPEED;
                            mDirection.X = MOVE_LEFT;
                        }
                        else if (pos.X <= START_POSITION_X + 2 && pos.X >= START_POSITION_X - 2)
                        {
                            //DO NOTHING
                        }
                        else
                        {
                            currentRow = 2;
                            mSpeed.X = CHARACTER_SPEED;
                            mDirection.X = MOVE_RIGHT;
                        }
                 
                        if (pos.Y > START_POSITION_Y +2)
                        {
                            currentRow = 3;
                            mSpeed.Y = CHARACTER_SPEED;
                            mDirection.Y = MOVE_UP;
                        }
                        else if (pos.Y <= START_POSITION_Y + 2 && pos.Y >= START_POSITION_Y - 2)
                        {
                            //DO NOTHING
                        }
                        else
                        {
                            currentRow = 0;
                            mSpeed.Y = CHARACTER_SPEED;
                            mDirection.Y = MOVE_DOWN;
                        }
                        
                    }

                }
                else //Found target and chase
                {
                    mCurrentState = State.Chasing;

                    if (pos.X > TargetPos.X - 40)
                    {
                        currentRow = 1;
                        mSpeed.X = CHARACTER_SPEED;
                        mDirection.X = MOVE_LEFT;
                    }
                    else if (pos.X <= TargetPos.X - 37 && pos.X >= TargetPos.X - 43)
                    {
                        //DO NOTHING
                    }
                    else
                    {
                        currentRow = 2;
                        mSpeed.X = CHARACTER_SPEED;
                        mDirection.X = MOVE_RIGHT;
                    }

                    if (pos.Y > TargetPos.Y - 40)
                    {
                        currentRow = 3;
                        mSpeed.Y = CHARACTER_SPEED;
                        mDirection.Y = MOVE_UP;
                    }
                    else if (pos.Y <= TargetPos.Y - 37 && pos.Y >= TargetPos.Y - 43)
                    {
                        //DO NOTHING
                    }
                    else
                    {
                        currentRow = 0;
                        mSpeed.Y = CHARACTER_SPEED;
                        mDirection.Y = MOVE_DOWN;
                    }
                    
                }

            }
    }
}
