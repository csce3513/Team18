﻿using WindowsGame1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for EnemyCharacterTest and is intended
    ///to contain all EnemyCharacterTest Unit Tests
    ///</summary>
    [TestClass()]
    public class EnemyCharacterTest
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
        ///A test for TargetPosition
        ///</summary>
        [TestMethod()]
        public void TargetPositionTest()
        {
            EnemyCharacter target = new EnemyCharacter(); // TODO: Initialize to an appropriate value
            Vector2 expected = new Vector2(); // TODO: Initialize to an appropriate value
            Vector2 actual;
            target.TargetPosition = expected;
            actual = target.TargetPosition;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LoadContent
        ///</summary>
        [TestMethod()]
        public void LoadContentTest()
        {
            EnemyCharacter target = new EnemyCharacter(); // TODO: Initialize to an appropriate value
            ContentManager theContentManager = null; // TODO: Initialize to an appropriate value
            target.LoadContent(theContentManager);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for EnemyUpdate
        ///</summary>
        [TestMethod()]
        public void EnemyUpdateTest()
        {
            EnemyCharacter target = new EnemyCharacter(); // TODO: Initialize to an appropriate value
            GameTime theGameTime = null; // TODO: Initialize to an appropriate value
            target.EnemyUpdate(theGameTime);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for EnemyCharacter Constructor
        ///</summary>
        [TestMethod()]
        public void EnemyCharacterConstructorTest()
        {
            EnemyCharacter target = new EnemyCharacter();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }



        /// <summary>
        ///A test for UpdateMovement
        ///</summary>
        [TestMethod()]
        [DeploymentItem("WindowsGame1.exe")]
        public void UpdateMovementTest()
        {
            EnemyCharacter_Accessor target = new EnemyCharacter_Accessor(); // TODO: Initialize to an appropriate value
            target.UpdateMovement();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

    }
}