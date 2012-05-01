using WindowsGame1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for PrincessZeldaTest and is intended
    ///to contain all PrincessZeldaTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PrincessZeldaTest
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
        ///A test for PrincessZelda Constructor
        ///</summary>
        [TestMethod()]
        public void PrincessZeldaConstructorTest()
        {
            PrincessZelda target = new PrincessZelda();
            Assert.IsNotNull(target);
        }
       
        /// <summary>
        ///A test for UpdateMovement
        ///This will test if the Princess would wait
        ///player before saved and follow the player after saved.
        ///</summary>
        [TestMethod()]
        [DeploymentItem("WindowsGame1.exe")]
        public void UpdateMovementTest_Zelda()
        {
            PrincessZelda_Accessor target = new PrincessZelda_Accessor();
            target.TargetPosition = (new Vector2(200, 300));//Player Position
            target.currentRow = 0;//Animation State
            target.gState = PrincessZelda_Accessor.GameState.Waiting;//Zelda waits for player

            Vector2 CurrentPos = new Vector2(100, 400); //Current Position
            target.pos = (CurrentPos);//Set Current Position to Zelda
            target.UpdateMovement();
            Assert.IsTrue(target.mDirection == new Vector2(0, 0), "Direction(0,0) Fail");
            Assert.IsTrue(target.currentRow == 1, "Animation is not Default");

            target.gState = PrincessZelda_Accessor.GameState.Escape;//Zelda follow the player
            target.UpdateMovement();
            Assert.IsTrue(target.mDirection == new Vector2(1, -1), "Direction(1 ,-1) Fail");
            Assert.IsTrue(target.currentRow == 2, "Animation is not moving up");
            
            CurrentPos = new Vector2(100, 285);
            target.pos = (CurrentPos);
            target.UpdateMovement();
            Assert.IsTrue(target.mDirection == new Vector2(1, 0), "Direction(1,0) Fail");
            Assert.IsTrue(target.currentRow == 4, "Animation is not moving right");
            
            CurrentPos = new Vector2(300, 285);
            target.pos = (CurrentPos);
            target.UpdateMovement();
            Assert.IsTrue(target.mDirection == new Vector2(-1, 0), "Direction(-1, 0) Fail");
            Assert.IsTrue(target.currentRow == 0, "Animation is not moving left");
        }

        /// <summary>
        ///A test for ZeldaUpdate
        ///</summary>
        [TestMethod()]
        public void ZeldaUpdateTest()
        {
            PrincessZelda target = new PrincessZelda(); // TODO: Initialize to an appropriate value
            GameTime theGameTime = null; // TODO: Initialize to an appropriate value
            target.ZeldaUpdate(theGameTime);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for TargetPosition
        ///</summary>
        [TestMethod()]
        public void TargetPositionTest()
        {
            PrincessZelda target = new PrincessZelda(); // TODO: Initialize to an appropriate value
            Vector2 expected = new Vector2(300, 400);
            Vector2 actual;
            target.TargetPosition = expected;
            actual = target.TargetPosition;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for status
        ///</summary>
        [TestMethod()]
        public void statusTest()
        {
            PrincessZelda target = new PrincessZelda(); // TODO: Initialize to an appropriate value
            int expected = 1; // TODO: Initialize to an appropriate value
            int actual;
            target.status = expected;
            actual = target.status;
            Assert.AreEqual(expected, actual);
        }
    }
}
