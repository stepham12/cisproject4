﻿using System;
using System.Collections.Generic;
using System.Text;

//Stephanie Amo
//Project 4
//Due: 11/05/2019

namespace cis237_assignment4
{
    class DroidCollection : IDroidCollection
    {
        // Private variable to hold the collection of droids
        private IDroid[] droidCollection;
        //Private variable to hold the collection of subarray of droids without nulls
        private IDroid[] droidCollectionSubArray;
        // Private variable to hold the length of the Collection
        private int lengthOfCollection;

        //Create instances for generic stacks and queue
        GenericStack<IDroid> protocolStack = new GenericStack<IDroid>();
        GenericStack<IDroid> janitorStack = new GenericStack<IDroid>();
        GenericStack<IDroid> astromechStack = new GenericStack<IDroid>();
        GenericStack<IDroid> utilityStack = new GenericStack<IDroid>();
        GenericQueue<IDroid> queue = new GenericQueue<IDroid>();

        //Create instance for MergeSort
        MergeSort mergeSort = new MergeSort();

        public void Categorize()
        {
            //Determine droid type and push onto appropriate stack
            foreach (IDroid droid in droidCollection)
            {
                if (droid is ProtocolDroid)
                {
                    protocolStack.Push(droid);
                }

                else if (droid is JanitorDroid)
                {
                    janitorStack.Push(droid);
                }

                else if (droid is AstromechDroid)
                {
                    astromechStack.Push(droid);
                }

                else if (droid is UtilityDroid)
                {
                    utilityStack.Push(droid);
                }
            }

            //Pop Droids off Stack and enqueue them in Queue
            while (!protocolStack.IsEmpty)
            {
                IDroid droid = protocolStack.Pop();
                queue.Enqueue(droid);
            }

            while (!janitorStack.IsEmpty)
            {
                IDroid droid = janitorStack.Pop();
                queue.Enqueue(droid);
            }

            while (!astromechStack.IsEmpty)
            {
                IDroid droid = astromechStack.Pop();
                queue.Enqueue(droid);
            }

            while (!utilityStack.IsEmpty)
            {
                IDroid droid = utilityStack.Pop();
                queue.Enqueue(droid);
            }

            // replace the original array of droids with the droids in the queue
            int counter = 0;
            while (!queue.IsEmpty)
            {
                IDroid droid = queue.Dequeue();
                droidCollection[counter] = droid;
                counter++;
            }

            Console.WriteLine();
            Console.Write("Droids sorted by Model. Print list to see sorted list.");
            Console.WriteLine();
            Console.WriteLine();
        }

        public void SortByTotalCost()
        {
            // Private variable to hold the subarray of droids without nulls
            droidCollectionSubArray = new IDroid[lengthOfCollection];
            int counter = 0;
            // For each droid in the droidCollection
            foreach (IDroid droid in droidCollection)
            {
                // If the droid is not null
                if (droid != null)
                {
                    // Calculate the total cost of the droid.
                    droid.CalculateTotalCost();
                    droidCollectionSubArray[counter] = droid;
                    counter++;
                }
            }

            //Perform merge sort to sort by Total Cost
            mergeSort.Sort(droidCollectionSubArray);

            //Put sorted sub array into original droidCollection array
            for (int i = 0; i<droidCollectionSubArray.Length; i++)
            {
                droidCollection[i] = droidCollectionSubArray[i];
            }

            Console.WriteLine();
            Console.Write("Droids sorted by Total Cost. Print list to see sorted list.");
            Console.WriteLine();
            Console.WriteLine();
        }

        // Constructor that takes in the size of the collection.
        // It sets the size of the internal array that will be used.
        // It also sets the length of the collection to zero since nothing is added yet.
        public DroidCollection(int sizeOfCollection)
        {
            // Make new array for the collection
            droidCollection = new IDroid[sizeOfCollection];
            // Set length of collection to 0
            lengthOfCollection = 0;
        }

        // The Add method for a Protocol Droid. The parameters passed in match those needed for a protocol droid
        public bool Add(string Material, string Color, int NumberOfLanguages)
        {
            // If there is room to add the new droid
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                // Add the new droid. Note that the droidCollection is of type IDroid, but the droid being stored is
                // of type Protocol Droid. This is okay because of Polymorphism.
                droidCollection[lengthOfCollection] = new ProtocolDroid(Material, Color, NumberOfLanguages);
                // Increase the length of the collection
                lengthOfCollection++;
                // Return that it was successful
                return true;
            }
            // Else, there is no room for the droid
            else
            {
                //Return false
                return false;
            }
        }

        // The Add method for a Utility droid. Code is the same as the above method except for the type of droid being created.
        // The method can be redeclared as Add since it takes different parameters. This is called method overloading.
        public bool Add(string Material, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm)
        {
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                droidCollection[lengthOfCollection] = new UtilityDroid(Material, Color, HasToolBox, HasComputerConnection, HasArm);
                lengthOfCollection++;
                return true;
            }
            else
            {
                return false;
            }
        }

        // The Add method for a Janitor droid. Code is the same as the above method except for the type of droid being created.
        public bool Add(string Material, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm, bool HasTrashCompactor, bool HasVaccum)
        {
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                droidCollection[lengthOfCollection] = new JanitorDroid(Material, Color, HasToolBox, HasComputerConnection, HasArm, HasTrashCompactor, HasVaccum);
                lengthOfCollection++;
                return true;
            }
            else
            {
                return false;
            }
        }

        // The Add method for a Astromech droid. Code is the same as the above method except for the type of droid being created.
        public bool Add(string Material, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm, bool HasFireExtinguisher, int NumberOfShips)
        {
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                droidCollection[lengthOfCollection] = new AstromechDroid(Material, Color, HasToolBox, HasComputerConnection, HasArm, HasFireExtinguisher, NumberOfShips);
                lengthOfCollection++;
                return true;
            }
            else
            {
                return false;
            }
        }

        // The last method that must be implemented due to implementing the interface.
        // This method iterates through the list of droids and creates a printable string that could
        // be either printed to the screen, or sent to a file.
        public string GetPrintString()
        {
            // Declare the return string
            string returnString = "";

            // For each droid in the droidCollection
            foreach (IDroid droid in droidCollection)
            {
                // If the droid is not null (It might be since the array may not be full)
                if (droid != null)
                {
                    // Calculate the total cost of the droid. Since we are using inheritance and Polymorphism
                    // the program will automatically know which version of CalculateTotalCost it needs to call based
                    // on which particular type it is looking at during the foreach loop.
                    droid.CalculateTotalCost();
                    // Create the string now that the total cost has been calculated
                    returnString += "******************************" + Environment.NewLine;
                    returnString += droid.ToString() + Environment.NewLine + Environment.NewLine;
                    returnString += "Total Cost: " + droid.TotalCost.ToString("C") + Environment.NewLine;
                    returnString += "******************************" + Environment.NewLine;
                    returnString += Environment.NewLine;
                }
            }

            // Return the completed string
            return returnString;
        }
    }
}
