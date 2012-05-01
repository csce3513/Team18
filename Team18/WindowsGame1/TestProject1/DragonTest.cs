using WindowsGame1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for DragonTest and is intended
    ///to contain all DragonTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DragonTest
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
        ///A test for Dragon Constructor
        ///</summary>
        [TestMethod()]
        public void DragonConstructorTest()
        {
            Dragon target = new Dragon();
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for EnemyUpdate
        ///</summary>
        [TestMethod()]
        public void EnemyUpdateTest()
        {
            Dragon target = new Dragon(); // TODO: Initialize to an appropriate value
            GameTime theGameTime = null; // TODO: Initialize to an appropriate value
            target.EnemyUpdate(theGameTime);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
   
        /// <summary>
        ///A test for UpdateMovement
        ///</summary>
        [TestMethod()]
        [DeploymentItem("WindowsGame1.exe")]
        public void UpdateMovementTest()
        {
            Dragon_Accessor target = new Dragon_Accessor();
            target.TargetPosition = (new Vector2(200, 300));//Player Position
            Vector2 CurrentPos = new Vector2(100, 200); //Current Position
            target.pos = (CurrentPos);//Set Current Position to Enemy Character
            target.UpdateMovement();
            Assert.IsTrue(target.mDirection == new Vector2(1, 1), "Direction(1,1) Fail");

            CurrentPos = new Vector2(150, 400);
            target.pos = (CurrentPos);
            target.UpdateMovement();
            Assert.IsTrue(target.mDirection == new Vector2(1, -1), "Direction(1,-1) Fail");

            CurrentPos = new Vector2(300, 250);
            target.pos = (CurrentPos);
            target.UpdateMovement();
            Assert.IsTrue(target.mDirection == new Vector2(-1, 1), "Direction(-1,1) Fail");
        }

        /// <summary>
        ///A test for TargetPosition
        ///</summary>
        [TestMethod()]
        public void TargetPositionTest()
        {
            Dragon target = new Dragon(); // TODO: Initialize to an appropriate value
            Vector2 expected = new Vector2(300, 400);
            Vector2 actual;
            target.TargetPosition = expected;
            actual = target.TargetPosition;
            Assert.AreEqual(expected, actual);
        }
    }
}
