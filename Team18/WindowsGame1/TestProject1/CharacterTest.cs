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
    ///This is a test class for CharacterTest and is intended
    ///to contain all CharacterTest Unit Tests 
    ///</summary>
    [TestClass()]
    [DeploymentItem(@"Content\")]
    public class CharacterTest
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
         
        //You can use the following additional attributes as you write your tests:
        
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        
        #endregion


        /// <summary>
        ///A test for Character Constructor
        ///</summary>
        [TestMethod()]
        public void CharacterConstructorTest()
        {
            Character target = new Character();
            Assert.IsNotNull(target, "character is not created"); //need a better test? 
        }     

        /// <summary>
        ///A test for UpdateMovement of right key
        ///</summary>
        [TestMethod()]
        [DeploymentItem("WindowsGame1.exe")]
        public void UpdateMovementTestRight()
        {
            Character_Accessor target = new Character_Accessor();
            KeyboardState aCurrentKeyboardState = new KeyboardState(Keys.Right);
            target.UpdateMovement(aCurrentKeyboardState);
            Assert.IsTrue(target.mSpeed.X.Equals(150) && target.mDirection.X.Equals(1));//Check if direction and speed are correct
        }

        //Test left
        [TestMethod()]
        [DeploymentItem("WindowsGame1.exe")]
        public void UpdateMovementTestLeft()
        {
            Character_Accessor target = new Character_Accessor();
            KeyboardState aCurrentKeyboardState = new KeyboardState(Keys.Left);
            target.UpdateMovement(aCurrentKeyboardState);
            Assert.IsTrue(target.mSpeed.X.Equals(150) && target.mDirection.X.Equals(-1));//Check if direction and speed are correct
        }


        //Test Up
        [TestMethod()]
        [DeploymentItem("WindowsGame1.exe")]
        public void UpdateMovementTestUp()
        {
            Character_Accessor target = new Character_Accessor();
            KeyboardState aCurrentKeyboardState = new KeyboardState(Keys.Up);
            target.UpdateMovement(aCurrentKeyboardState);
            Assert.IsTrue(target.mSpeed.Y.Equals(150) && target.mDirection.Y.Equals(-1));//Check if direction and speed are correct
        }

        //Test down
        [TestMethod()]
        [DeploymentItem("WindowsGame1.exe")]
        public void UpdateMovementTestDown()
        {
            Character_Accessor target = new Character_Accessor();
            KeyboardState aCurrentKeyboardState = new KeyboardState(Keys.Down);
            target.UpdateMovement(aCurrentKeyboardState);
            Assert.IsTrue(target.mSpeed.Y.Equals(150) && target.mDirection.Y.Equals(1));//Check if direction and speed are correct
        }
   
        /// <summary>
        ///A test for CharacterUpdate
        ///</summary>
        [TestMethod()]
        public void CharacterUpdateTest()
        {
            Character target = new Character(); // TODO: Initialize to an appropriate value
            GameTime theGameTime = null; // TODO: Initialize to an appropriate value
            target.CharacterUpdate(theGameTime);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }      

        /// <summary>
        ///A test for status
        ///</summary>
        [TestMethod()]
        public void statusTest()
        {
            Character target = new Character(); 
            int expected = 1; 
            int actual;
            target.status = expected;
            actual = target.status;
            Assert.AreEqual(expected, actual);            
        }
    }
}
