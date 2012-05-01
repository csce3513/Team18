using WindowsGame1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.Xna.Framework.Audio;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for CollisionTest and is intended
    ///to contain all CollisionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CollisionTest
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
        ///A test for Collision Constructor
        ///</summary>
        [TestMethod()]
        public void CollisionConstructorTest()
        {
            Collision target = new Collision();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for SpriteCollision
        ///</summary>
        [TestMethod()]
        public void SpriteCollisionTest()
        {
            Collision target = new Collision(); // TODO: Initialize to an appropriate value
            PrincessZelda name = null; // TODO: Initialize to an appropriate value
            PrincessZelda nameExpected = null; // TODO: Initialize to an appropriate value
            target.SpriteCollision(ref name);
            Assert.AreEqual(nameExpected, name);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SpriteCollision
        ///</summary>
        [TestMethod()]
        public void SpriteCollisionTest1()
        {
            Collision target = new Collision(); // TODO: Initialize to an appropriate value
            Character name = null; // TODO: Initialize to an appropriate value
            Character nameExpected = null; // TODO: Initialize to an appropriate value
            SoundEffectInstance song6Inst = null; // TODO: Initialize to an appropriate value
            SoundEffectInstance song7Inst = null; // TODO: Initialize to an appropriate value
            target.SpriteCollision(ref name, song6Inst, song7Inst);
            Assert.AreEqual(nameExpected, name);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SpriteCollision
        ///</summary>
        [TestMethod()]
        public void SpriteCollisionTest2()
        {
            Collision target = new Collision(); // TODO: Initialize to an appropriate value
            EnemyCharacter name = null; // TODO: Initialize to an appropriate value
            EnemyCharacter nameExpected = null; // TODO: Initialize to an appropriate value
            target.SpriteCollision(ref name);
            Assert.AreEqual(nameExpected, name);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SpriteCollision
        ///</summary>
        [TestMethod()]
        public void SpriteCollisionTest3()
        {
            Collision target = new Collision(); // TODO: Initialize to an appropriate value
            Dragon name = null; // TODO: Initialize to an appropriate value
            Dragon nameExpected = null; // TODO: Initialize to an appropriate value
            target.SpriteCollision(ref name);
            Assert.AreEqual(nameExpected, name);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
