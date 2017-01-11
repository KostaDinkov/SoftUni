//---------------------------------------------------
// SoftUni											 
// Course:      Data Structures						 
// Lecture:     Linear Data Structures - Stacks and Queues	 
// Problem:     03.Implement an Array-Based Stack							 
// Description: Implement the "stack" data structure Stack<T> that holds its elements in an array.
//              Follow the concepts from the CircularQueue<T> class from the exercises in class. 
//              The stack is simpler than the circular queue, so you will need to follow the same 
//              logic, but more simplified. Some hints:
//              •	The stack capacity is this.elements.Length
//              •	Keep the stack size (number of elements) in this.Count
//              •	Push(element) just saves the element in elements [this.Count]
//                  and increases this.Count
//              •	Push(element) should invoke Grow() in case of this.Count == this.elements.Length
//              •	Pop() decreases this.Count and returns this.elements [this.Count]
//              •	Grow() allocates a new array newElements of size 2 * this.elements.
//                  Length and copies the first this.Count elements from this.elements 
//                  to newElements.Finally, assign this.elements = newElements
//              •	ToArray() just creates and returns a sub-array of this.elements [0…this.Count-1]

//													 
// Date:        Friday 02.2016 17:35 								 
//---------------------------------------------------

namespace _03.ArrayStack
{
    using System;

    internal class ArrayStackMain
    {
        private static readonly Random rnd = new Random();

        private static void Main()
        {
            var integerStack = new ArrayStack<int>();

            for (var i = 0; i < 10; i++)
            {
                integerStack.Push(rnd.Next(5, 30));
            }

            Console.WriteLine("Stack = " + string.Join(", ", integerStack.ToArray()));

            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine("Poping ... " + integerStack.Pop());
                Console.WriteLine("Stack = " + string.Join(", ", integerStack.ToArray()));
            }
            // uncomment the next line and the program should throw an exeption
            // because the stack is empty
            //integerStack.Pop();
        }
    }
}