using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;


namespace WindowsGame1
{

    //ActionHandler Detects Collision and Check Visivility of Enemy

    class ActionHandler
    {
        //PosList indicate Position of each item
        private Vector2[] posList = new Vector2[20];

        //IDlist indicate each ID
        private int[] IDList = new int[20];

        //Height and Width list indicate height and width of object
        private float[] HeightList = new float[20];
        private float[] WidthList = new float[20];

        //InGame indicate if the item is in the game
        private bool[] InGame = new bool[20];
        
        //CharacterStatus indicate if player plays(1), moves to next level(2),
        //Or win the game(3), lose(4). First, set as playing.
        private int CharacterStatus = 1;
        
        //Sprite Size
        int size = 0;

        //BoundaryDetection
        bool Boundary;

        

        //Default Constructor
        public ActionHandler()
        {

        }

        public int CharaceterState
        {
            get { return CharacterStatus; }
            set { CharacterStatus = value; }
        }
 
        //Adding Object
        public void addObject(Vector2 Pos, int ID, float Width, float Height)
        {
            posList[size] = Pos;
            IDList[size] = ID;
            HeightList[size] = Height;
            WidthList[size] = Width;
            InGame[size] = true;
            size++;
        }

        //Ignore the item from Collision Detection
        public void IgnoreObject(int ID)
        {
            InGame[FindSprite(ID)] = false;
        }

        //Put object into Collision Detection
        public void RecognizeObject(int ID)
        {
            InGame[FindSprite(ID)] = true;
        }


        //Position Update
        public void UpdatePos(int ID, Vector2 pos)
        {
            posList[FindSprite(ID)] = pos;
        }

        //May not need
        public double getWidth(int ID)
        {
            return WidthList[FindSprite(ID)];
        }
        //May not need 
        public double getHeight(int ID)
        {
            return HeightList[FindSprite(ID)];
        }
        //May not need 
        public Vector2 getPos(int ID)
        {
            return posList[FindSprite(ID)];
        }



        //Collision checker will check all of object with assigned object
        //When Collision detected, return vector2 that indicating how far intercepted
        public Vector2 CollisionCheck(int ID)
        {
            Vector2 status = new Vector2(0, 0);
            Vector2 Detection = new Vector2(0,0);

            int SubjectNum = FindSprite(ID);

            for (int i = 0; i < size; i++)
                if (i != SubjectNum && InGame[i] && 202 != ID)
                {
                    if (status.X != 0 && status.Y != 0)
                        return status;

                    Boundary = false;
                    Detection = CollisionDetect(SubjectNum, i);

                    if (Detection != new Vector2(0, 0))
                    {
                        //No boundaryCollision included
                        if (!Boundary)
                        {
                            //Collide with emeny means LOSE
                            //ID indicate Enemy, Subject has to be Character
                            if (200 <= IDList[i] && IDList[i] < 300 && SubjectNum == 0)
                                CharacterStatus = 4;

                            //Collide with Zelda means WIN
                            //ID1 is Princess
                            else if (1 == IDList[i] && SubjectNum == 0)
                                CharacterStatus = 3;

                            //Collide with Exit to Next means go to next level
                            else if (501 == IDList[i] && SubjectNum == 0)
                                CharacterStatus = 2;
                        }

                        //Normaly only one vector returned, so put each on status
                        if (Detection.X != 0)
                            status.X = Detection.X;
                        if (Detection.Y != 0)
                            status.Y = Detection.Y;
                    }
                }
            return status;
        }

        //Find sprite from ID, then return the number stored in List
        private int FindSprite(int ID)
        {
            for (int i = 0; i < size; i++)
                if (IDList[i] == ID)
                    return i;

            //not found return -1
            return -1;
        }


