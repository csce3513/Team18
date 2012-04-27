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
    //Collision Handling by each sprite personality

    class Collision : ActionHandler
    {
        //Obtain how far collide with the object and move back to original position
        //For Player sprite
        public void SpriteCollision(ref Character name, SoundEffectInstance song6Inst, SoundEffectInstance song7Inst)
        {
            //Temporary Value for Object position
            Vector2 currentPos;

            //Difference between each objects edges
            Vector2 Diff = new Vector2(0, 0);

            //Obtain difference from Actionhandler
            Diff = CollisionCheck(name.SpriteID);


            //For X axis difference
            if (Math.Abs(Diff.X) > 0)
            {
                //Sounds for colliding into object
                song6Inst.Volume = 1.0f;
                song6Inst.Play();
                currentPos = name.pos;
                currentPos.X -= Diff.X;
                name.pos = currentPos;
            }
            //For Y axis difference
            if (Math.Abs(Diff.Y) > 0)
            {
                //Sounds for colliding into object
                song7Inst.Volume = 1.0f;
                song7Inst.Play();
                currentPos = name.pos;
                currentPos.Y -= Diff.Y;
                name.pos = currentPos;
            }

        }

        //Obtain how far collide with the object and move back to original position
        //For Enemy sprite
        public void SpriteCollision(ref EnemyCharacter name)
        {
            //Temporary Value for Object position
            Vector2 currentPos;

            //Difference between each objects edges
            Vector2 Diff = new Vector2(0, 0);

            //Obtain difference from Actionhandler
            Diff = CollisionCheck(name.SpriteID);

            //For X axis difference
            if (Math.Abs(Diff.X) > 0)
            {
                currentPos = name.pos;
                currentPos.X -= Diff.X;
                name.pos = currentPos;
            }
            //For Y axis difference
            if (Math.Abs(Diff.Y) > 0)
            {
                currentPos = name.pos;
                currentPos.Y -= Diff.Y;
                name.pos = currentPos;
            }

        }

        //Obtain how far collide with the object and move back to original position
        //For Dragon sprite
        public void SpriteCollision(ref Dragon name)
        {
            //Temporary Value for Object position
            Vector2 currentPos;

            //Difference between each objects edges
            Vector2 Diff = new Vector2(0, 0);

            //Obtain difference from Actionhandler
            Diff = CollisionCheck(name.SpriteID);

            //For X axis difference
            if (Math.Abs(Diff.X) > 0)
            {
                currentPos = name.pos;
                currentPos.X -= Diff.X;
                name.pos = currentPos;
            }
            //For Y axis difference
            if (Math.Abs(Diff.Y) > 0)
            {
                currentPos = name.pos;
                currentPos.Y -= Diff.Y;
                name.pos = currentPos;
            }

        }

        //Obtain how far collide with the object and move back to original position
        //For Zelda sprite
        public void SpriteCollision(ref PrincessZelda name)
        {
            //Temporary Value for Object position
            Vector2 currentPos;

            //Difference between each objects edges
            Vector2 Diff = new Vector2(0, 0);

            //Obtain difference from Actionhandler
            Diff = CollisionCheck(name.SpriteID);

            //For X axis difference
            if (Math.Abs(Diff.X) > 0)
            {
                currentPos = name.pos;
                currentPos.X -= Diff.X;
                name.pos = currentPos;
            }
            //For Y axis difference
            if (Math.Abs(Diff.Y) > 0)
            {
                currentPos = name.pos;
                currentPos.Y -= Diff.Y;
                name.pos = currentPos;
            }

        }
    }
}
