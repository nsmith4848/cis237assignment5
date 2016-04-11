//Author: David Barnes
//CIS 237
//Assignment 1
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class UserInterface
    {
        const int maxMenuChoice = 5;
        //---------------------------------------------------
        //Public Methods
        //---------------------------------------------------

        //Display Welcome Greeting
        public void DisplayWelcomeGreeting()
        {
            Console.WriteLine("Welcome to the wine program");
        }

        //Display Menu And Get Response
        public int DisplayMenuAndGetResponse()
        {
            //declare variable to hold the selection
            string selection;

            //Display menu, and prompt
            this.displayMenu();
            this.displayPrompt();

            //Get the selection they enter
            selection = this.getSelection();

            //While the response is not valid
            while (!this.verifySelectionIsValid(selection))
            {
                //display error message
                this.displayErrorMessage();

                //display the prompt again
                this.displayPrompt();

                //get the selection again
                selection = this.getSelection();
            }
            //Return the selection casted to an integer
            return Int32.Parse(selection);
        }

        //Get the search query from the user
        public string GetSearchQuery()
        {
            Console.WriteLine();
            Console.WriteLine("What would you like to search for?");
            Console.Write("> ");
            return Console.ReadLine();
        }
              
        //Display All Items
        public void DisplayAllItems(string allItemsOutput)
        {
            Console.WriteLine(allItemsOutput);
        }       

        //Display Item Found Error
        public void DisplayItemFoundError()
        {
            Console.WriteLine();
            Console.WriteLine("A Match was not found");
        }

        //Display Add Wine Item Success
        public void DisplayAddItemSuccess()
        {
            Console.WriteLine();
            Console.WriteLine("The Item was successfully added");
        }

        //Display Item Already Exists Error
        public void DisplayItemAlreadyExistsError()
        {
            Console.WriteLine();
            Console.WriteLine("An Item With That Id Already Exists");
        }


        //---------------------------------------------------
        //Private Methods
        //---------------------------------------------------

        //Display the Menu
        private void displayMenu()
        {
            Console.WriteLine();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine();
            Console.WriteLine("1. Print The Entire List Of Items");
            Console.WriteLine("2. Add New Item");
            Console.WriteLine("3. Update Existing Item");
            Console.WriteLine("4. Delete Item");
            Console.WriteLine("5. Exit Program");
        }

        //Display the Prompt
        private void displayPrompt()
        {
            Console.WriteLine();
            Console.Write("Enter Your Choice: ");
        }

        //Display the Error Message
        private void displayErrorMessage()
        {
            Console.WriteLine();
            Console.WriteLine("That is not a valid option. Please make a valid choice");
        }

        //Get the selection from the user
        private string getSelection()
        {
            return Console.ReadLine();
        }

        //Verify that a selection from the main menu is valid
        private bool verifySelectionIsValid(string selection)
        {
            //Declare a returnValue and set it to false
            bool returnValue = false;

            try
            {
                //Parse the selection into a choice variable
                int choice = Int32.Parse(selection);

                //If the choice is between 0 and the maxMenuChoice
                if (choice > 0 && choice <= maxMenuChoice)
                {
                    //set the return value to true
                    returnValue = true;
                }
            }
            //If the selection is not a valid number, this exception will be thrown
            catch (Exception e)
            {
                //set return value to false even though it should already be false
                returnValue = false;
            }

            //Return the reutrnValue
            return returnValue;
        }

        public Beverage GetAddedInput()       //Gets the information for a new Beverage to be added to the database from the user
        {
            Beverage beverageToAdd = new Beverage();
            Console.WriteLine("Please enter an ID for Your Beverage");
            Console.WriteLine("");
            beverageToAdd.id = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Please enter a Name for Your Beverage");
            Console.WriteLine("");
            beverageToAdd.name = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Please enter a package size for your beverage");
            Console.WriteLine();
            beverageToAdd.pack = Console.ReadLine();
            Console.WriteLine();
            beverageToAdd.price = this.GetPrice();                //Common method in add and update input to allow validation without
            return beverageToAdd;                                 //Resetting the entire method

        }
        public string GetID()                                  //Gets the ID of item for update or deletion
        {
            Console.WriteLine();
            Console.WriteLine("Please enter the ID of the item you would like to access");
            Console.WriteLine();
            string idString = Console.ReadLine();
            return idString;
        }

        public Beverage GetUpdateInfo(string idString)                  //Gets the name, pack size, and price of item to be updated
        {
            Beverage templateBeverage = new Beverage();
            templateBeverage.id = idString;
            Console.WriteLine();
            Console.WriteLine("What is the new name?");
            Console.WriteLine();
            templateBeverage.name = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("What is the new package size?");
            Console.WriteLine();
            templateBeverage.pack = Console.ReadLine();
            Console.WriteLine();
            templateBeverage.price = this.GetPrice();
            Console.WriteLine();
            return templateBeverage;
        }

        private decimal GetPrice()                              //Recursive method to keep user from having to restart input due to 
        {                                                       //Misunderstanding of data type to enter
            Console.WriteLine("Please Enter the Price");
            try
            {
                return Convert.ToDecimal(Console.ReadLine());            //Base Case
            }
            catch
            {
                return GetPrice();
            }

        }
        public void ItemDeleted()
        {
            Console.WriteLine();
            Console.WriteLine("Item Deleted");
            Console.WriteLine();
        }
    }
}
