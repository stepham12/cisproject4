using System;

//Stephanie Amo
//Project 4
//Due: 11/05/2019

namespace cis237_assignment4
{
    interface IDroid : IComparable
    {
        // Method to calculate the total cost of a droid
        void CalculateTotalCost();

        // Property to get the total cost of a droid
        decimal TotalCost { get; set; }

        //Method to compare Droid object
        new int CompareTo(object obj);
    }
}
