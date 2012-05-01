using WindowsGame1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
//using Moq;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for SpriteTest and is intended
    ///to contain all SpriteTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SpriteTest
    {
        //private GraphicsDevice MockedGraphicDevice()
        //{
        //    Mock<GraphicsDevice> mock = new Mock<GraphicsDevice>();
        //    mock.Setup(m => m.Adapter.DeviceName).Returns<GraphicsAdapter>(null);
        //    mock.Setup(m => m.GraphicsProfile).Returns<GraphicsProfile>(null);
        //    mock.Setup(m => m.PresentationParameters).Returns<PresentationParameters>(null);
        //    return mock.Object;
        //}

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
        ///A test for Sprite Constructor
        ///Testing pos and scale
        ///</summary>
        [TestMethod()]
        public void SpriteConstructorTest1()
        {
            Vector2 test = new Vector2(0,0);
            Sprite target = new Sprite();
            Assert.IsTrue(target.getPos() == test, "pos is not 0,0");    
            Assert.IsTrue(target.Scale == 1.0f, "Scale is not 1.0f");
        }

        /// <summary>
        ///A test for Draw
        ///</summary>
        //[TestMethod()]
        //public void DrawTest_Spr() // BUG: Mocking GraphicDevice is needed
        //{
        //    Game1 game = new Game1(); 
        //    Sprite target = new Sprite();
        //    SpriteBatch theSpriteBatch = new SpriteBatch(target.MockedGraphicDevice());
        //    target.Draw(theSpriteBatch);
        //    Assert.IsNotNull(target.getTex());
        //}

        /// <summary>
        ///A test for LoadContent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Content/test.png", "Content")]
        public void LoadContentTest_Spr() // BUG: Mocking GraphicDevice is needed
        {
            Game1 game = new Game1(); 
            Sprite target = new Sprite(); 
            ContentManager theContentManager = game.Content;
            string theAssetName = "test"; 
            target.LoadContent(theContentManager, theAssetName);
            Assert.IsNotNull(target.getTex());
        }

        /// <summary>
        ///A test for Update
        ///Testing the position has been changed by movement
        ///</summary>
        [TestMethod()]
        public void UpdateTest_Spr()
        {
            Sprite target = new Sprite();
            TimeSpan span = new TimeSpan(0,0,0,0,100); //100 milisecond
            GameTime theGameTime = new GameTime(span, span); 
            Vector2 theSpeed = new Vector2(160, 0);
            Vector2 theDirection = new Vector2(-1, 0);
            Vector2 lastPos = target.getPos();
            target.Update(theGameTime, theSpeed, theDirection);
            Assert.IsFalse(lastPos == target.getPos());
        }

        /// <summary>
        ///A test for updatePos
        ///Test changing position without movement 
        ///</summary>
        [TestMethod()]
        public void updatePosTest_Spr()
        {
            Sprite target = new Sprite(); 
            Vector2 newPos = new Vector2(120, 350);
            Vector2 lastPos = target.getPos();
            target.updatePos(newPos);
            Assert.IsFalse(lastPos == target.getPos());
        }

        /// <summary>
        ///A test for Scale
        ///</summary>
        [TestMethod()] 
        public void ScaleTest1()//Mocking GraphicDevice is needed
        {
            Sprite target = new Sprite(); 
            float expected = 2.0F;  
            float actual;
            target.Scale = expected;
            actual = target.Scale;
            Assert.AreEqual(expected, actual);
            Assert.IsTrue(target.Scale == 2.0F);
        }

        /// <summary>
        ///A test for Sprite Constructor
        ///</summary>
        [TestMethod()]
        public void SpriteConstructorTest()
        {
            int ID = 0; // TODO: Initialize to an appropriate value
            Sprite target = new Sprite(ID);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Sprite Constructor
        ///</summary>
        [TestMethod()]
        public void SpriteConstructorTest2()
        {
            Sprite target = new Sprite();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Draw
        ///</summary>
        [TestMethod()]
        public void DrawTest()
        {
            Sprite target = new Sprite(); // TODO: Initialize to an appropriate value
            SpriteBatch theSpriteBatch = null; // TODO: Initialize to an appropriate value
            target.Draw(theSpriteBatch);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LoadContent
        ///</summary>
        [TestMethod()]
        public void LoadContentTest()
        {
            Sprite target = new Sprite(); // TODO: Initialize to an appropriate value
            ContentManager theContentManager = null; // TODO: Initialize to an appropriate value
            string theAssetName = string.Empty; // TODO: Initialize to an appropriate value
            target.LoadContent(theContentManager, theAssetName);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            Sprite target = new Sprite(); // TODO: Initialize to an appropriate value
            GameTime gameTime = null; // TODO: Initialize to an appropriate value
            target.Update(gameTime);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

    
        /// <summary>
        ///A test for getPos
        ///</summary>
        [TestMethod()]
        public void getPosTest()
        {
            Sprite target = new Sprite(); // TODO: Initialize to an appropriate value
            Vector2 expected = new Vector2(); // TODO: Initialize to an appropriate value
            Vector2 actual;
            actual = target.getPos();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SpriteID
        ///</summary>
        [TestMethod()]
        public void SpriteIDTest()
        {
            Sprite target = new Sprite(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.SpriteID = expected;
            actual = target.SpriteID;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for pos
        ///</summary>
        [TestMethod()]
        public void posTest()
        {
            Sprite target = new Sprite(); // TODO: Initialize to an appropriate value
            Vector2 expected = new Vector2(); // TODO: Initialize to an appropriate value
            Vector2 actual;
            target.pos = expected;
            actual = target.pos;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
