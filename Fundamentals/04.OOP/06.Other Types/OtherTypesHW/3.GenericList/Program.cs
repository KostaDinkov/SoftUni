//---------------------------------------------------
// SoftUni
// Course:      OOP
// Lecture:     Other Types
// Problem:     3.Generic List
// Description: Write a generic class GenericList<T> that keeps a list 
//              of elements of some parametric type T. 
//              •	Keep the elements of the list in an array with a certain capacity, 
//                  which is given as an optional parameter in the class constructor. 
//              Declare the default capacity of 16 as a constant.
//              •	Implement methods for:
//              o adding an element
//              o accessing element by index
//              o   removing element by index
//              o inserting element at given position
//              o clearing the list
//              o finding element index by given value
//              o   checking if the list contains a value
//              o   printing the entire list (override ToString()). 
//              •	Check all input parameters to avoid accessing elements at invalid positions.
//              •	Implement auto-grow functionality: when the internal array is full, 
//                  create a new array of double size and move all elements to it.
//              •	Create generic methods Min<T>() and Max<T>() for finding the minimal 
//                  and maximal element in the GenericList<T>.You may need to add generic 
//                      constraints for the type T to implement IComparable<T>.
//              
// IDE:         Visual Studio 2015, C# v.6
// Date:        Wednesday 12.2015 23:05 
//---------------------------------------------------

namespace _3.GenericList
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var numbers = new GenericList<int>();

            // populate the list with  numbers from 0 to 19
            Console.WriteLine("Adding numbers to the list...");
            for (var i = 0; i < 20; i++)
            {
                numbers.Add(i);
            }
            Console.WriteLine(numbers);

            // remove element at position 10
            Console.WriteLine("Removing number at position 10...");
            numbers.RemoveAt(10);
            Console.WriteLine(numbers);

            // insert a number at position 10
            Console.WriteLine("Inserting number 333 at position 10");
            numbers.Insert(10, 333);
            Console.WriteLine(numbers);

            // check if the list contains 333
            Console.WriteLine("The list contains 333: {0} ", numbers.Contains(333) ? "True" : "False");

            //accessing element by index
            Console.WriteLine("Accessing index 14");
            Console.WriteLine(numbers[14]);

            //getting the index of number 5
            Console.WriteLine("Getting the index of number 5");
            Console.WriteLine(numbers.IndexOf(5));

            //change the number at index 10 
            Console.WriteLine("Changing the number at index 10 to 555");
            numbers[10] = 555;
            Console.WriteLine(numbers);

            //clearing the numbers
            Console.WriteLine("Clearing the numbers...");
            numbers.Clear();
            Console.WriteLine(numbers);

            //Problem 4. Version
            Console.WriteLine("Version information for {0}", numbers.GetType());
            var type = typeof (GenericList<>);
            VersionAttribute versionAttr;
            foreach (Attribute attr in type.GetCustomAttributes(true))
            {
                versionAttr = attr as VersionAttribute;
                if (versionAttr != null)
                {
                    Console.WriteLine("Version of {0} : {1}", type, versionAttr.Version);
                }
            }
        }
    }
}