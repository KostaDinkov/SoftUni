//---------------------------------------------------
// SoftUni											 
// Course:      Data Structures						 
// Lecture:     Linear Data Structures - Stacks and Queues		 
// Problem:     01.Reveerse Numbers WithStack							 
// Description: Write a program that reads N integers from the console 
//              and reverses them using a stack. Use the Stack<int> class from .NET Framework. 
//              Just put the input numbers in the stack and pop them. 						 
//													 
// Date:        Friday 02.2016 10:34 								 
//---------------------------------------------------

namespace _01.ReveerseNumbersWithStack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class ReverseMain
    {
        private static void Main(string[] args)
        {
            var input =
                new Stack<int>(Console.ReadLine().Split(' ').Select(i => int.Parse(i)).ToList());
            var integersCount = input.Count;

            for (var i = 0; i < integersCount; i++)
            {
                Console.Write(input.Pop() + " ");
            }
            Console.WriteLine();
        }
    }
}