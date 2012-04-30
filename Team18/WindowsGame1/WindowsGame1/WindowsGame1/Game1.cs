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
            menu, play, help, story1, story2
        }

        //GameMaps and Backgraound. New map goes by Third Forth... so on
        enum gamemap
        {
            start = 1, second, third, Escape1, Escape2, lose, win, 
        }

        gamestate state;
        gamemap MapState;
        gamemap previousMapState;

        KeyboardState keystate;
        KeyboardState lastKeyState;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Sprite BG0;
        Sprite menu;
        Sprite help;
        Sprite Thanks;
        Sprite Blood;
        Sprite Story1;
        Sprite Story2;

        Sprite tree1;
        Sprite tree2;
        Sprite tree3;
        Sprite tree4;
        Sprite tree5;
        Sprite Arrow;

        EnemyCharacter Enemy1;
        EnemyCharacter Enemy2;
        EnemyCharacter Enemy3;
        EnemyCharacter Enemy4;
        Dragon Dragon1;

        PrincessZelda Zelda;
        Character player;

        Collision Action;

        //audio variables declaration
        SoundEffect audioHome;
        SoundEffectInstance audioHomeInst;
        SoundEffect audioCollision;
        SoundEffectInstance audioCollisionInst;
        SoundEffect audioGameLost;
        SoundEffectInstance audioGameLostInst;
        SoundEffect audioVictory;
        SoundEffectInstance audioVictoryInst;
        SoundEffect audioInGame;
        SoundEffectInstance audioInGameInst;
        SoundEffect audioScene2;
        SoundEffectInstance audioScene2Inst;
        SoundEffect audioCollisionR;
        SoundEffectInstance audioCollisionRInst;
        SoundEffect audioCollisionL;
        SoundEffectInstance audioCollisionLInst;
        SoundEffect audioDead;
        SoundEffectInstance audioDeadInst;
        SoundEffect audioScene3;
        SoundEffectInstance audioScene3Inst;
        SoundEffect audioScene4;
        SoundEffectInstance audioScene4Inst;
        SoundEffect audioScene5;
        SoundEffectInstance audioScene5Inst;
        SoundEffect audioStory;
        SoundEffectInstance audioStoryInst;


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
            previousMapState = MapState;

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
            Enemy3 = new EnemyCharacter();
            Enemy3.SpriteID = 204;
            Enemy4 = new EnemyCharacter();
            Enemy4.SpriteID = 205;

            //ID number 1 indicate PrincessZelda
            Zelda = new PrincessZelda();
            Zelda.SpriteID = 1;

            //Backgrounds
            menu = new Sprite();
            help = new Sprite();
            BG0 = new Sprite();
            Blood = new Sprite();
            Thanks = new Sprite();
            Story1 = new Sprite();
            Story2 = new Sprite();

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
            Story1.LoadContent(this.Content, "Story1");
            Story2.LoadContent(this.Content, "Story2");
            Story1.Scale = 0.9f;
            Story2.Scale = 0.9f;

            //Lose Screen
            Blood.LoadContent(this.Content, "Blood");
            Blood.Scale = 0.9f;

            //Win Screen
            Thanks.LoadContent(this.Content, "Thanks");
            Thanks.updatePos(new Vector2(0, 0));

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
            tree4.Scale = 0.8f;
            tree5.Scale = 0.8f;
            Arrow.Scale = 1.5f;

            //Movable sprites
            player.LoadContent(this.Content);
            player.Scale = 1.5f;

            Enemy1.LoadContent(this.Content);
            Dragon1.LoadContent(this.Content);
            Enemy2.LoadContent(this.Content);
            Enemy3.LoadContent(this.Content);
            Enemy4.LoadContent(this.Content);


            Zelda.LoadContent(this.Content);
            Zelda.Scale = 1.5f;

            //Add object information to ActionHandler
            Action.addObject(player.pos, player.SpriteID, 30 * 1.5f - 20, 26 * 1.5f - 8);
            Action.addObject(tree1.pos, tree1.SpriteID, tree1.getTex().Width * 0.7f, tree1.getTex().Height * 0.7f);
            Action.addObject(tree2.pos, tree2.SpriteID, tree2.getTex().Width * 0.7f, tree2.getTex().Height * 0.7f);
            Action.addObject(tree3.pos, tree3.SpriteID, tree3.getTex().Width * 0.7f, tree3.getTex().Height * 0.7f);
            Action.addObject(tree4.pos, tree4.SpriteID, tree4.getTex().Width * 0.7f, tree4.getTex().Height * 0.7f);
            Action.addObject(tree5.pos, tree5.SpriteID, tree5.getTex().Width * 0.7f, tree5.getTex().Height * 0.7f);
            Action.addObject(Enemy1.pos, Enemy1.SpriteID, 44, 34);
            Action.addObject(Enemy2.pos, Enemy2.SpriteID, 44, 34);
            Action.addObject(Enemy3.pos, Enemy3.SpriteID, 44, 34);
            Action.addObject(Enemy4.pos, Enemy4.SpriteID, 44, 34);
            Action.addObject(Dragon1.pos, Dragon1.SpriteID, 85, 85);
            Action.addObject(Zelda.pos, Zelda.SpriteID,20* 1.5f, 28* 1.5f);
            Action.addObject(new Vector2(775, 250), Arrow.SpriteID, Arrow.getTex().Width* 1.5f, Arrow.getTex().Height* 1.5f);

            //Load Animation Spritesheet
            player.Animation(Content, "Player_SpriteSheet", 30, 26, 10);
            Dragon1.Animation(Content, "finalflyingdragon", 96, 96, 4);
            Enemy1.Animation(Content, "Enemy1_SpriteSheet", 50, 40, 3);
            Enemy2.Animation(Content, "Enemy1_SpriteSheet", 50, 40, 3);
            Enemy3.Animation(Content, "Enemy1_SpriteSheet", 50, 40, 3);
            Enemy4.Animation(Content, "Enemy1_SpriteSheet", 50, 40, 3);
            Zelda.Animation(Content, "Zelda1", 29, 28, 4);

            //add audios 
            audioHome = Content.Load<SoundEffect>("audioHome");  // menu Audio
            audioHomeInst = audioHome.CreateInstance();
            audioCollision = Content.Load<SoundEffect>("collisionAudio"); //audio for character hit by obstacle
            audioCollisionInst = audioCollision.CreateInstance();
            audioGameLost = Content.Load<SoundEffect>("Condolescences"); //when game lost
            audioGameLostInst = audioGameLost.CreateInstance();
            audioVictory = Content.Load<SoundEffect>("Victory");//when game won
            audioVictoryInst = audioVictory.CreateInstance();
            audioInGame = Content.Load<SoundEffect>("playAudio");  //"in-game" audio
            audioInGameInst = audioInGame.CreateInstance();
            audioScene2 = Content.Load<SoundEffect>("Scene2Audio");
            audioScene2Inst = audioScene2.CreateInstance();
            audioCollisionR = Content.Load<SoundEffect>("CollisionRight");
            audioCollisionRInst = audioCollisionR.CreateInstance();
            audioCollisionL = Content.Load<SoundEffect>("CollisionLeft");
            audioCollisionLInst = audioCollisionL.CreateInstance();
            audioDead = Content.Load<SoundEffect>("DyingAudio");
            audioDeadInst = audioDead.CreateInstance();
            audioScene3 = Content.Load<SoundEffect>("Scene3Audio");
            audioScene3Inst = audioScene3.CreateInstance();
            audioScene4 = Content.Load<SoundEffect>("Scene4Audio");
            audioScene4Inst = audioScene4.CreateInstance();
            audioScene5 = Content.Load<SoundEffect>("Scene5Audio");
            audioScene5Inst = audioScene5.CreateInstance();
            audioStory = Content.Load<SoundEffect>("StoryAudio");
            audioStoryInst = audioStory.CreateInstance();


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
                audioHomeInst.Volume = 0.5f;
                audioHomeInst.Play();
                audioInGameInst.Stop();
                audioCollisionInst.Stop();
                audioGameLostInst.Stop();
                audioScene2Inst.Stop();
                audioVictoryInst.Stop();

                // Allows the game to exit
                if ((keystate.IsKeyDown(Keys.Escape) == true)
                    && (lastKeyState.IsKeyUp(Keys.Escape) == true))
                    this.Exit();

                // Go to playing state
                if ((keystate.IsKeyDown(Keys.Space) == true)
                    && (lastKeyState.IsKeyUp(Keys.Space) == true))
                {
                    state = gamestate.story1;

                    //Load First Map
                    MapState = gamemap.start;
                    previousMapState = MapState;

                    //Healthy. Default state of player
                    Action.PlayerState = ActionHandler.CharacterStatus.Play;
                    player.status = 6;

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

            else if (state == gamestate.story1)
            {
                player.CharacterUpdate(gameTime);
                player.HandleSourceRect(gameTime);

                if ((keystate.IsKeyDown(Keys.Space) == true)
                   && (lastKeyState.IsKeyUp(Keys.Space) == true))
                    state = gamestate.play;
            }

            else if (state == gamestate.story2)
            {
                player.CharacterUpdate(gameTime);
                player.HandleSourceRect(gameTime);
                Zelda.ZeldaUpdate(gameTime);
                Zelda.HandleSourceRect(gameTime);

                if ((keystate.IsKeyDown(Keys.Space) == true)
                   && (lastKeyState.IsKeyUp(Keys.Space) == true))
                    state = gamestate.play;
            }


            //At playing screen    
            else if (state == gamestate.play)
            {

                // GO to Menu state
                if ((keystate.IsKeyDown(Keys.Escape) == true)
                    && (lastKeyState.IsKeyUp(Keys.Escape) == true))
                    state = gamestate.menu;

                //Default state of Character
                Action.PlayerState = ActionHandler.CharacterStatus.Play;

                //Enemy and Player action has to be called here
                if (MapState == gamemap.lose)
                {
                    audioInGameInst.Stop();
                    audioCollisionInst.Stop();
                    audioScene2Inst.Stop();
                    audioScene3Inst.Stop();
                    audioScene4Inst.Stop();
                    audioScene5Inst.Stop();
                    audioGameLostInst.Volume = 0.7f;
                    audioGameLostInst.Play();                   
                    player.CharacterUpdate(gameTime);
                    player.HandleSourceRect(gameTime);
                    Zelda.ZeldaUpdate(gameTime);
                    Zelda.HandleSourceRect(gameTime);
                }
                else if (MapState == gamemap.win)
                {
                    audioInGameInst.Stop();
                    audioCollisionInst.Stop();
                    audioScene2Inst.Stop();
                    audioScene3Inst.Stop();
                    audioScene4Inst.Stop();
                    audioScene5Inst.Stop();
                    audioVictoryInst.Volume = 0.7f;
                    audioVictoryInst.Play();
                    player.CharacterUpdate(gameTime);
                    player.HandleSourceRect(gameTime);
                    Zelda.ZeldaUpdate(gameTime);
                    Zelda.HandleSourceRect(gameTime);
                    player.status = 5;//Indicate WIN
                    Zelda.status = 5;
                }
                //First(default) map setting
                else if (MapState == gamemap.start)
                {
                    audioHomeInst.Pause();
                    audioInGameInst.Volume = 0.7f;
                    audioInGameInst.Play();

                    //StartMap Update
                    CollisionUpdate(gameTime);

                    //This means Move to Next map
                    //Replace Objects for the New Map
                    if (Action.PlayerState == ActionHandler.CharacterStatus.Next)
                    {
                        MapState = gamemap.second;

                        //SecondMap Loading
                        SecondMap_Load();

                    }
                    //Lose killed by Enemy
                    else if (Action.PlayerState == ActionHandler.CharacterStatus.Lose)
                        MapState = gamemap.lose;


                }
                //Second Map basically same as First except Enamy2 added here
                else if (MapState == gamemap.second)
                {
                    audioScene2Inst.Volume = 0.5f;
                    audioScene2Inst.Play();
                    audioInGameInst.Stop();
                    audioHomeInst.Stop();


                    //Second Map Update
                    CollisionUpdate(gameTime);

                    if (Action.PlayerState == ActionHandler.CharacterStatus.Lose)
                        MapState = gamemap.lose;
                    else if (Action.PlayerState == ActionHandler.CharacterStatus.Next)
                    {
                        previousMapState = MapState;
                        MapState = gamemap.third;
                        //Final Map loading
                        ThirdMap_Load();

                    }
                }
                else if (MapState == gamemap.third)
                {
                    audioScene3Inst.Volume = 0.5f;
                    audioScene3Inst.Play();
                    audioScene2Inst.Stop();
                    audioHomeInst.Stop();

                    //Third Map Collision and Update
                    CollisionUpdate(gameTime);

                    if (Action.PlayerState == ActionHandler.CharacterStatus.Save)
                    {
                        previousMapState = MapState;
                        MapState = gamemap.Escape1;
                        //Escape map loaded
                        state = gamestate.story2;
                        player.status = 6;//Stop moving for story
                        Zelda.status = 5;
                        Escape1_Load();
                    }
                    else if (Action.PlayerState == ActionHandler.CharacterStatus.Lose)
                        MapState = gamemap.lose;
                }
                else if (MapState == gamemap.Escape1)
                {
                    audioScene4Inst.Volume = 0.5f;
                    audioScene4Inst.Play();
                    audioScene3Inst.Stop();
                    audioHomeInst.Stop();

                    //Escape1 Map Collision and Update
                    CollisionUpdate(gameTime);

                    if (Action.PlayerState == ActionHandler.CharacterStatus.Next)
                    {
                        previousMapState = MapState;
                        MapState = gamemap.Escape2;
                        Escape2_Load();
                    }
                    else if (Action.PlayerState == ActionHandler.CharacterStatus.Lose)
                        MapState = gamemap.lose;

                }
                else if (MapState == gamemap.Escape2)
                {
                    audioScene5Inst.Volume = 0.5f;
                    audioScene5Inst.Play();
                    audioScene4Inst.Stop();
                    audioHomeInst.Stop();

                    //Escape2 Map Collision and Update
                    CollisionUpdate(gameTime);

                    if (Action.PlayerState == ActionHandler.CharacterStatus.Next)
                    {
                        MapState = gamemap.win;
                        player.updatePos(new Vector2(450, 100));
                        Zelda.updatePos(new Vector2(410, 100));
                    }
                    else if (Action.PlayerState == ActionHandler.CharacterStatus.Lose)
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

            if (state == gamestate.story1)
            {
                Story1.Draw(this.spriteBatch);
                player.animateDraw(this.spriteBatch);
            }

            if (state == gamestate.story2)
            {
                Story2.Draw(this.spriteBatch);
                Zelda.animateDraw(this.spriteBatch);
                player.animateDraw(this.spriteBatch);
            }

            if (state == gamestate.play)
            {//showing LOSE background
                if (MapState == gamemap.lose)
                {
                    Blood.Draw(this.spriteBatch);
                    player.animateDraw(this.spriteBatch);
                    if ((int)previousMapState > 2)
                        Zelda.animateDraw(this.spriteBatch);
                }
                //showing WIN background
                else if (MapState == gamemap.win)
                {
                    Thanks.Draw(this.spriteBatch);
                    Zelda.animateDraw(this.spriteBatch);
                    player.animateDraw(this.spriteBatch);
                }
                else
                {
                    //Drawing Backgrounds and objects that are on the Map
                    BG0.Draw(this.spriteBatch);
                    tree1.Draw(this.spriteBatch);
                    tree2.Draw(this.spriteBatch);
                    tree3.Draw(this.spriteBatch);

                    //Only Third Map does not have Arrow Sprite
                    if (MapState != gamemap.third)
                        Arrow.Draw(this.spriteBatch);

                    Enemy1.animateDraw(this.spriteBatch);

                    //Drawing after First map
                    if ((int)MapState > 1)
                        Enemy2.animateDraw(this.spriteBatch);

                    //Drawing after Second map
                    if ((int)MapState > 2)
                    {
                        tree4.Draw(this.spriteBatch);                        
                        Zelda.animateDraw(this.spriteBatch);
                    }
                    if ((int)MapState > 3)
                    { 
                        Dragon1.animateDraw(this.spriteBatch); 
                    }
                    //Drawing after Escape1 map
                    if ((int)MapState > 4)
                    {
                        Enemy3.animateDraw(this.spriteBatch);
                        Enemy4.animateDraw(this.spriteBatch);
                    }

                    player.animateDraw(this.spriteBatch);
                }
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }



        /// <summary> 
        /// Below here, Map loading and update methods that declares object
        /// position and check collision and so on for EACH MAP.
        /// 
        /// ::Future possible development::
        /// Choose if sprite is used or not on each sprite and gives
        /// only position. This means NOT EACH MAP, EACH SPRITES.
        /// This will enable to use loading Map data from another file
        /// </summary>

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
            Action.UpdatePos(player);
            Action.UpdatePos(Enemy1);
            Action.UpdatePos(tree1);
            Action.UpdatePos(tree2);
            Action.UpdatePos(tree3);


            //Ignore objects that is not on the map for CollisionDetect
            Action.IgnoreObject(Dragon1);
            Action.IgnoreObject(Zelda);
            Action.IgnoreObject(Enemy2);
            Action.IgnoreObject(Enemy3);
            Action.IgnoreObject(Enemy4);
            Action.IgnoreObject(tree4);
            Action.IgnoreObject(tree5);

            Action.RecognizeObject(Arrow);
        }

        private void SecondMap_Load()
        {
            //Setup new Position
            tree1.updatePos(new Vector2(100, 350));
            tree2.updatePos(new Vector2(500, 200));
            tree3.updatePos(new Vector2(200, 100));
            player.updatePos(new Vector2(50, 300));

            //For enemy, change first position where they move back if they lost player
            Enemy1.FirstPos = new Vector2(700, 150);

            //newly added
            Enemy2.FirstPos = new Vector2(650, 350);

            //ActionHandler needs to know updated position
            Action.UpdatePos(player);
            Action.UpdatePos(Enemy1);
            Action.UpdatePos(tree1);
            Action.UpdatePos(tree2);
            Action.UpdatePos(tree3);

            //newly added
            Action.UpdatePos(Enemy2);

            //Recognize objects that is not on the map from CollisionDetect
            Action.RecognizeObject(Enemy2);

        }


        private void ThirdMap_Load()
        {
            //Setup new Position
            tree1.updatePos(new Vector2(300, 150));
            tree2.updatePos(new Vector2(200, 200));
            tree3.updatePos(new Vector2(630, 280));
            tree4.updatePos(new Vector2(530, 400));
            player.updatePos(new Vector2(50, 300));

            //For enemy, change first position where they move back if they lost player
            Enemy1.FirstPos = new Vector2(700, 150);
            Enemy2.FirstPos = new Vector2(350, 100);

            //newly added
            Zelda.updatePos(new Vector2(700, 430));
            
            //ActionHandler needs to know updated position
            Action.UpdatePos(player);
            Action.UpdatePos(Enemy1);
            Action.UpdatePos(Enemy2);
            Action.UpdatePos(tree1);
            Action.UpdatePos(tree2);
            Action.UpdatePos(tree3);
            Action.UpdatePos(tree4);

            //newly added
            Action.UpdatePos(Zelda);

            //Recognize objects that is not on the map from CollisionDetect
            //Zelda added
            Action.RecognizeObject(Zelda);
            Action.RecognizeObject(tree4);
            Action.IgnoreObject(Arrow);

            //Zelda waits for player
            Zelda.gState = PrincessZelda.GameState.Waiting;
        }

        private void Escape1_Load()
        {
            //Setup new Position
            tree1.updatePos(new Vector2(200, 140));
            tree2.updatePos(new Vector2(300, 250));
            tree3.updatePos(new Vector2(500, 340));
            tree4.updatePos(new Vector2(600, 180));
            player.updatePos(new Vector2(100, 250));
            Zelda.updatePos(new Vector2(60, 250));

            //For enemy, change first position where they move back 
            Enemy1.FirstPos = new Vector2(700, 100);
            Enemy2.FirstPos = new Vector2(650, 350);

            //Enemy goes to right even if they cannot see the player
            Enemy1.updatePos(new Vector2(-150, 50));
            Enemy2.updatePos(new Vector2(-150, 400));
            Dragon1.updatePos(new Vector2(-250, 250));

            //ActionHandler needs to know updated position
            Action.UpdatePos(player);
            Action.UpdatePos(Enemy1);
            Action.UpdatePos(Enemy2);
            Action.UpdatePos(tree1);
            Action.UpdatePos(tree2);
            Action.UpdatePos(tree3);
            Action.UpdatePos(tree4);
            Action.UpdatePos(Dragon1);
            Action.UpdatePos(Zelda);

            //Zelda start following player to escape from dragon
            Zelda.gState = PrincessZelda.GameState.Escape;

            Action.RecognizeObject(Arrow);
            Action.RecognizeObject(Dragon1);
        }

        private void Escape2_Load()
        {
            //Setup new Position
            tree1.updatePos(new Vector2(100, 100));
            tree2.updatePos(new Vector2(300, 250));
            tree3.updatePos(new Vector2(500, 340));
            tree4.updatePos(new Vector2(120, 400));
            player.updatePos(new Vector2(50, 250));
            Zelda.updatePos(new Vector2(40, 300));

            //For enemy, change first position where they move back 
            Enemy1.FirstPos = new Vector2(700, 150);
            Enemy2.FirstPos = new Vector2(650, 350);
            //new
            Enemy3.FirstPos = new Vector2(700, 150);
            Enemy4.FirstPos = new Vector2(650, 350);

            //Enemy goes to right even if they cannot see the player
            Enemy1.updatePos(new Vector2(150, -50));
            Enemy2.updatePos(new Vector2(150, 600));
            Dragon1.updatePos(new Vector2(-150, 150));
            //new
            Enemy3.updatePos(new Vector2(600, -150));
            Enemy4.updatePos(new Vector2(600, 700));


            //ActionHandler needs to know updated position
            Action.UpdatePos(player);
            Action.UpdatePos(Enemy1);
            Action.UpdatePos(Enemy2);
            Action.UpdatePos(Enemy3);
            Action.UpdatePos(Enemy4);
            Action.UpdatePos(tree1);
            Action.UpdatePos(tree2);
            Action.UpdatePos(tree3);
            Action.UpdatePos(tree4);
            Action.UpdatePos(Dragon1);
            Action.UpdatePos(Zelda);

            //Recognize new objects
            Action.RecognizeObject(Enemy3);
            Action.RecognizeObject(Enemy4);

        }

        private void CollisionUpdate(GameTime gameTime)
        {
            //Checks if the enemy can see the player, return -999.-999 or player.pos
            Enemy1.TargetPosition = Action.Visibility(Enemy1.SpriteID, player.SpriteID);
            if ((int)MapState > 1) //After First Map 
                Enemy2.TargetPosition = Action.Visibility(Enemy2.SpriteID, player.SpriteID);
            if ((int)MapState > 2) //After Second Map
            {
                 Zelda.TargetPosition = Action.Visibility(Zelda.SpriteID, player.SpriteID);
            }
            if ((int)MapState > 3)
            {
                Dragon1.TargetPosition = Action.Visibility(Dragon1.SpriteID, player.SpriteID);
            }
            if ((int)MapState > 4) //After Escape1 Map
            {
                Enemy3.TargetPosition = Action.Visibility(Enemy3.SpriteID, player.SpriteID);
                Enemy4.TargetPosition = Action.Visibility(Enemy4.SpriteID, player.SpriteID);
            }

            //Player and Enemy movement
            player.CharacterUpdate(gameTime);
            Enemy1.EnemyUpdate(gameTime);
            if ((int)MapState > 1)
            {
                Enemy2.EnemyUpdate(gameTime);
            }
            if ((int)MapState > 2)
            {                
                Zelda.ZeldaUpdate(gameTime);
            }
            if ((int)MapState > 3)
            {
                Dragon1.EnemyUpdate(gameTime);
            }
            if ((int)MapState > 4)
            {
                Enemy3.EnemyUpdate(gameTime);
                Enemy4.EnemyUpdate(gameTime);
            }

            //Player and Enemy HandleSourceRectangle
            player.HandleSourceRect(gameTime);
            Enemy1.HandleSourceRect(gameTime);
            if ((int)MapState > 1)
                Enemy2.HandleSourceRect(gameTime);
            if ((int)MapState > 2)
            {                
                Zelda.HandleSourceRect(gameTime);
            }
            if ((int)MapState > 3)
            {
                Dragon1.HandleSourceRect(gameTime);
            }
            if ((int)MapState > 4)
            {
                Enemy3.HandleSourceRect(gameTime);
                Enemy4.HandleSourceRect(gameTime);
            }

            //ActionHandler needs to know updated position
            Action.UpdatePos(player);
            Action.UpdatePos(Enemy1);
            if ((int)MapState > 1)
                Action.UpdatePos(Enemy2);
            if ((int)MapState > 2)
            {
                 Action.UpdatePos(Zelda);
            }
            if ((int)MapState > 3)
            {
                Action.UpdatePos(Dragon1);
            }
            if ((int)MapState > 4)
            {
                Action.UpdatePos(Enemy3);
                Action.UpdatePos(Enemy4);
            }

            //Collision detection, moving back to non-collide position
            Action.SpriteCollision(ref player, audioCollisionRInst, audioCollisionLInst);
            Action.SpriteCollision(ref Enemy1);

            if ((int)MapState > 1)
                Action.SpriteCollision(ref Enemy2);
            if ((int)MapState > 2)
            {
                Action.SpriteCollision(ref Zelda);
            }
            if ((int)MapState > 3)
            {
                Action.SpriteCollision(ref Dragon1); 
            }
            if ((int)MapState > 4)
            {
                Action.SpriteCollision(ref Enemy3);
                Action.SpriteCollision(ref Enemy4);
            }

            //In collision check, also checked Lose and Win status
            player.status = (int)Action.PlayerState;
            Zelda.status = (int)Action.PlayerState;
        }


    }
}


