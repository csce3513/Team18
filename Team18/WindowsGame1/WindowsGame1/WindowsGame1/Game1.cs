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

        ActionHandler Collide;

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

            Collide = new ActionHandler();
                       

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

            tree1.LoadContent(this.Content, "Tree");
            tree2.LoadContent(this.Content, "Tree");
            tree3.LoadContent(this.Content, "Tree");

            //Size modification
            tree1.Scale = 0.8f;
            tree2.Scale = 0.8f;
            tree3.Scale = 0.8f;
      
            //Set Position
            tree1.updatePos(new Vector2(200, 200));
            tree2.updatePos(new Vector2(0, 0));
            tree3.updatePos(new Vector2(500, 100));

            player.LoadContent(this.Content);
            player.Scale = 1.5f;

            Enemy1.LoadContent(this.Content);

            //Add object information to ActionHandler
            Collide.addObject(player.pos, player.SpriteID, player.Texture.Height*1.5 -8 , player.Texture.Width* 1.5 -5);
            Collide.addObject(tree1.pos, tree1.SpriteID, tree1.getTex().Height * 0.8, tree1.getTex().Width * 0.8);
            Collide.addObject(tree2.pos, tree2.SpriteID, tree2.getTex().Height * 0.8, tree2.getTex().Width * 0.8);
            Collide.addObject(tree3.pos, tree3.SpriteID, tree3.getTex().Height * 0.8, tree3.getTex().Width * 0.8);
            Collide.addObject(Enemy1.pos, Enemy1.SpriteID, Enemy1.getTex().Height, Enemy1.getTex().Width);

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
            else if (state == gamestate.play)
            {
                Vector2 lastPos = player.pos;

                // GO to Menu state
                if ((keystate.IsKeyDown(Keys.Escape) == true)
                    && (lastKeyState.IsKeyUp(Keys.Escape) == true))
                    state = gamestate.menu;
                         
                //Player movement
                player.Update(gameTime);

                //ActionHandler needs to know updated position
                Collide.UpdatePos(player.SpriteID, player.pos);

                //Collision detection.
                if (Collide.CollisionCheck(player.SpriteID))
                    player.pos = lastPos;
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
