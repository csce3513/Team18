using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WindowsGame1
{//test class for the main menu buttons.
   
    [TestClass]
    public class ButtonTest
    {// testing the play button which is supposed to lead to another submenu with "Newgame" and "Resume" buttons when clicked.
      
        [TestMethod]

        public void TestPlay()
        {
            Button play = new Button(); //new button created "play"
            play.addButton("Newgame");  //Newgame button is added to play button
            Assert.AreSame("Newgame", play.getButton()); //tesing that Newgame button has been created.
             play.addButton("Resume"); // Resume button is added to play button
            Assert.AreSame("Resume", play.getButton()); // testing that Resume button has been created.


        }

        // testing the exit button which is supposed to exit the game when clicked.
         [TestMethod]
        public void TestExit() {
        Button exit = new Button();
           
            exit.IsClicked("exit");
      //     asserts that if exit is clicked it corresponds to the same "exit" button that is resposible for exiting the game.
            Assert.AreSame("exit", exit.getIsClicked());
        
        }
        
        
        }

    }

