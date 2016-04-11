# Assignment 5 - Update the Assignment 1 with Wines to use a database instead of a CSV

## Due 4-11-2016

## Author
Nic Smith
## Description

The program allows the following functionality:

1. Loads the information about the Wines (Beverages) from the database. This is achived by making the connection to the database.
2. Allow the user to print the entire list of items.
3. Allow the user to search for an item by the item id, and print out the item if found. Error message if not. This can be done with either Find, or Where.
4. Allow the user to add a new wine item to the list. It should show a nice error message if the user tries to add a wine with a primary id that is already in the DB.
5. Allow the user to update an existing wine item. (You should not allow the user to update the ID since that is the Primary Key of the database record)
6. Allow the user to delete an existing wine item. It should show a nice error if the delete can not complete. (Deleting by ID is good enough. If you would like to offer other searches for deletion you can, but are not required to.)

I have replaced the class called WineItem with an Entity Framework Model based on the data in the database.

Replaced the WineItemCollection class with an Entity Framework collection based on the data in the database. We will do an example of this in class.

Updated the class called User Interface to include any new methods that are required to facilitate the above funcitonality.

CSVProcessor was left. It will not be used though.

I did not do this.  The old WineItem and WineItemCollection can be removed if desired since the Entity Framework versions will be used instead. You may want to hang on to the WineItemCollection and repurpose it as a class to act as a layer between the UI, and the Entity Framework. Essentially, the WineItemCollection could contain methods that make the EF method calls.

To connect to the database you will use the following information.

Sever address / name: barnesbrothers.homeserver.com,443 //Remember that the comma denotes that the port number follows.

Sql Server Authentication (Not Windows Auth):

Username: FirstInial + LastName (All lowercase) (ie. John Smith would be jsmith)

Password: password (If you would like me to change your password to something else for you, I can)

DatabaseName: Beverage + FirstInital + LastName

********************************************************************************************
*NOTE: There is a database for each person. Use the one that is for you. Don't be a troll. If I hear about you trolling on someone elses database, you will get a zero for the assignment!
********************************************************************************************

Solution Requirements:

* 4 classes (Main, Beverage (EF Version), Beverages (EF Version), and UserInterface. The names can differ, and might due to database names and EF setup. In addition, you will have WineItemCollection if you decided to keep it and re-purpose it.)
* EntityFramework Model and Collection
* Read functionality
* Insert functionality
* Update functionality
* Delete functionality
* UI Class to handle I/O

### Notes
Should meet all requirements

## Outside Resources Used
Inclass five was used for reference, as was this readme file
## Known Problems, Issues, And/Or Errors in the Program
No known problems


