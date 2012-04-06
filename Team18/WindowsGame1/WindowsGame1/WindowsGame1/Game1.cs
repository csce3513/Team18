using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WindowsGame1
{

    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    { 
        enum gamestate
        {
            menu, play
        }

        gamestate state;
        KeyboardState keystate;
        KeyboardState lastKeyState; 
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Sprite BG0;
        Sprite menu;
        Sprite tree1;
        Sprite tree2;
        Sprite tree3;
        EnemyCharacter Enemy1;

        Character player;

        ActionHandler Action;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            //Game starts with the menu
            state = gamestate.menu;

            //Player that can move around
            player = new Character();

            //ID number 0 indicate character that is only one exist.
            player.SpriteID = 0;

            //ID number 2xx indicate Enemy
            Enemy1 = new EnemyCharacter();
            Enemy1.SpriteID = 201;

            //Backgrounds
            menu = new Sprite();
            BG0 = new Sprite();
            
            //ID 9xx indicate non object sprite
            menu.SpriteID = 901;

            //ID 1xx indicate stationary object
            tree1 = new Sprite(101);
            tree2 = new Sprite(102);
            tree3 = new Sprite(103);

            //Action Handling including Collision Detection and EnemySight
            Action = new ActionHandler();
                       

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Background
            menu.LoadContent(this.Content, "Menu");
            BG0.LoadContent(this.Content, "Grass");
            BG0.updatePos(new Vector2(0, 0));
            BG0.Scale = 3.0f;

            //Trees as Obstacle
            tree1.LoadContent(this.Content, "Tree");
            tree2.LoadContent(this.Content, "Tree");
            tree3.LoadContent(this.Content, "Tree");

            //Size modification
            tree1.Scale = 0.8f;
            tree2.Scale = 0.8f;
            tree3.Scale = 0.8f;
      
            //Set Position
            tree1.updatePos(new Vector2(200, 200));
            tree2.updatePos(new Vector2(600, 300));
            tree3.updatePos(new Vector2(500, 100));

            //Movable sprites
            player.LoadContent(this.Content);
            player.Scale = 1.5f;
            
            Enemy1.LoadContent(this.Content);

            //Add object information to ActionHandler
            Action.addObject(player.pos, player.SpriteID, player.Texture.Height*1.5f -8 , player.Texture.Width* 1.5f -5);
            Action.addObject(tree1.pos, tree1.SpriteID, tree1.getTex().Height * 0.8f, tree1.getTex().Width * 0.8f);
            Action.addObject(tree2.pos, tree2.SpriteID, tree2.getTex().Height * 0.8f, tree2.getTex().Width * 0.8f);
            Action.addObject(tree3.pos, tree3.SpriteID, tree3.getTex().Height * 0.8f, tree3.getTex().Width * 0.8f);
            Action.addObject(Enemy1.pos, Enemy1.SpriteID, Enemy1.getTex().Height, Enemy1.getTex().Width);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            //Get keyboard state
            keystate = Keyboard.GetState();
            
            //At Menu screen
            if (state == gamestate.menu)
            {
                // Allows the game to exit
                if ((keystate.IsKeyDown(Keys.Escape) == true) 
                    && (lastKeyState.IsKeyUp(Keys.Escape) == true))
                    this.Exit();

                // Go to playing state
                if ((keystate.IsKeyDown(Keys.Space) == true)
                    && (lastKeyState.IsKeyUp(Keys.Space) == true))
                {
                    state = gamestate.play;
                }
            }
            //At playing screen    
            else if (state == gamestate.play)
            {
                Vector2 currentPos;
                Vector2 Diff = new Vector2(0,0);

                // GO to Menu state
                if ((keystate.IsKeyDown(Keys.Escape) == true)
                    && (lastKeyState.IsKeyUp(Keys.Escape) == true))
                    state = gamestate.menu;

                //Checks if the enemy can see the player, return -999.-999 or player.pos
                Enemy1.TargetPosition = Action.Visibility(Enemy1.SpriteID, player.SpriteID) ;
                         
                //Player movement
                player.CharacterUpdate(gameTime);
                Enemy1.EnemyUpdate(gameTime);

                //ActionHandler needs to know updated position
                Action.UpdatePos(player.SpriteID, player.pos);
                Action.UpdatePos(Enemy1.SpriteID, Enemy1.pos);

                //Collision detection, moving back to non-collide position
                Diff = Action.CollisionCheck(player.SpriteID);

                //Collide against a object on X axis
                if (Math.Abs(Diff.X) > 0)
                {
                    currentPos = player.pos;
                    currentPos.X -= Diff.X;
                    player.pos = currentPos;
                }
                //Collide against object on Y axis
                if (Math.Abs(Diff.Y) > 0)
                {
                    currentPos = player.pos;
                    currentPos.Y -= Diff.Y;
                    player.pos = currentPos;
                }

                //Same as character, collision detection.
                Diff = Action.CollisionCheck(Enemy1.SpriteID);

                if (Math.Abs(Diff.X)> 0)
                {
                    currentPos = Enemy1.pos;
                    currentPos.X -= Diff.X;
                    Enemy1.pos = currentPos;
                }
                if (Math.Abs(Diff.Y) > 0)
                {
                    currentPos = Enemy1.pos;
                    currentPos.Y -= Diff.Y;
                    Enemy1.pos = currentPos;
                }
            }

            lastKeyState = keystate;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            if (state == gamestate.menu)
            {
                menu.Draw(this.spriteBatch);
            }

            if (state == gamestate.play)
            {
                //Drawing Backgrounds and objects 
                BG0.Draw(this.spriteBatch);
                tree1.Draw(this.spriteBatch);
                tree2.Draw(this.spriteBatch);
                tree3.Draw(this.spriteBatch);
                Enemy1.Draw(this.spriteBatch);

                player.Draw(this.spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

 
    }
}
