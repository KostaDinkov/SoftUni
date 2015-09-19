//  SoftUni
//  Course:     Advanced C#
//  Lecture:    Arrays, Lists, Stacks, Queues
//  Problem:    5.Longest Increasing Sequence
//              Write a program to find all increasing sequences inside an array of integers.
//              The integers are given on a single line, separated by a space.Print the sequences
//              in the order of their appearance in the input array, each at a single line.Separate the 
//              sequence elements by a space.Find also the longest increasing sequence and print it at the 
//              last line.If several sequences have the same longest length, print the left-most of them.

//NOTE : Using functionality from C# v.6

using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace Problem5
{
    class P5
    {
        static void Main(string[] args)
        {
            
            int[] inputInts = ReadLine().Split(' ').Select(i => Int32.Parse(i)).ToArray();
            List<List<int>> subsets = new List<List<int>>();
            int currentIndex = 0;
            
            List<int> subset = new List<int>();

            while (currentIndex< inputInts.Length)
            {
                subset.Add(inputInts[currentIndex]);
                while (currentIndex + 1 != inputInts.Length && inputInts[currentIndex] < inputInts[currentIndex+1])
                {
                    subset.Add(inputInts[currentIndex+1]);
                    currentIndex++;
                }
                subsets.Add(new List<int>(subset));
                subset.Clear();
                currentIndex++;
            }
            PrintList(subsets);
            var sortedList = subsets.OrderByDescending(l => l.Count).ToList();
            Write("Longest: ");
            sortedList[0].ForEach(e => Write(e + " "));
            WriteLine();
        }

        static void PrintList(List<List<int>> list)
        {
            foreach (List<int> ints in list)
            {
                foreach (int i in ints)
                {
                    Write(i + " ");
                }
                WriteLine();
            }
        }
    }
}

