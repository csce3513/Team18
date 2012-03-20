using WindowsGame1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for SpriteTest and is intended
    ///to contain all SpriteTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SpriteTest
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
        ///A test for Sprite Constructor
        ///</summary>
        [TestMethod()]
        public void SpriteConstructorTest()
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
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void UpdateTest1()
        {
            Sprite target = new Sprite(); // TODO: Initialize to an appropriate value
            GameTime theGameTime = null; // TODO: Initialize to an appropriate value
            Vector2 theSpeed = new Vector2(); // TODO: Initialize to an appropriate value
            Vector2 theDirection = new Vector2(); // TODO: Initialize to an appropriate value
            target.Update(theGameTime, theSpeed, theDirection);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for updatePos
        ///</summary>
        [TestMethod()]
        public void updatePosTest()
        {
            Sprite target = new Sprite(); // TODO: Initialize to an appropriate value
            Vector2 newPos = new Vector2(); // TODO: Initialize to an appropriate value
            target.updatePos(newPos);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Scale
        ///</summary>
        [TestMethod()]
        public void ScaleTest()
        {
            Sprite target = new Sprite(); // TODO: Initialize to an appropriate value
            float expected = 0F; // TODO: Initialize to an appropriate value
            float actual;
            target.Scale = expected;
            actual = target.Scale;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
