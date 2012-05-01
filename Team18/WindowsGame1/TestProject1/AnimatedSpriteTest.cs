using WindowsGame1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for AnimatedSpriteTest and is intended
    ///to contain all AnimatedSpriteTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AnimatedSpriteTest
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
        ///A test for AnimatedSprite Constructor
        ///</summary>
        [TestMethod()]
        public void AnimatedSpriteConstructorTest()
        {
            AnimatedSprite target = new AnimatedSprite();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Animation
        ///</summary>
        [TestMethod()]
        public void AnimationTest()
        {
            AnimatedSprite target = new AnimatedSprite(); // TODO: Initialize to an appropriate value
            ContentManager content = null; // TODO: Initialize to an appropriate value
            string assetName = string.Empty; // TODO: Initialize to an appropriate value
            int spriteWidth = 0; // TODO: Initialize to an appropriate value
            int spriteHeight = 0; // TODO: Initialize to an appropriate value
            int numberOfFrames = 0; // TODO: Initialize to an appropriate value
            target.Animation(content, assetName, spriteWidth, spriteHeight, numberOfFrames);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for HandleSourceRect
        ///</summary>
        [TestMethod()]
        public void HandleSourceRectTest()
        {
            AnimatedSprite target = new AnimatedSprite();
            TimeSpan span = new TimeSpan(0, 0, 0, 0, 100);
            GameTime gameTime = new GameTime(span, span);
            target.HandleSourceRect(gameTime);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for animateDraw
        ///</summary>
        [TestMethod()]
        public void animateDrawTest()
        {
            AnimatedSprite target = new AnimatedSprite(); // TODO: Initialize to an appropriate value
            SpriteBatch theSpriteBatch = null; // TODO: Initialize to an appropriate value
            target.animateDraw(theSpriteBatch);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Origin
        ///</summary>
        [TestMethod()]
        public void OriginTest()
        {
            AnimatedSprite target = new AnimatedSprite(); // TODO: Initialize to an appropriate value
            Vector2 expected = new Vector2(); // TODO: Initialize to an appropriate value
            Vector2 actual;
            target.Origin = expected;
            actual = target.Origin;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Position
        ///</summary>
        [TestMethod()]
        public void PositionTest()
        {
            AnimatedSprite target = new AnimatedSprite(); // TODO: Initialize to an appropriate value
            Vector2 expected = new Vector2(300, 400);
            Vector2 actual;
            target.Position = expected;
            actual = target.Position;
            Assert.AreEqual(expected, actual);
        }    
    }
}
