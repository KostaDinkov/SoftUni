//---------------------------------------------------
// SoftUni											 
// Course:      Data Structures						 
// Lecture:     Linear Data Structures - Lists		 
// Problem:     07.Linked List							 
// Description: Implement the data structure singly linked list LinkedList<T> 
//              that holds a sequence of linked elements. Define two classes:
//              •	ListNode<T> holding the value and a pointer to the next element.
//              •	LinkedList<T> holding the first element + operations Add(T item), 
//                  Remove(index), Count, IEnumerable<T>, FirstIndexOf(T item), LastIndexOf(T item).

//													 
// Date:        Wednesday 02.2016 19:45 								 
//---------------------------------------------------

namespace _07.LinkedList
{
    using System;

    internal class Program
    {
        private static void Main()
        {
            var list = new MyLinkedList<int> {1, 2, 3, 4, 5, 6, 4};

            Console.WriteLine(string.Join(", ", list));

            Console.WriteLine("Removing at index 1");
            list.RemoveAt(1);
            Console.WriteLine(string.Join(", ", list));

            Console.WriteLine("Item count:");
            Console.WriteLine(list.Count);

            Console.WriteLine("First index of 4 is : ");
            Console.WriteLine(list.FirstIndexOf(4));

            Console.WriteLine("Last index of 4 is : ");
            Console.WriteLine(list.LastIndexOf(4));
        }
    }
}