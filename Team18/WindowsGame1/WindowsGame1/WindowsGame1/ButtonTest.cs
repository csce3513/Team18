using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{ // class to create buttons on the main menu
    class Button
    {
        private string button1, button2;
        //function to create a button and name it
        public void addButton(String text) 
    {
        
         button1 = text;
        }
        //function to get the name of the button which is later used in the testplay to compare.
        public string getButton() {

            return button1;
            
        }
        // function to associate the buttin clicked with its name for testing purposes and also used to implement the event handling later

        public void IsClicked(string BtonName) {

            button2 = BtonName;
        
        
        }

        // function to return the name of the button that is clicked
        public string getIsClicked() {

            return button2;
        }
    }
}
