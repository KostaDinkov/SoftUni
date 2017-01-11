//---------------------------------------------------
// SoftUni
// Course:      Data Structures
// Lecture:     Linear Data Structures - Lists
// Problem:     01.Sum And Average
// Description: Write a program that reads from the console a sequence of 
//              integer numbers (on a single line, separated by a space). Calculate and 
//              print the sum and average of the elements of the sequence. 
//              Keep the sequence in List<int>.
//
// Date:        Tuesday 02.2016 21:10 
//---------------------------------------------------

namespace _01.SumAndAverage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static void Main(string[] args)
        {
            // Read the input and generate the list of ints
            var numbers =
                Console.ReadLine().
                    Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).
                    Select(e => int.Parse(e)).
                    ToList();

            long sum = 0;
            double average = 0;

            if (numbers.Count > 0)
            {
                sum = GetSum(numbers);
                average = sum/(double) numbers.Count;
            }

            Console.WriteLine($"Sum={sum}; Average={average}");
        }

        private static long GetSum(List<int> integers)
        {
            long sum = 0;
            foreach (var integer in integers)
            {
                sum += integer;
            }
            return sum;
        }
    }
}