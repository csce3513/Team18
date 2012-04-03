using WindowsGame1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Microsoft.Xna.Framework;

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
        ///A test for Initialize
        ///Test Initializad values are not null
        ///</summary>
        [TestMethod()]
        [DeploymentItem("WindowsGame1.exe")]
        public void InitializeTest1()
        {
            Game1_Accessor target = new Game1_Accessor();
            target.Initialize();
            Assert.IsTrue(target.state != null && target.player != null
                && target.menu != null && target.BG0 != null);
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

       
      

        
    }
}