        //Collsion detector will check if the two objects collides
        //Return true if collision detected
        protected Vector2 CollisionDetect(int n, int m)
        {
            //Postion, Height, and Width on Object1
            Vector2 Position1 = posList[n];
            float Height1 = HeightList[n];
            float Width1 = WidthList[n];

            //Positon, Height, and Width on Object2
            Vector2 Position2 = posList[m];
            float Height2 = HeightList[m];
            float Width2 = WidthList[m];

            float diffY = 0;
            float diffX = 0;

            //Right side of Object1 on left side of Object2
            if (Position1.X < Position2.X)
                if (Position1.X + Width1 > Position2.X)
                    //object1 above object2
                    if (Position1.Y < Position2.Y)
                    {
                        //Bottom of object1 under top of object2. (intercect)
                        if (Position1.Y + Height1 > Position2.Y)
                        {
                            //Obtain difference between edges
                            diffX = (Position1.X + Width1) - Position2.X;
                            diffY = (Position1.Y + Height1) - Position2.Y;

                            if (Math.Abs(diffX) >Math.Abs( diffY))
                                return new Vector2(0, diffY);
                            else
                                return new Vector2(diffX, 0);
                        }
                    }//object1 below object2
                    else if (Position1.Y > Position2.Y)
                        if (Position1.Y < Position2.Y + Height2) //(intercect)
                        {
                            //Obtain difference between edges
                            diffX = (Position1.X + Width1) - Position2.X;
                            diffY = Position1.Y-(Position2.Y + Height2);

                            if (Math.Abs(diffX) >Math.Abs( diffY))
                                return new Vector2(0, diffY);
                            else
                                return new Vector2(diffX, 0);

                        }

            //Right side of Object2 on left side of Object1
            if (Position1.X > Position2.X)
                if (Position1.X < Position2.X + Width2)
                    if (Position1.Y < Position2.Y)
                    {
                        if (Position1.Y + Height1 > Position2.Y)
                        {
                            diffX = Position1.X-(Position2.X + Width2);
                            diffY = (Position1.Y + Height1) - Position2.Y;

                            if (Math.Abs(diffX) >Math.Abs( diffY))
                                return new Vector2(0, diffY);
                            else
                                return new Vector2(diffX, 0);
                        }
                    }
                    else if (Position1.Y > Position2.Y)
                        if (Position1.Y < Position2.Y + Height2)
                        {
                            diffX =   Position1.X-(Position2.X + Width2);
                            diffY = Position1.Y - (Position2.Y + Height2);

                            if (Math.Abs(diffX) >Math.Abs( diffY))
                                return new Vector2(0, diffY);
                            else
                                return new Vector2(diffX, 0);
                        }

            //This defines 4 boundaries on display.
            if (Position1.X < 0)
                diffX = Position1.X;
            if (Position1.Y < 0)
                diffY = Position1.Y;
            if (Position1.X + Width1 > 800)
                diffX = Position1.X + Width1 - 800;
            if (Position1.Y + Height1 > 480)
                diffY = Position1.Y + Height1 - 480;

            if (diffX != 0 || diffY != 0)
            {
                //BoundaryCollisionDetected
                Boundary = true;
                return new Vector2(diffX, diffY);
            }
            //No collision agaist objects and boundaries detected
            return new Vector2(0,0);
        }


        /*
         * Check if Character is able to see the another object
         * ID1 is observer, ID2 is object. Calculate the straight line 
         * between ID1 and ID2, then check if there is any object between them.
         */
        public Vector2 Visibility(int ID1, int ID2)
        {
            //Slope, Intercept, Y
            //Right, left, Top , Bottom for Postion1 and 2 rectangle

            float a, b, y1, y2,
                right, left, top, bottom;


            //Find object number
            int n = FindSprite(ID1);
            int m = FindSprite(ID2);
            Vector2 Position1 = posList[n];
            Vector2 Position2 = posList[m];

            //Modify the Position Left-top to center of sprite
            Position1.X += WidthList[n] / 2;
            Position1.Y += HeightList[n] / 2;
            Position2.X += WidthList[m] / 2;
            Position2.Y += HeightList[m] / 2;

            //ID 202 is Dragon that can fly and see the player from sky
            //ID 1 is Princess that has to be helped by player
            if (ID1 == 202 || ID1 == 1)
                return Position2;

            //Find Rectangle
            //Right and left sides
            if (Position1.X < Position2.X)
            {
                right = Position2.X + 2;
                left = Position1.X -2 ;
            }
            else if (Position1.X > Position2.X)
            {
                right = Position1.X +2;
                left = Position2.X -2;
            }
            else
            {
                right = Position1.X +2;
                left = right -2;
            }

            //Top and bottom
            if (Position1.Y > Position2.Y)
            {
                top = Position2.Y -2;
                bottom = Position1.Y +2;
            }
            else if (Position1.Y < Position2.Y)
            {
                top = Position1.Y -2;
                bottom = Position2.Y +2;
            }
            else
            {
                top = Position1.Y -2;
                bottom = top +2;
            }

            //Get slope
            a = (Position1.Y - Position2.Y) / (Position1.X - Position2.X);

            //Get intercept
            b = Position1.Y - a * Position1.X;

            //check if there is any object between object1 and 2
            for (int i = 0; i < size; i++)
                //only obstacles considered
                if (i != n && i != m && InGame[i])
                {
                    //line is not nearly vertical
                    if (!(right+1 <= left && right-1 >=left))
                    {
                        //Obstacles Between position1 and 2 are considered
                        if ((left <= posList[i].X && right >= posList[i].X + WidthList[i])
                            || (top <= posList[i].Y && bottom >= posList[i].Y + HeightList[i]))
                        {
                            //Intersection between visible sight
                            y1 = a * posList[i].X + b;
                            y2 = a * (posList[i].X + WidthList[i]) + b;

                            //Checking left top and right bottom to visible sight line
                            if (a <= 0)
                                if (posList[i].Y < y1 && (posList[i].Y + HeightList[i]) > y2)
                                    return new Vector2(-999, -999);

                            if (a > 0)
                                if (posList[i].Y < y2 && (posList[i].Y + HeightList[i]) > y1)
                                    return new Vector2(-999, -999);
                        }


                    }
                    else //Line is nearly vertical, compare right and left on object to line 
                        if (top > posList[i].Y && bottom < posList[i].Y + HeightList[i])
                            if (posList[i].X < right && (posList[i].X + WidthList[i]) > right)
                                return new Vector2(-999, -999);
                }

            return Position2;
        }



    }
}
