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

        Character player;

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

            //Backgrounds
            menu = new Sprite();
            BG0 = new Sprite();

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
            BG0.LoadContent(this.Content, "Forest 01a");
            BG0.updatePos(new Vector2(-500, -500));

            player.LoadContent(this.Content);

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

                if ((keystate.IsKeyDown(Keys.Space) == true)
                    && (lastKeyState.IsKeyUp(Keys.Space) == true))
                {
                    state = gamestate.play;
                }
            }
            else if (state == gamestate.play)
            {
                if ((keystate.IsKeyDown(Keys.Escape) == true)
                    && (lastKeyState.IsKeyUp(Keys.Escape) == true))
                    state = gamestate.menu;

                player.Update(gameTime);
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
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            if (state == gamestate.menu)
            {
                menu.Draw(this.spriteBatch);
            }

            if (state == gamestate.play)
            {
                BG0.Draw(this.spriteBatch);

                player.Draw(this.spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}
