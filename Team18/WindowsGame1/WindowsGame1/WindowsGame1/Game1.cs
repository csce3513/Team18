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
            menu, play, help
        }

        enum gamemap
        {
            start, second, final, lose, win
        }

        
        gamestate state;
        KeyboardState keystate;
        KeyboardState lastKeyState;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Sprite BG0;
        Sprite menu;
        Sprite help;
        Sprite tree1;
        Sprite tree2;
        Sprite tree3;
        EnemyCharacter Enemy1;
        

        Dragon Enemy2;
        PrincessZelda Zelda;
        Sprite Arrow;
        gamemap MapState;
        Sprite Thanks;
        Sprite Blood;

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

            //Game play starts with start map
            MapState = gamemap.start;

            //Player that can move around
            player = new Character();

            //ID number 0 indicate character that is only one exist.
            player.SpriteID = 0;

            //ID number 2xx indicate Enemy
            Enemy1 = new EnemyCharacter();
            Enemy1.SpriteID = 201;
            Enemy2 = new Dragon();
            Enemy2.SpriteID = 202;

            //ID number 1 indicate PrincessZelda
            Zelda = new PrincessZelda();
            Zelda.SpriteID = 1;

            //Backgrounds
            menu = new Sprite();
            help = new Sprite();
            BG0 = new Sprite();
            Blood = new Sprite();
            Thanks = new Sprite();

            //ID 9xx indicate non object sprite
            menu.SpriteID = 901;

            //ID 1xx indicate stationary object
            tree1 = new Sprite(101);
            tree2 = new Sprite(102);
            tree3 = new Sprite(103);

            //ID 5xx indicate Key acition abject that cause some action
            Arrow = new Sprite(501);

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
            menu.LoadContent(this.Content, "Menu1");
            help.LoadContent(this.Content, "Help");
            BG0.LoadContent(this.Content, "Grass");
            BG0.updatePos(new Vector2(0, 0));
            BG0.Scale = 3.0f;
            Blood.LoadContent(this.Content, "Blood");
            Blood.Scale = 0.9f;
            Thanks.LoadContent(this.Content, "Thanks");

            Thanks.updatePos(new Vector2(0, -150));

            //Trees as Obstacle
            tree1.LoadContent(this.Content, "Tree");
            tree2.LoadContent(this.Content, "Tree");
            tree3.LoadContent(this.Content, "Tree");

            //Action Obstacle
            Arrow.LoadContent(this.Content, "Arrow");
            Arrow.updatePos(new Vector2(750, 250)); 

            //Size modification
            tree1.Scale = 0.8f;
            tree2.Scale = 0.8f;
            tree3.Scale = 0.8f;
            Arrow.Scale = 1.5f;

            //Movable sprites
            player.LoadContent(this.Content);
            player.Scale = 1.5f;

            Enemy1.LoadContent(this.Content);           
            Enemy2.LoadContent(this.Content);

            Zelda.LoadContent(this.Content);
            Zelda.Scale = 1.5f;

            //Add object information to ActionHandler
            Action.addObject(player.pos, player.SpriteID, 26 * 1.5f - 8, 30 * 1.5f - 5);
            Action.addObject(tree1.pos, tree1.SpriteID, tree1.getTex().Height * 0.8f, tree1.getTex().Width * 0.8f);
            Action.addObject(tree2.pos, tree2.SpriteID, tree2.getTex().Height * 0.8f, tree2.getTex().Width * 0.8f);
            Action.addObject(tree3.pos, tree3.SpriteID, tree3.getTex().Height * 0.8f, tree3.getTex().Width * 0.8f);
            Action.addObject(Enemy1.pos, Enemy1.SpriteID, 40, 52);
            Action.addObject(Zelda.pos, Zelda.SpriteID, Zelda.getTex().Height * 1.5f, Zelda.getTex().Width * 1.5f);
            Action.addObject(new Vector2(775, 250), Arrow.SpriteID, Arrow.getTex().Height, Arrow.getTex().Width); 

            Action.addObject(Enemy2.pos, Enemy2.SpriteID, 90, 50);

            player.Animation(Content, "Player_SpriteSheet", 30, 26, 10);
            Enemy2.Animation(Content, "finalflyingdragon", 96, 96, 4);
            Enemy1.Animation(Content, "Enemy1_SpriteSheet", 50, 40, 3);




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
                    MapState = gamemap.start;
                    Action.CharaceterState = 1;

                    //Set Position
                    tree1.updatePos(new Vector2(200, 200));
                    tree2.updatePos(new Vector2(600, 300));
                    tree3.updatePos(new Vector2(500, 100)); 
                    Enemy1.FirstPos = new Vector2(600, 250);
                    player.updatePos(new Vector2(50, 300));

                    //ActionHandler needs to know updated position
                    Action.UpdatePos(player.SpriteID, player.pos);
                    Action.UpdatePos(Enemy1.SpriteID, Enemy1.pos);
                    Action.UpdatePos(tree1.SpriteID, tree1.pos);
                    Action.UpdatePos(tree2.SpriteID, tree2.pos);
                    Action.UpdatePos(tree3.SpriteID, tree3.pos);


                    //Ignore objects that is not on the map from CollisionDetect
                    Action.IgnoreObject(202);
                    Action.IgnoreObject(1);
                }

                //get player to help menu
                if ((keystate.IsKeyDown(Keys.F1) == true)
                    && (lastKeyState.IsKeyUp(Keys.F1) == true))
                {
                    state = gamestate.help;
                }
            }


                // allow player to quit help screen
            else if (state == gamestate.help)
            {
                if ((keystate.IsKeyDown(Keys.Escape) == true)
                    && (lastKeyState.IsKeyUp(Keys.Escape) == true))
                    state = gamestate.menu;

            }
            //At playing screen    
            else if (state == gamestate.play)
            {
                Vector2 currentPos;
                Vector2 Diff = new Vector2(0, 0);

                // GO to Menu state
                if ((keystate.IsKeyDown(Keys.Escape) == true)
                    && (lastKeyState.IsKeyUp(Keys.Escape) == true))
                    state = gamestate.menu;

                //First(default) map setting
                if (MapState == gamemap.start)
                {
                    //Checks if the enemy can see the player, return -999.-999 or player.pos
                    Enemy1.TargetPosition = Action.Visibility(Enemy1.SpriteID, player.SpriteID);

                    //Player movement
                    player.CharacterUpdate(gameTime);
                    player.HandleSourceRect(gameTime);
                    Enemy1.EnemyUpdate(gameTime);
                    Enemy1.HandleSourceRect(gameTime);

                    //ActionHandler needs to know updated position
                    Action.UpdatePos(player.SpriteID, player.pos);
                    Action.UpdatePos(Enemy1.SpriteID, Enemy1.pos);

                    //Collision detection, moving back to non-collide position
                    Diff = Action.CollisionCheck(player.SpriteID);
                    player.status = Action.CharaceterState; 

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

                    if (Math.Abs(Diff.X) > 0)
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

                    if (Action.CharaceterState == 2)
                    {
                        MapState = gamemap.second;
                        //Recognize objects that is not on the map from CollisionDetect
                        Action.RecognizeObject(202);
                        Action.RecognizeObject(1);

                        //Setup new Position
                        tree1.updatePos(new Vector2(50, 150));
                        tree2.updatePos(new Vector2(500, 200));
                        tree3.updatePos(new Vector2(200, 100));
                        Enemy1.FirstPos = new Vector2(700,150);
                        Enemy2.updatePos(new Vector2(650, 350));
                        player.updatePos(new Vector2(50, 300));

                        //ActionHandler needs to know updated position
                        Action.UpdatePos(player.SpriteID, player.pos);
                        Action.UpdatePos(Enemy1.SpriteID, Enemy1.pos);
                        Action.UpdatePos(Enemy2.SpriteID, Enemy2.pos);
                        Action.UpdatePos(tree1.SpriteID, tree1.pos);
                        Action.UpdatePos(tree2.SpriteID, tree2.pos);
                        Action.UpdatePos(tree3.SpriteID, tree3.pos);
                    }
                    else if (Action.CharaceterState == 3)
                        MapState = gamemap.win;
                    else if (Action.CharaceterState == 4)
                        MapState = gamemap.lose;


                }

                else if (MapState == gamemap.second)
                {

                    //Checks if the enemy can see the player, return -999.-999 or player.pos
                    Enemy1.TargetPosition = Action.Visibility(Enemy1.SpriteID, player.SpriteID);
                    Enemy2.TargetPosition = Action.Visibility(Enemy2.SpriteID, player.SpriteID);

                    //Player movement
                    player.CharacterUpdate(gameTime);
                    player.HandleSourceRect(gameTime);
                    Enemy1.EnemyUpdate(gameTime);
                    Enemy1.HandleSourceRect(gameTime);
                    Enemy2.EnemyUpdate(gameTime);
                    Enemy2.HandleSourceRect(gameTime);

                    //ActionHandler needs to know updated position
                    Action.UpdatePos(player.SpriteID, player.pos);
                    Action.UpdatePos(Enemy1.SpriteID, Enemy1.pos);
                    Action.UpdatePos(Enemy2.SpriteID, Enemy2.pos);

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

                    if (Math.Abs(Diff.X) > 0)
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

                    //Same as character, collision detection.
                    Diff = Action.CollisionCheck(Enemy2.SpriteID);

                    if (Math.Abs(Diff.X) > 0)
                    {
                        currentPos = Enemy2.pos;
                        currentPos.X -= Diff.X;
                        Enemy2.pos = currentPos;
                    }
                    if (Math.Abs(Diff.Y) > 0)
                    {
                        currentPos = Enemy2.pos;
                        currentPos.Y -= Diff.Y;
                        Enemy2.pos = currentPos;
                    }

                    if (Action.CharaceterState == 3)
                        MapState = gamemap.win;
                    else if (Action.CharaceterState == 4)
                        MapState = gamemap.lose;
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

            if (state == gamestate.help)
            {
                help.Draw(this.spriteBatch);
            }


            if (state == gamestate.play)
            {
                if (MapState == gamemap.start)
                {
                    //Drawing Backgrounds and objects 
                    BG0.Draw(this.spriteBatch);
                    tree1.Draw(this.spriteBatch);
                    tree2.Draw(this.spriteBatch);
                    tree3.Draw(this.spriteBatch);
                    Arrow.Draw(this.spriteBatch);
                    Enemy1.animateDraw(this.spriteBatch);
                    player.animateDraw(this.spriteBatch);
                }
                //Drawing second map
                else if (MapState == gamemap.second)
                {
                    //Drawing Backgrounds and objects 
                    BG0.Draw(this.spriteBatch);
                    tree1.Draw(this.spriteBatch);
                    tree2.Draw(this.spriteBatch);
                    tree3.Draw(this.spriteBatch);
                    Enemy1.animateDraw(this.spriteBatch);
                    Enemy2.animateDraw(this.spriteBatch);
                    Zelda.Draw(this.spriteBatch);
                    player.animateDraw(this.spriteBatch);
                }
                //showing LOSE background
                else if (MapState == gamemap.lose)
                {
                    Blood.Draw(this.spriteBatch);
                    player.animateDraw(this.spriteBatch);
                }
                //showing WIN background
                else if (MapState == gamemap.win)
                {
                    Thanks.Draw(this.spriteBatch);
                    player.animateDraw(this.spriteBatch);
                }

            }

            spriteBatch.End();

            base.Draw(gameTime);
        }


    }
}


