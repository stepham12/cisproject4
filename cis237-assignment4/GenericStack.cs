﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Stephanie Amo
//Project 4
//Due: 11/05/2019

namespace cis237_assignment4
{
    class GenericStack <T>
    {
        //Make node class in inner class
        protected class Node
        {
            public T Data { get; set; }
            public Node Next { get; set; }
        }

        // Class variables for maintaining the linked list
        // Head is a pointer to an object of Node
        protected Node _head;
        protected int _size;

        public bool IsEmpty
        {
            get
            {
                //To check whether or not is is empty we can check to see if the 
                // _head pointer is null. 
                //If so, there are no nodes in the list, so it must be empty.
                return _head == null;  //Could check tail too if desired
            }
        }

        public int Size
        {
            get
            {
                return _size;
            }
        }

        //Add to front to push onto stack
        public void Push(T Data)
        {
            //Make a new variable to also point to the head of the list
            Node oldHead = _head;
            //Make a new node and assign it to the head variable
            _head = new Node();
            //Set the date on the new Node
            _head.Data = Data;
            //Make the next property of the new node point to the old head
            _head.Next = oldHead;
            //Increment the size of the list
            _size++;
        }

        //Remove from front to pop from stack
        public T Pop()
        {
            //If it is empty trhow an error
            if (IsEmpty)
            {
                throw new Exception("List is empty");
            }

            //Let's get the data to return
            T returnData = _head.Data;
            //Move the head pointer to the next ni the list.
            _head = _head.Next;

            //Decrease the size
            _size--;

            return returnData;
        }
    }
}
