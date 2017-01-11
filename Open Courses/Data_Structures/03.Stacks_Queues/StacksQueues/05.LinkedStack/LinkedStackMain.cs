//---------------------------------------------------
// SoftUni											 
// Course:      Data Structures						 
// Lecture:     Linear Data Structures - Stacks and Queues	 
// Problem:     05.Linked Stack							 
// Description: Implement a stack by a "linked list" as underlying data structure.
//              The Push(element) operation should create a new Node<T> and put it as firstNode, 
//              followed by the old value of the firstNode, e.g. this.firstNode = new Node<T>(element, this.firstNode).
//              The Pop() operation should return the firstNode and replace it with firstNode.NextNode.
//													 
// Date:        Friday 02.2016 20:20 								 
//---------------------------------------------------

namespace _05.LinkedStack
{
    using System;
    
    internal class LinkedStackMain
    {
        static Random rnd = new Random();
        private static void Main(string[] args)
        {
            var integerStack = new LinkedStack<int>();

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
        }
    }
}