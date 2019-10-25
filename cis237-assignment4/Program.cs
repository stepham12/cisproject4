using System;

namespace cis237_assignment4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new droid collection and set the size of it to 100.
            IDroidCollection droidCollection = new DroidCollection(100);

            // Create a user interface and pass the droidCollection into it as a dependency
            UserInterface userInterface = new UserInterface(droidCollection);

            //Hard-Coded Droids to test program
            droidCollection.Add("Carbonite", "Red", false, false, true, false, 10);
            droidCollection.Add("Carbonite","White", 5);
            droidCollection.Add("Carbonite", "Green", false, false, true);
            droidCollection.Add("Quadranium", "Blue", true, true, false, true, false);
            droidCollection.Add("Vanadium", "Red", 2);
            droidCollection.Add("Quadranium", "Blue", true, true, false);
            droidCollection.Add("Vanadium", "Green", false, false, true, false, true);
            droidCollection.Add("Quadranium", "White", true, true, false, true, 5);

            // Display the main greeting for the program
            userInterface.DisplayGreeting();

            // Display the main menu for the program
            userInterface.DisplayMainMenu();

            // Get the choice that the user makes
            int choice = userInterface.GetMenuChoice();

            // While the choice is not equal to 3, continue to do work with the program
            while (choice != 3)
            {
                // Test which choice was made
                switch (choice)
                {
                    // Choose to create a droid
                    case 1:
                        userInterface.CreateDroid();
                        break;

                    // Choose to Print the droid
                    case 2:
                        userInterface.PrintDroidList();
                        break;
                }
                // Re-display the menu, and re-prompt for the choice
                userInterface.DisplayMainMenu();
                choice = userInterface.GetMenuChoice();
            }
        }
    }
}
