//---------------------------------------------------
// SoftUni											 
// Course:      Data Structures						 
// Lecture:     Linear Data Structures - Lists		 
// Problem:     06.Reversed List							 
// Description: Implement a data structure ReversedList<T> that holds a sequence of 
//              elements of generic type T. It should hold a sequence of items in 
//              reversed order. The structure should have some capacity that 
//              grows twice when it is filled. The reversed list should 
//              support the following operations:
//              •	Add(T item) - adds an element to the sequence(grow twice the 
//                  underlying array to extend its capacity in case the capacity is full)
//              •	Count - returns the number of elements in the structure
//              •	Capacity - returns the capacity of the underlying array holding the elements of the structure
//              •	this[index] - the indexer should access the elements by index 
//                  (in range 0 … Count-1) in the reverse order of adding
//              •	Remove(index) - removes an element by index (in range 0 … Count-1) in the reverse order of adding
//              •	IEnumerable<T> - implement an enumerator to allow iterating over 
//                  the elements in a foreach loop in a reversed order of their addition

//													 
// Date:        Wednesday 02.2016 18:15 								 
//---------------------------------------------------


namespace _06.ReversedList
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        private static void Main()
        {
            var reversedList = new ReversedList<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            // Print to check order
            Console.WriteLine("Checking order:");
            Print(reversedList);

            // It should remove the 8
            Console.WriteLine("Removing item at index 2 (8)");
            reversedList.RemoveAt(2);
            Print(reversedList);

            //Printing the items count
            Console.WriteLine("Item count:");
            Console.WriteLine(reversedList.Count);

            //Adding should put element "in front"
            Console.WriteLine("Adding 8");
            reversedList.Add(8);
            Print(reversedList);

            //Get element at index
            Console.WriteLine("Get element at index 2");
            Console.WriteLine(reversedList[2]);

            //Get Capacity
            Console.WriteLine("Capacity:");
            Console.WriteLine(reversedList.Capacity);
        }

        private static void Print<T>(IEnumerable<T> collection)
        {
            Console.WriteLine(string.Join(",", collection));
        }
    }
}