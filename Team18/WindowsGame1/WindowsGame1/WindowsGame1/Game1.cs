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

        //GameMaps and Backgraound. New map goes by Third Forth... so on
        enum gamemap
        {
            start, second, final, lose, win
        }

        gamestate state;
        gamemap MapState;
        
        KeyboardState keystate;
        KeyboardState lastKeyState;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Sprite BG0;
        Sprite menu;
        Sprite help;
        Sprite Thanks;
        Sprite Blood;

        Sprite tree1;
        Sprite tree2;
        Sprite tree3;
        Sprite tree4;
        Sprite tree5;
        Sprite Arrow;
        
        EnemyCharacter Enemy1;
        EnemyCharacter Enemy2;
        Dragon Dragon1;
        
        PrincessZelda Zelda;               
        Character player;

        Collision Action;

        //audio variables declaration
        SoundEffect song0;
        SoundEffectInstance song0Inst;
        SoundEffect song1;
        SoundEffectInstance song1Inst;
        SoundEffect song2;
        SoundEffectInstance song2Inst;
        SoundEffect song3;
        SoundEffectInstance song3Inst;
        SoundEffect song4;
        SoundEffectInstance song4Inst;
        SoundEffect song5;
        SoundEffectInstance song5Inst;
        SoundEffect song6;
        SoundEffectInstance song6Inst;
        SoundEffect song7;
        SoundEffectInstance song7Inst;
        SoundEffect song8;
        SoundEffectInstance song8Inst;

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
            Dragon1 = new Dragon();
            Dragon1.SpriteID = 202;
            Enemy2 = new EnemyCharacter();
            Enemy2.SpriteID = 203;

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
            tree4 = new Sprite(104);
            tree5 = new Sprite(105);

            //ID 5xx indicate Key acition abject that cause some action
            Arrow = new Sprite(501);

            //Action Handling including Collision Detection and EnemySight
            Action = new Collision();


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

            //Lose Screen
            Blood.LoadContent(this.Content, "Blood");
            Blood.Scale = 0.9f;

            //Win Screen
            Thanks.LoadContent(this.Content, "Thanks");
            Thanks.updatePos(new Vector2(0, -150));

            //Trees as Obstacle
            tree1.LoadContent(this.Content, "Tree");
            tree2.LoadContent(this.Content, "Tree");
            tree3.LoadContent(this.Content, "Tree");
            tree4.LoadContent(this.Content, "Tree");
            tree5.LoadContent(this.Content, "Tree");

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
            Dragon1.LoadContent(this.Content);
            Enemy2.LoadContent(this.Content);  

            Zelda.LoadContent(this.Content);
            Zelda.Scale = 1.5f;

            //Add object information to ActionHandler
            Action.addObject(player.pos, player.SpriteID, 30 * 1.5f - 20, 26 * 1.5f - 8);
            Action.addObject(tree1.pos, tree1.SpriteID, tree1.getTex().Width * 0.7f, tree1.getTex().Height * 0.7f);
            Action.addObject(tree2.pos, tree2.SpriteID, tree2.getTex().Width * 0.7f, tree2.getTex().Height * 0.7f);
            Action.addObject(tree3.pos, tree3.SpriteID, tree3.getTex().Width * 0.7f, tree3.getTex().Height * 0.7f);
            Action.addObject(tree4.pos, tree4.SpriteID, tree4.getTex().Width * 0.7f, tree4.getTex().Height * 0.7f);
            Action.addObject(tree5.pos, tree5.SpriteID, tree5.getTex().Width * 0.7f, tree5.getTex().Height * 0.7f);
            Action.addObject(Enemy1.pos, Enemy1.SpriteID, 48, 38);
            Action.addObject(Enemy2.pos, Enemy2.SpriteID, 48, 38);            
            Action.addObject(Dragon1.pos, Dragon1.SpriteID, 45, 85);
            Action.addObject(Zelda.pos, Zelda.SpriteID, Zelda.getTex().Width * 1.5f, Zelda.getTex().Height * 1.5f);
            Action.addObject(new Vector2(775, 250), Arrow.SpriteID, Arrow.getTex().Width, Arrow.getTex().Height);

            //Load Animation Spritesheet
            player.Animation(Content, "Player_SpriteSheet", 30, 26, 10);
            Dragon1.Animation(Content, "finalflyingdragon", 96, 96, 4);
            Enemy1.Animation(Content, "Enemy1_SpriteSheet", 50, 40, 3);
            Enemy2.Animation(Content, "Enemy1_SpriteSheet", 50, 40, 3);
            Zelda.Animation(Content, "Zelda1", 29, 27, 4 );

            //add audios 
            song0 = Content.Load<SoundEffect>("audioHome");  // menu Audio
            song0Inst = song0.CreateInstance();
            song1 = Content.Load<SoundEffect>("collisionAudio"); //audio for character hit by obstacle
            song1Inst = song1.CreateInstance();
            song2 = Content.Load<SoundEffect>("Condolescences"); //when game lost
            song2Inst = song2.CreateInstance();
            song3 = Content.Load<SoundEffect>("Victory");//when game won
            song3Inst = song3.CreateInstance();
            song4 = Content.Load<SoundEffect>("playAudio");  //"in-game" audio
            song4Inst = song4.CreateInstance();
            song5 = Content.Load<SoundEffect>("Scene2Audio");
            song5Inst = song5.CreateInstance();
            song6 = Content.Load<SoundEffect>("CollisionRight");
            song6Inst = song6.CreateInstance();
            song7 = Content.Load<SoundEffect>("CollisionLeft");
            song7Inst = song7.CreateInstance();
            song8 = Content.Load<SoundEffect>("DyingAudio");
            song8Inst = song8.CreateInstance();


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
                //play "in-game" audio
                song0Inst.Volume = 0.5f;
                song0Inst.Play();
                song4Inst.Stop();
                song1Inst.Stop();
                song2Inst.Stop();
                song5Inst.Stop();
                song3Inst.Stop();

                // Allows the game to exit
                if ((keystate.IsKeyDown(Keys.Escape) == true)
                    && (lastKeyState.IsKeyUp(Keys.Escape) == true))
                    this.Exit();

                // Go to playing state
                if ((keystate.IsKeyDown(Keys.Space) == true)
                    && (lastKeyState.IsKeyUp(Keys.Space) == true))
                {
                    state = gamestate.play;

                    //Load First Map
                    MapState = gamemap.start;
                    
                    //Healthy. Default state of player
                    Action.CharaceterState = 1;

                    //StartMap Load
                    StartMap_Load();
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
                
                // GO to Menu state
                if ((keystate.IsKeyDown(Keys.Escape) == true)
                    && (lastKeyState.IsKeyUp(Keys.Escape) == true))
                    state = gamestate.menu;

                //First(default) map setting
                //Enemy and Player action has to be called here
                if (MapState == gamemap.start)
                {
                    song0Inst.Pause();
                    song4Inst.Volume = 0.7f;
                    song4Inst.Play();

                    //StartMap Update
                    StartMap_Update(gameTime);
                   
                    //This means Move to Next map
                    //Replace Objects for the New Map
                    if (Action.CharaceterState == 2)
                    {
                        MapState = gamemap.second;

                        //SecondMap Loading
                        SecondMap_Load();
                        
                    }
                    //Win save the Princess
                    else if (Action.CharaceterState == 3)
                        MapState = gamemap.win;
                    //Lose killed by Enemy
                    else if (Action.CharaceterState == 4)
                        MapState = gamemap.lose;


                }
                //Second Map basically same as First except Enamy2 added here
                else if (MapState == gamemap.second)
                {
                    song5Inst.Volume = 0.5f;
                    song5Inst.Play();
                    song4Inst.Stop();
                    song0Inst.Stop();

                    //Default state of Character
                    Action.CharaceterState = 1;

                    //Second Map Update
                    SecondMap_Update(gameTime);


                    if (Action.CharaceterState == 3)
                        MapState = gamemap.win;
                    else if (Action.CharaceterState == 4)
                        MapState = gamemap.lose;
                    else if (Action.CharaceterState == 2)
                    {
                        MapState = gamemap.final;
                        //Final Map loading
                        FinalMap_Load();
                    }
                }
                else if (MapState == gamemap.final)
                {
                    //Default state of Character
                    Action.CharaceterState = 1;

                    //Second Map Update
                    FinalMap_Update(gameTime);
                    

                    if (Action.CharaceterState == 3)
                        MapState = gamemap.win;
                    else if (Action.CharaceterState == 4)
                        MapState = gamemap.lose;
                }
                else if (MapState == gamemap.lose)
                {
                    player.CharacterUpdate(gameTime);
                    player.HandleSourceRect(gameTime);
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
                    //Drawing Backgrounds and objects that are on the Map
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
                    //Drawing Backgrounds and objects that are on the Map
                    BG0.Draw(this.spriteBatch);
                    tree1.Draw(this.spriteBatch);
                    tree2.Draw(this.spriteBatch);
                    tree3.Draw(this.spriteBatch);
                    Arrow.Draw(this.spriteBatch);
                    Enemy1.animateDraw(this.spriteBatch);
                    Enemy2.animateDraw(this.spriteBatch);
                    player.animateDraw(this.spriteBatch);
                }
                //Drawing final map
                else if (MapState == gamemap.final)
                {
                    //Drawing Backgrounds and objects that are on the Map
                    BG0.Draw(this.spriteBatch);
                    tree1.Draw(this.spriteBatch);
                    tree2.Draw(this.spriteBatch);
                    tree3.Draw(this.spriteBatch);
                    Enemy1.animateDraw(this.spriteBatch);
                    Enemy2.animateDraw(this.spriteBatch);
                    Dragon1.animateDraw(this.spriteBatch);
                    Zelda.animateDraw(this.spriteBatch);
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


        //Objects in Start map are placed
        private void StartMap_Load()
        {
            //Set Position for Each objects
            tree1.updatePos(new Vector2(200, 200));
            tree2.updatePos(new Vector2(600, 300));
            tree3.updatePos(new Vector2(500, 100));
            Enemy1.FirstPos = new Vector2(600, 250);
            player.updatePos(new Vector2(10, 220));

            //ActionHandler needs to know updated position
            Action.UpdatePos(player.SpriteID, player.pos);
            Action.UpdatePos(Enemy1.SpriteID, Enemy1.pos);
            Action.UpdatePos(tree1.SpriteID, tree1.pos);
            Action.UpdatePos(tree2.SpriteID, tree2.pos);
            Action.UpdatePos(tree3.SpriteID, tree3.pos);


            //Ignore objects that is not on the map for CollisionDetect
            Action.IgnoreObject(Dragon1.SpriteID);
            Action.IgnoreObject(Zelda.SpriteID);
            Action.IgnoreObject(Enemy2.SpriteID);
            Action.IgnoreObject(tree4.SpriteID);
            Action.IgnoreObject(tree5.SpriteID);
        }

        private void SecondMap_Load()
        {
            //Setup new Position
            tree1.updatePos(new Vector2(50, 150));
            tree2.updatePos(new Vector2(500, 200));
            tree3.updatePos(new Vector2(200, 100));
            player.updatePos(new Vector2(50, 300));

            //For enemy, change first position where they move back if they lost player
            Enemy1.FirstPos = new Vector2(700, 150);

            //newly added
            Enemy2.FirstPos = new Vector2(650, 350);

            //ActionHandler needs to know updated position
            Action.UpdatePos(player.SpriteID, player.pos);
            Action.UpdatePos(Enemy1.SpriteID, Enemy1.pos);
            Action.UpdatePos(tree1.SpriteID, tree1.pos);
            Action.UpdatePos(tree2.SpriteID, tree2.pos);
            Action.UpdatePos(tree3.SpriteID, tree3.pos);

            //newly added
            Action.UpdatePos(Enemy2.SpriteID, Enemy2.pos);

            //Recognize objects that is not on the map from CollisionDetect
            //Dragon and Zelda added
            Action.RecognizeObject(Enemy2.SpriteID);
           
        }

        private void FinalMap_Load()
        {             
            //Setup new Position
            tree1.updatePos(new Vector2(300, 150));
            tree2.updatePos(new Vector2(200, 200));
            tree3.updatePos(new Vector2(500, 400));
            player.updatePos(new Vector2(50, 300));

            //For enemy, change first position where they move back if they lost player
            Enemy1.FirstPos = new Vector2(700, 150);
            Enemy2.FirstPos = new Vector2(650, 100);

            //newly added
            Dragon1.updatePos(new Vector2(-150, -50));

            //ActionHandler needs to know updated position
            Action.UpdatePos(player.SpriteID, player.pos);
            Action.UpdatePos(Enemy1.SpriteID, Enemy1.pos);
            Action.UpdatePos(Enemy2.SpriteID, Enemy2.pos);
            Action.UpdatePos(tree1.SpriteID, tree1.pos);
            Action.UpdatePos(tree2.SpriteID, tree2.pos);
            Action.UpdatePos(tree3.SpriteID, tree3.pos);

            //newly added
            Action.UpdatePos(Dragon1.SpriteID, Dragon1.pos);

            //Recognize objects that is not on the map from CollisionDetect
            //Dragon and Zelda added
            Action.RecognizeObject(Dragon1.SpriteID);
            Action.RecognizeObject(Zelda.SpriteID);
        }



        //This will handle collision and animation on StartMap
        private void StartMap_Update(GameTime gameTime)
        {
            //Checks if the enemy can see the player, return -999.-999 or player.pos
            Enemy1.TargetPosition = Action.Visibility(Enemy1.SpriteID, player.SpriteID);

            //Player and Enemy movement
            player.CharacterUpdate(gameTime);
            Enemy1.EnemyUpdate(gameTime);

            //Player and Enemy HandleSorceRectangle
            player.HandleSourceRect(gameTime);
            Enemy1.HandleSourceRect(gameTime);

            //ActionHandler needs to know updated position
            Action.UpdatePos(player.SpriteID, player.pos);
            Action.UpdatePos(Enemy1.SpriteID, Enemy1.pos);

            //Collision detection, moving back to non-collide position
            Action.SpriteCollision(ref player, song6Inst, song7Inst);
            Action.SpriteCollision(ref Enemy1);

            //In collision check, also checked Lose and Win status
            player.status = Action.CharaceterState;

        }

        private void SecondMap_Update(GameTime gameTime)
        {

            //Checks if the enemy can see the player, return -999.-999 or player.pos
            Enemy1.TargetPosition = Action.Visibility(Enemy1.SpriteID, player.SpriteID);
            Enemy2.TargetPosition = Action.Visibility(Enemy2.SpriteID, player.SpriteID);

            //Player and Enemy movement
            player.CharacterUpdate(gameTime);
            Enemy1.EnemyUpdate(gameTime);
            Enemy2.EnemyUpdate(gameTime);

            //Player and Enemy Animation Rectangle Handle
            player.HandleSourceRect(gameTime);
            Enemy1.HandleSourceRect(gameTime);
            Enemy2.HandleSourceRect(gameTime);
           // Zelda.HandleSourceRect(gameTime);

            //ActionHandler needs to know updated position
            Action.UpdatePos(player.SpriteID, player.pos);
            Action.UpdatePos(Enemy1.SpriteID, Enemy1.pos);
            Action.UpdatePos(Enemy2.SpriteID, Enemy2.pos);
           
            //Collision detection, moving back to non-collide position
            Action.SpriteCollision(ref player, song6Inst, song7Inst);
            Action.SpriteCollision(ref Enemy1);
            Action.SpriteCollision(ref Enemy2);

            //In collision check, also checked Lose and Win status
            player.status = Action.CharaceterState;

        }


        private void FinalMap_Update(GameTime gameTime)
        {
            //Checks if the enemy can see the player, return -999.-999 or player.pos
            Enemy1.TargetPosition = Action.Visibility(Enemy1.SpriteID, player.SpriteID);
            Dragon1.TargetPosition = Action.Visibility(Dragon1.SpriteID, player.SpriteID);
            Enemy2.TargetPosition = Action.Visibility(Enemy2.SpriteID, player.SpriteID);

            //Player and Enemy movement
            player.CharacterUpdate(gameTime);
            Enemy1.EnemyUpdate(gameTime);
            Dragon1.EnemyUpdate(gameTime);
            Enemy2.EnemyUpdate(gameTime);

            //Player and Enemy Animation Rectangle Handle
            player.HandleSourceRect(gameTime);
            Enemy1.HandleSourceRect(gameTime);
            Dragon1.HandleSourceRect(gameTime);
            Enemy2.HandleSourceRect(gameTime);
            Zelda.HandleSourceRect(gameTime);

            //ActionHandler needs to know updated position
            Action.UpdatePos(player.SpriteID, player.pos);
            Action.UpdatePos(Enemy1.SpriteID, Enemy1.pos);
            Action.UpdatePos(Dragon1.SpriteID, Dragon1.pos);
            Action.UpdatePos(Enemy2.SpriteID, Enemy2.pos);

            //Collision detection, moving back to non-collide position
            Action.SpriteCollision(ref player, song6Inst, song7Inst);
            Action.SpriteCollision(ref Enemy1);
            Action.SpriteCollision(ref Enemy2);
            Action.SpriteCollision(ref Dragon1);

            //In collision check, also checked Lose and Win status
            player.status = Action.CharaceterState;
        }


        

    }
}


