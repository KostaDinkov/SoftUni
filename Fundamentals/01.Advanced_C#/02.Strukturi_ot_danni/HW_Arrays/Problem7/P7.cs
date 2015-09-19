//  SoftUni
//  Course:     Advanced C#
//  Lecture:    Arrays, Lists, Stacks, Queues
//  Problem:    7.Sorted Subset Sums
//              Modify the program you wrote for the previous problem to print the results in the 
//              following way: each line should contain the operands (numbers that form the desired sum)
//              in ascending order; the lines containing fewer operands should be printed before those 
//              with more operands; when two lines have the same number of operands, the one containing 
//              the smallest operand should be printed first. If two or more lines contain the same number 
//              of operands and have the same smallest operand, the order of printing is not important

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;


namespace Problem7
{
    class P7
    {
        static void Main()
        {

            Console.WriteLine("This program checks if there is a subset of a set of integers which sums up to a user provided number!\n" +
                              "and prints the results in sorted fashion ...");
            Console.WriteLine("Enter a Sum :");
            int sum = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter integers separated by a space:");
            int[] set = Console.ReadLine().Split(' ').Select(i => Int32.Parse(i)).Distinct().ToArray();

            int subSetCount = (int)Math.Pow(2, set.Length);
            bool matchExists = false;

            SortedSet<List<int>> sortedSet = new SortedSet<List<int>>(new ByLength());

            for (int i = 1; i <= subSetCount; i++)
            {
                var subset = GetSubset(set, i);
                subset.Sort();
                if (subset.Sum() == sum)
                {
                    sortedSet.Add(subset);
                    matchExists = true;
                }
            }
            if (!matchExists)
            {
                Console.WriteLine("No matching subsets.");
            }
            foreach (var list in sortedSet)
            {
                PrintSet(list, sum);
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

    class ByLength : IComparer<List<int>>

    {
        public int Compare(List<int> listA, List<int> listB)
        {

            int listAlen = listA.Count;
            int listBlen = listB.Count;

            // if the list are with equal element counts
            if (listAlen.CompareTo(listBlen) == 0)
            {
                // and if they are equal - compare by the first element in the lists
                if (listA[0] > listB[0])
                {
                    return 1;
                }

                if (listA[0] < listB[0])
                {
                    return -1;
                }
                // if the first element in list A equals the first element in listB - then it doesnt matter which list goes first in the sort
                return 1;
            }
            // Compare the lists by the count of their elements
            return listAlen.CompareTo(listBlen);
        }
    }
}
