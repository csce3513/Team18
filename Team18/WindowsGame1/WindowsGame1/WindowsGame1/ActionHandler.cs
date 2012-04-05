using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{

    //ActionHandler handles collision and some action related to objects

    class ActionHandler
    {
        //These Lists contains Positon, texture info with ID.
        Vector2[] posList = new Vector2[10];
        int[] IDList = new int[10];
        double[] HeightList = new double[10];
        double[] WidthList = new double[10];
             
        
        //Sprite Size
        int size = 0;
        
        //Default Constructor
        public ActionHandler()
        {
                      
        }

        //Adding Object
        public void addObject(Vector2 Pos, int ID, double Height, double Width)
        {
            posList[size] = Pos;
            IDList[size] = ID;
            HeightList[size] = Height;
            WidthList[size] = Width;
            size++;
        }

        //Position Update
        public void UpdatePos(int ID, Vector2 pos)
        {
            posList[FindSprite(ID)] = pos;            
        }

        //Collision checker will check all of object with assigned object
        //When Collision detected return false
        public bool CollisionCheck(int ID)
        {
            bool status = false;

            int SubjectNum = FindSprite(ID);
            
            for (int i = 0; i < size; i++)
                if (i != SubjectNum)
                    if (CollisionDetect(SubjectNum, i))
                        status = true;

            return status;
        }

        //Find sprite from ID, then return the number stored in List
        private int FindSprite (int ID)
        {
            for (int i = 0; i < size; i++)
                if (IDList[i] == ID)
                    return i;

            //not found return -1
            return -1;
        }
       

        //Collsion detector will check if the two objects collides
        //Return true if collision detected
        protected bool CollisionDetect(int n, int m)
        {
            //Postion, Height, and Width on Object1
            Vector2 Position1 = posList[n];
            double Height1 = HeightList[n];
            double Width1 = WidthList[n];

            //Positon, Height, and Width on Object2
            Vector2 Position2 = posList[m];
            double Height2 = HeightList[m];
            double Width2 = WidthList[m];

            //Right side of Object1 on left side of Object2
            if (Position1.X < Position2.X)
                if (Position1.X + Width1 > Position2.X)
                    //object1 above object2
                    if (Position1.Y < Position2.Y)
                    {
                        //Bottom of object1 under top of object2. (intercect)
                        if (Position1.Y + Height1 > Position2.Y)
                        {
                            return true;
                        }
                    }
                    else if (Position1.Y > Position2.Y)
                            if (Position1.Y < Position2.Y + Height2)
                                return true;


            if (Position1.X > Position2.X)
                if (Position1.X < Position2.X + Width2)
                    if (Position1.Y < Position2.Y)
                    {
                        if (Position1.Y + Height1 > Position2.Y)
                        {
                            return true;
                        }
                    }
                    else if (Position1.Y > Position2.Y)
                        if (Position1.Y < Position2.Y + Height2)
                            return true;

           return false;
        }


        //Check if Character is able to see the another object
        //public Vector2 Visibility(int ID1, int ID2)
        //{
        //    int n = FindSprite(ID1);
        //    int m = FindSprite(ID2);
        //    Vector2 Position1 = posList[n];
        //    Vector2 Position2 = posList[m];

        //    double a = (Position1.Y - Position2.Y) / (Position1.X - Position2.X);
        //    double x;
            
           
        //}
    }
}
