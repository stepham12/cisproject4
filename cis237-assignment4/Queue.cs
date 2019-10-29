using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment4
{
    class Queue<T>
    {
        //Make node class in inner class
        protected class Node
        {
            public T Data { get; set; }
            public Node Next { get; set; }
        }

        // Class variables for maintaining the linked list
        // Head and Tail are pointers to an object of Node
        protected Node _head;
        protected Node _tail;
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

        //Add to back to enqueue
        public void Enqueue(T Data)
        {
            // Make a pointer to the tail called old tail
            Node oldTail = _tail;
            //Make a new variable and assign it to the tail pointer
            _tail = new Node();
            //Assign the date and set the next point
            _tail.Data = Data;
            _tail.Next = null; //Not needed technically.

            //Check to see if the list is empty
            //If so, make the head point to the same location as the tail. 
            if (IsEmpty) //Can check IsEmpty because size not incremented yet.
            {
                _head = _tail;
            }
            //We need to take the oldTail and make its Next property point
            //to the tail that we just created.
            else
            {
                oldTail.Next = _tail;
            }
            _size++;
        }

        //Remove from front to dequeue
        public T Dequeue()
        {
            //If it is empty throw an error
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
            // Check to see if we just removed the last node from the list
            if (IsEmpty)
            {
                _tail = null;
            }

            return returnData;
        }

    }
}
