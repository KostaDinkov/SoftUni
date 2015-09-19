//  SoftUni
//  Course:     Advanced C#
//  Lecture:    Arrays, Lists, Stacks, Queues
//  Problem:    6.Subset Sums
//              Write a program that reads from the console a number N and an array 
//              of integers given on a single line.Your task is to find all subsets 
//              within the array which have a sum equal to N and print them on the 
//              console (the order of printing is not important). Find only the unique 
//              subsets by filtering out repeating numbers first. In case there aren't 
//              any subsets with the desired sum, print "No matching subsets." 

using System;
using System.Collections.Generic;
using System.Linq;


namespace Problem6
{
    class P6
    {
        static void Main()
        {

            Console.WriteLine("This program checks if there is a subset of a set of integers which sums up to a user provided number!\n");
            Console.WriteLine("Enter a Sum :");
            int sum = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter integers separated by a space:");
            int[] set = Console.ReadLine().Split(' ').Select(i => Int32.Parse(i)).Distinct().ToArray();
            int subSetCount = (int)Math.Pow(2, set.Length);
            bool matchExists = false;

            for (int i = 1; i <= subSetCount; i++)
            {
                var subset = GetSubset(set, i);
                if (subset.Sum() == sum)
                {
                    PrintSet(subset, sum);
                    matchExists = true;
                }
            }
            if (!matchExists)
            {
                Console.WriteLine("No matching subsets.");
            }

        }

        private static List<int> GetSubset(int[] set, int binary)
        {
            List<int> subset = new List<int>();
            char[] mask = GetBinaryMask(set.Length, binary);
            for (int j = 0; j < set.Length; j++)
            {
                if (mask[j] != '0')
                {
                    subset.Add(set[j]);
                }
            }
            return subset;
        }

        static char[] GetBinaryMask(int maskSize, int number)
        {
            var array = Convert.ToString(number, 2).PadLeft(maskSize, '0').ToArray();
            return array;
        }

        static void PrintSet(List<int> list, int sum)
        {
            Console.WriteLine(String.Join(" + ", list) + " = " + sum);
        }
    }
}
