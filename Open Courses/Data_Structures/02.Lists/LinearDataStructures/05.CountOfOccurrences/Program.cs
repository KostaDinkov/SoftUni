//---------------------------------------------------
// SoftUni											 
// Course:      Data Structures						 
// Lecture:     Linear Data Structures - Lists		 
// Problem:     05.Count Of Occurrences							 
// Description: Write a program that finds in given array of integers how 
//              many times each of them occurs. The input sequence holds numbers in range [0…1000]. 
//              The output should hold all numbers that occur at 
//              least once along with their number of occurrences. 						 
//													 
// Date:        Wednesday 02.2016 16:27 								 
//---------------------------------------------------

namespace _05.CountOfOccurrences
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var testCases = new List<int[]>
            {
                new[] {3, 4, 4, 2, 3, 3, 4, 3, 2},
                new[] {1000},
                new[] {0, 0, 0},
                new[] {7, 6, 5, 5, 6}
            };

            foreach (var testCase in testCases)
            {
                Console.WriteLine("Test Case: " + string.Join(",", testCase));
                var occurences = CountOccurences(testCase);
                PrintDictionary(occurences);
                Console.WriteLine(new string('_', 30) + "\n");
            }
        }

        private static void PrintDictionary<T>(IDictionary<T, T> dict)
        {
            foreach (var pair in dict)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value} times");
            }
        }

        private static SortedDictionary<int, int> CountOccurences(int[] integers)
        {
            var occurences = new SortedDictionary<int, int>();

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
            return occurences;
        }
    }
}