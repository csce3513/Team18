using WindowsGame1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;


namespace TestProject1 
{
    
    
    /// <summary>
    ///This is a test class for Game1Test and is intended
    ///to contain all Game1Test Unit Tests
    ///</summary>
    [TestClass()]
    public class Game1Test
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        /// <summary>
        ///A test for Game1 Constructor
        ///Test RootDirectory is correct
        ///</summary>
        [TestMethod()]
        public void Game1_AddObjects(Game1_Accessor target)   
        {
            target.Initialize();

            target.Action.addObject(target.player.pos, target.player.SpriteID, 30 * 1.5f - 20, 26 * 1.5f - 8);
            target.Action.addObject(target.tree1.pos, target.tree1.SpriteID, 100 * 0.7f, 120 * 0.7f);
            target.Action.addObject(target.tree2.pos, target.tree2.SpriteID, 100 * 0.7f, 120 * 0.7f);
            target.Action.addObject(target.tree3.pos, target.tree3.SpriteID, 100 * 0.7f, 120 * 0.7f);
            target.Action.addObject(target.tree4.pos, target.tree4.SpriteID, 100 * 0.7f, 120 * 0.7f);
            target.Action.addObject(target.tree5.pos, target.tree5.SpriteID, 100 * 0.7f, 120 * 0.7f);
            target.Action.addObject(target.Enemy1.pos, target.Enemy1.SpriteID, 44, 34);
            target.Action.addObject(target.Enemy2.pos, target.Enemy2.SpriteID, 44, 34);
            target.Action.addObject(target.Enemy3.pos, target.Enemy3.SpriteID, 44, 34);
            target.Action.addObject(target.Enemy4.pos, target.Enemy4.SpriteID, 44, 34);
            target.Action.addObject(target.Dragon1.pos, target.Dragon1.SpriteID, 85, 85);
            target.Action.addObject(target.Zelda.pos, target.Zelda.SpriteID, 20 * 1.5f, 28 * 1.5f);
            target.Action.addObject(new Vector2(775, 250), target.Arrow.SpriteID, 30 * 1.5f, 30 * 1.5f);
        }
        
        /// <summary>
        ///A test for Game1 Constructor
        ///Test RootDirectory is correct
        ///</summary>
        [TestMethod()]
        public void Game1ConstructorTest1()
        {
            Game1 target = new Game1();
            Assert.IsTrue(target.Content.RootDirectory.Equals("Content"));
        }

        /// <summary>
        ///A test for Draw
        ///
        ///</summary>
        [TestMethod()]
        [DeploymentItem("WindowsGame1.exe")]
        public void DrawTest_game1()  
        {
            Game1_Accessor target = new Game1_Accessor();
            GameTime gameTime = new GameTime(); 
            target.Draw(gameTime); 
            Assert.IsTrue(target.player != null);
        }

        /// <summary>
        ///A test for Update
        ///Test keystate is not null, and first state is menu
        ///</summary>
        [TestMethod()]
        [DeploymentItem("WindowsGame1.exe")]
        public void UpdateTest1_Menu()
        {
            Game1_Accessor target = new Game1_Accessor();
            GameTime gameTime = new GameTime();
            target.Update(gameTime);
            Assert.IsNotNull(target.keystate, "keystate is null");
            Assert.IsNotNull(target.lastKeyState, "lastKeystate is null");
            Assert.IsTrue(target.state.value__ == 0, "state is play");
        }



        /// <summary>
        ///A test for LoadContent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("WindowsGame1.exe")]
        public void LoadContentTest_Game1() 
        {
            Game1_Accessor target = new Game1_Accessor(); // TODO: Initialize to an appropriate value
            target.LoadContent();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }






