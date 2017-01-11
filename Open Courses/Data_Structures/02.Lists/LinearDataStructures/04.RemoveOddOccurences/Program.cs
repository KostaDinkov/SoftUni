//---------------------------------------------------
// SoftUni											 
// Course:      Data Structures						 
// Lecture:     Linear Data Structures - Lists		 
// Problem:     04.Remove Odd Occurences							 
// Description: Write a program that removes from given sequence all numbers that occur odd number of times.						 
//													 
// Date:        Wednesday 02.2016 14:20 								 
//---------------------------------------------------

// Note: Assuming integers as input

namespace _04.RemoveOddOccurences
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var testCases = new List<List<int>>
            {
                new List<int> {1, 2, 3, 4, 1},
                new List<int> {1, 2, 3, 4, 5, 3, 6, 7, 6, 7, 6},
                new List<int> {1, 2, 1, 2, 1, 2},
                new List<int> {3, 7, 3, 3, 4, 3, 4, 3, 7},
                new List<int> {1, 1}
            };

            foreach (var testCase in testCases)
            {
                RemoveOddOccurences(testCase);
                Console.WriteLine(string.Join(" ", testCase));
            }
        }

        private static void RemoveOddOccurences(List<int> integers)
        {
            //Going with the naive algorithm...

            var occurences = new Dictionary<int, int>();
            foreach (var integer in integers)
            {
                if (occurences.ContainsKey(integer))
                {
                    occurences[integer] += 1;
                }
                else
                {
                    occurences.Add(integer, 1);
                }
            }
            foreach (var pair in occurences)
            {
                if (pair.Value%2 == 1)
                {
                    integers.RemoveAll(e => e == pair.Key);
                }
            }
        }
    }
}