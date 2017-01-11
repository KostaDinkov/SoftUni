//---------------------------------------------------
// SoftUni											 
// Course:      Data Structures						 
// Lecture:     Linear Data Structures - Stacks and Queues	 
// Problem:     07.Linked Queue							 
// Description: Implement a queue by a "doubly-linked list" 
//              as underlying data structure						 
//													 
// Date:        Friday 02.2016 21:42 								 
//---------------------------------------------------
namespace _07.LinkedQueue
{
    using System;

    internal class LinkedQueueMain
    {
        private static void Main(string[] args)
        {
            var integerQueue = new LinkedQueue<int>();

            integerQueue.Enqueue(1);
            integerQueue.Enqueue(2);
            integerQueue.Enqueue(3);
            integerQueue.Enqueue(4);
            integerQueue.Enqueue(5);

            Console.WriteLine("Current Queue:" + string.Join(", ", integerQueue.ToArray()));

            Console.WriteLine($"Dequeue ... {integerQueue.Dequeue()}");
            Console.WriteLine($"Dequeue ... {integerQueue.Dequeue()}");
            Console.WriteLine($"Dequeue ... {integerQueue.Dequeue()}");

            Console.WriteLine("Current Queue:" + string.Join(", ", integerQueue.ToArray()));


        }
    }
}