using WindowsGame1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.Xna.Framework;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for ActionHandlerTest and is intended
    ///to contain all ActionHandlerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ActionHandlerTest
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
        ///A test for ActionHandler Constructor
        ///</summary>
        [TestMethod()]
        public void ActionHandlerConstructorTest()
        {
            ActionHandler target = new ActionHandler();
            Assert.IsNotNull(target);
        }

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
        ///A test for CollisionCheck
        ///</summary>
        [TestMethod()]
        public void CollisionCheckTest()
        {
            ActionHandler target = new ActionHandler(); // TODO: Initialize to an appropriate value
            int ID = 0; // TODO: Initialize to an appropriate value
            Vector2 expected = new Vector2(0,0); // TODO: Initialize to an appropriate value
            Vector2 actual;
            actual = target.CollisionCheck(ID);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for CollisionDetect
        ///No Collision Detected
        ///</summary>
        [TestMethod()]
        [DeploymentItem("WindowsGame1.exe")]
        public void CollisionDetectTest()
        {
            ActionHandler_Accessor target = new ActionHandler_Accessor();
            //Object Assignment
            //Add objects to Position, Height, Width List
            target.addObject(new Vector2(100,210), 0, 30, 30);
            target.addObject(new Vector2(200, 200), 101, 90, 90);
            target.addObject(new Vector2(0, 0), 102, 90, 90);
            target.addObject(new Vector2(500, 100), 103, 90, 90);
            target.addObject(new Vector2(600, 250), 201, 35, 35);          
            int n = 0; // Character
            int m = 1; // Object1
            Vector2 expected = new Vector2(0,0); //No Collision
            Vector2 actual;
            actual = target.CollisionDetect(n, m);
            Assert.AreEqual(expected, actual); //True
         }
        
        /// <summary>
        ///A test for CollisionDetect
        ///Collision Detected
        ///</summary>
        [TestMethod()]
        [DeploymentItem("WindowsGame1.exe")]
        public void CollisionDetectTest1()
        {
            ActionHandler_Accessor target = new ActionHandler_Accessor();
            //Object Assignment
            //Character Position is Changed
            target.addObject(new Vector2(190, 210), 0, 30, 30);
            target.addObject(new Vector2(200, 200), 101, 90, 90);
            target.addObject(new Vector2(0, 0), 102, 90, 90);
            target.addObject(new Vector2(500, 100), 103, 90, 90);
            target.addObject(new Vector2(600, 250), 201, 35, 35);
            int n = 0; // Character
            int m = 1; // Object1
            Vector2 expected = new Vector2(0, 0); //No Collision
            Vector2 actual;
            actual = target.CollisionDetect(n, m);
            Assert.AreNotEqual(expected, actual); //NotEqual is True
        }

        /// <summary>
        ///A test for Visibility
        ///Enemy found Character
        ///</summary>
        [TestMethod()]
        public void VisibilityTest()
        {
            ActionHandler target = new ActionHandler();
            //Object Assignment
            target.addObject(new Vector2(300, 250), 0, 30, 30);
            target.addObject(new Vector2(100, 100), 101, 90, 90);
            target.addObject(new Vector2(0, 0), 102, 90, 90);
            target.addObject(new Vector2(400, 240), 103, 90, 90);
            target.addObject(new Vector2(600, 200), 201, 35, 35);
            int ID1 = 201; //Enemy
            int ID2 = 0;   //Character
            //Character Position is returned when enemy found
            Vector2 expected = new Vector2(300, 250);
            Vector2 actual;
            actual = target.Visibility(ID1, ID2);
            Assert.AreNotEqual(expected, actual); //true
        }

        [TestMethod()]
        public void VisibilityTest1() 
        {
            ActionHandler target = new ActionHandler();
            //Object Assignment
            target.addObject(new Vector2(300, 250), 0, 30, 30);
            target.addObject(new Vector2(100, 100), 101, 90, 90);
            target.addObject(new Vector2(0, 0), 102, 90, 90);
            target.addObject(new Vector2(400, 240), 103, 90, 90);
            //Enemy Position is changed
            target.addObject(new Vector2(600, 250), 201, 35, 35);
            int ID1 = 201; //Enemy
            int ID2 = 0;   //Character
            //Vector2(-999, -999) is returned when enemy didn't find
            Vector2 expected = new Vector2(-999, -999);
            Vector2 actual;
            actual = target.Visibility(ID1, ID2);
            Assert.AreEqual(expected, actual); //true
        }

        /// <summary>
        ///A test for FindSprite
        ///</summary>
        [TestMethod()]
        [DeploymentItem("WindowsGame1.exe")]
        public void FindSpriteTest()
        {
            ActionHandler_Accessor target = new ActionHandler_Accessor(); // TODO: Initialize to an appropriate value
            int ID = 0; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.FindSprite(ID);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
      

        /// <summary>
        ///A test for addObject
        ///</summary>
        [TestMethod()]
        public void addObjectTest()
        {
            ActionHandler target = new ActionHandler(); 
            Vector2 Pos = new Vector2(300, 200);
            int ID = 208; 
            float Height = 30F; 
            float Width = 30F; 
            target.addObject(Pos, ID, Height, Width);
            Assert.IsTrue(target.getPos(ID) == Pos, "Position fail");
            Assert.IsTrue(target.getWidth(ID) == Width, "Width fail");
            Assert.IsTrue(target.getHeight(ID) == Height, "Height fail ");
        }


        /// <summary>
        ///A test for getWidth
        ///</summary>
        [TestMethod()]
        public void getWidthTest()
        {
            ActionHandler target = new ActionHandler(); 
            int ID = 0; 
            double expected = 45F; 
            double actual;
            actual = target.getWidth(ID);
            Assert.AreEqual(expected, actual);           
        }

        /// <summary>
        ///A test for getPos
        ///</summary>
        [TestMethod()]
        public void getPosTest()
        {
            ActionHandler target = new ActionHandler(); 
            int ID = 5; 
            Vector2 expected = new Vector2(100, 200); 
            Vector2 actual;
            actual = target.getPos(ID);
            Assert.AreEqual(expected, actual);            
        }

        /// <summary>
        ///A test for getHeight
        ///</summary>
        [TestMethod()]
        public void getHeightTest()
        {
            ActionHandler target = new ActionHandler(); 
            int ID = 12; 
            double expected = 30F; 
            double actual;
            actual = target.getHeight(ID);
            Assert.AreEqual(expected, actual);           
        }

        /// <summary>
        ///A test for IgnoreObject
        ///</summary>
        [TestMethod()]
        public void IgnoreObjectTest()
        {
            ActionHandler target = new ActionHandler(); // TODO: Initialize to an appropriate value
            Sprite name = new Sprite(); // TODO: Initialize to an appropriate value
            target.IgnoreObject(name);
        }

        /// <summary>
        ///A test for RecognizeObject
        ///</summary>
        [TestMethod()]
        public void RecognizeObjectTest()
        {
            ActionHandler target = new ActionHandler(); // TODO: Initialize to an appropriate value
            Sprite name = null; // TODO: Initialize to an appropriate value
            target.RecognizeObject(name);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for UpdatePos
        ///</summary>
        [TestMethod()]
        public void UpdatePosTest1() 
        {
            ActionHandler target = new ActionHandler(); 
            Sprite name = new Sprite();
            name.SpriteID = 15;

            name.updatePos(new Vector2(100, 299));
            
            target.UpdatePos(name);
            Assert.IsTrue(name.pos == target.getPos(name.SpriteID));
        }    
    }
}