        /// <summary>
        ///A test for Game1 Constructor
        ///</summary>
        [TestMethod()]
        public void Game1ConstructorTest()
        {
            Game1 target = new Game1();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for CollisionUpdate
        ///</summary>
        [TestMethod()]
        [DeploymentItem("WindowsGame1.exe")]
        public void CollisionUpdateTest()
        {
            Game1_Accessor target = new Game1_Accessor(); // TODO: Initialize to an appropriate value
            GameTime gameTime = null; // TODO: Initialize to an appropriate value
            target.CollisionUpdate(gameTime);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Draw
        ///</summary>
        [TestMethod()]
        [DeploymentItem("WindowsGame1.exe")]
        public void DrawTest()
        {
            Game1_Accessor target = new Game1_Accessor(); // TODO: Initialize to an appropriate value
            GameTime gameTime = null; // TODO: Initialize to an appropriate value
            target.Draw(gameTime);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        
        /// <summary>
        ///A test for Initialize
        ///</summary>
        [TestMethod()]
        [DeploymentItem("WindowsGame1.exe")]
        public void InitializeTest()
        {
            Game1_Accessor target = new Game1_Accessor(); // TODO: Initialize to an appropriate value
            target.Initialize();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LoadContent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("WindowsGame1.exe")]
        public void LoadContentTest()
        {
            Game1_Accessor target = new Game1_Accessor(); // TODO: Initialize to an appropriate value
            target.LoadContent();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SecondMap_Load
        ///This will test if Player and Enemy placement are correct. 
        ///No collisions are allowed at First placement on the Map  except trees.
        ///</summary>
        [TestMethod()]
        [DeploymentItem("WindowsGame1.exe")]
        public void SecondMap_LoadTest()
        {
            Game1_Accessor target = new Game1_Accessor(); 
            Game1_AddObjects(target);//Adding Objects to CollisionHandler
            target.SecondMap_Load();
            Assert.IsTrue(target.Action.CollisionCheck(0) == new Vector2 (0, 0) , "ID_0: CollisionDetected");
            Assert.IsTrue(target.Action.CollisionCheck(201) == new Vector2(0, 0), "ID_201: CollisionDetected");
            Assert.IsTrue(target.Action.CollisionCheck(203) == new Vector2(0, 0), "ID_203: CollisionDetected");
        }

        /// <summary>
        ///A test for StartMap_Load
        ///This will test if Player and Enemy placement are correct. 
        ///No collisions are allowed at First placement on the Map  except trees.
        ///</summary>
        [TestMethod()]
        [DeploymentItem("WindowsGame1.exe")]
        public void StartMap_LoadTest()
        {
            Game1_Accessor target = new Game1_Accessor();
            Game1_AddObjects(target);//Adding Objects to CollisionHandler
            target.StartMap_Load();
            Assert.IsTrue(target.Action.CollisionCheck(0) == new Vector2(0, 0), "ID_0: CollisionDetected");
            Assert.IsTrue(target.Action.CollisionCheck(201) == new Vector2(0, 0), "ID_201: CollisionDetected");
        }

        /// <summary>
        ///A test for ThirdMap_Load
        ///This will test if Player and Enemy placement are correct. 
        ///No collisions are allowed at First placement on the Map  except trees.
        ///</summary>
        [TestMethod()]
        [DeploymentItem("WindowsGame1.exe")]
        public void ThirdMap_LoadTest()
        {
            Game1_Accessor target = new Game1_Accessor();
            Game1_AddObjects(target);//Adding Objects to CollisionHandler
            target.ThirdMap_Load();
            Assert.IsTrue(target.Action.CollisionCheck(0) == new Vector2(0, 0), "ID_0: CollisionDetected");
            Assert.IsTrue(target.Action.CollisionCheck(201) == new Vector2(0, 0), "ID_201: CollisionDetected");
            Assert.IsTrue(target.Action.CollisionCheck(203) == new Vector2(0, 0), "ID_203: CollisionDetected");
            Assert.IsTrue(target.Action.CollisionCheck(1) == new Vector2(0, 0), "ID_1: CollisionDetected");
        }

        /// <summary>
        ///A test for Escape1_Load
        ///This will test if Player and Enemy placement are correct. 
        ///No collisions are allowed at First placement on the Map  except trees.
        ///</summary>
        [TestMethod()]
        [DeploymentItem("WindowsGame1.exe")]
        public void Escape1_LoadTest()
        {
            Game1_Accessor target = new Game1_Accessor();
            Game1_AddObjects(target);//Adding Objects to CollisionHandler
            target.Escape1_Load(); 
            Assert.IsTrue(target.Action.CollisionCheck(0) == new Vector2(0, 0), "ID_0: CollisionDetected");
            Assert.IsTrue(target.Action.CollisionCheck(201) == new Vector2(0, 0), "ID_201: CollisionDetected");
            Assert.IsTrue(target.Action.CollisionCheck(203) == new Vector2(0, 0), "ID_203: CollisionDetected");
            Assert.IsTrue(target.Action.CollisionCheck(1) == new Vector2(0, 0), "ID_1: CollisionDetected");
            Assert.IsTrue(target.Action.CollisionCheck(202) == new Vector2(0, 0), "ID_202: CollisionDetected");
        }

        /// <summary>
        ///A test for Escape2_Load
        ///This will test if Player and Enemy placement are correct. 
        ///No collisions are allowed at First placement on the Map  except trees.
        ///</summary>
        [TestMethod()]
        [DeploymentItem("WindowsGame1.exe")]
        public void Escape2_LoadTest()
        {
            Game1_Accessor target = new Game1_Accessor();
            Game1_AddObjects(target);//Adding Objects to CollisionHandler
            target.Escape2_Load();
            Assert.IsTrue(target.Action.CollisionCheck(0) == new Vector2(0, 0), "ID_0: CollisionDetected");
            Assert.IsTrue(target.Action.CollisionCheck(201) == new Vector2(0, 0), "ID_201: CollisionDetected");
            Assert.IsTrue(target.Action.CollisionCheck(203) == new Vector2(0, 0), "ID_203: CollisionDetected");
            Assert.IsTrue(target.Action.CollisionCheck(1) == new Vector2(0, 0), "ID_1: CollisionDetected");
            Assert.IsTrue(target.Action.CollisionCheck(202) == new Vector2(0, 0), "ID_202: CollisionDetected");
            Assert.IsTrue(target.Action.CollisionCheck(204) == new Vector2(0, 0), "ID_204: CollisionDetected");
            Assert.IsTrue(target.Action.CollisionCheck(205) == new Vector2(0, 0), "ID_205: CollisionDetected");
        }


        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        [DeploymentItem("WindowsGame1.exe")]
        public void UpdateTest_Game()  
        {
            Game1_Accessor target = new Game1_Accessor();
            GameTime gameTime = new GameTime();
            target.state = Game1_Accessor.gamestate.menu;
            KeyboardState aCurrentKeyboardState = new KeyboardState(Keys.Space);
            target.Initialize();
            target.Update(gameTime);
            Assert.IsTrue(target.state == Game1_Accessor.gamestate.story1, "Not moved to Story1");
       }
    }
}
