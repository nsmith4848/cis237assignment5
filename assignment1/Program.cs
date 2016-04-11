//Author: David Barnes
//CIS 237
//Assignment 1
/*
 * The Menu Choices Displayed By The UI
 * 1. Load Wine List From CSV
 * 2. Print The Entire List Of Items
 * 3. Search For An Item
 * 4. Add New Item To The List
 * 5. Exit Program
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class Program
    {
        static void Main(string[] args)
        {            
            //Set up an instance of the beverages networkframe entity
            BeverageNSmithEntities beverageNSmithEntities = new BeverageNSmithEntities();

            //Create an instance of the UserInterface class
            UserInterface userInterface = new UserInterface();            
            
            //Display the Welcome Message to the user
            userInterface.DisplayWelcomeGreeting();

            //Display the Menu and get the response. Store the response in the choice integer
            //This is the 'primer' run of displaying and getting.
            int choice = userInterface.DisplayMenuAndGetResponse();

            while (choice != 5)
            {
                switch (choice)
                {
                    case 1:
                        //Get a string for all items in database, then print with UI command
                        string outputString = "";
                        foreach(Beverage beverage in beverageNSmithEntities.Beverages)   //Gets the info of each beverage
                        {
                            outputString += beverage.id + " " + beverage.name.Trim() +" " + beverage.pack.Trim() + " " + beverage.price.ToString() + Environment.NewLine;
                        }
                        userInterface.DisplayAllItems(outputString);
                        break;

                    case 2:
                        //Adds a beverage to the database
                        Beverage beverageToAdd = userInterface.GetAddedInput();   //Gets all of the info from the user
                        try
                        {                                                              //Validation for duplicate beverage id
                            beverageNSmithEntities.Beverages.Add(beverageToAdd);
                            beverageNSmithEntities.SaveChanges();
                            userInterface.DisplayAddItemSuccess();
                        }
                        catch
                        {
                            userInterface.DisplayItemAlreadyExistsError();
                        }
                        break;

                    case 3:
                        //Updates the information in an existing beverage
                        string updateIDString = userInterface.GetID();  //Gets ID of beverage from the user
                        try
                        {                           //Validation of whether or not ID is in the database
                            Beverage beverageToUpdate = beverageNSmithEntities.Beverages.Find(updateIDString);
                            Beverage updateBeverage = userInterface.GetUpdateInfo(updateIDString);
                            beverageToUpdate.name = updateBeverage.name;
                            beverageToUpdate.pack = updateBeverage.pack;
                            beverageToUpdate.price = updateBeverage.price;
                            beverageNSmithEntities.SaveChanges();
                        }
                        catch
                        {
                            userInterface.DisplayItemFoundError();
                        }
                        break;

                    case 4:
                        //Delete an item
                        string deleteIDString = userInterface.GetID();    //Gets ID of item to delete from the user
                        try
                        {                     //Validation for whether the item to delete exists
                            Beverage beverageToDelete = beverageNSmithEntities.Beverages.Find(deleteIDString);                       
                            beverageNSmithEntities.Beverages.Remove(beverageToDelete);
                            beverageNSmithEntities.SaveChanges();
                            userInterface.ItemDeleted();
                        }
                        catch
                        {
                            userInterface.DisplayItemFoundError();
                        }
                        break;
                }

                //Get the new choice of what to do from the user
                choice = userInterface.DisplayMenuAndGetResponse();
            }

        }
    }
}
