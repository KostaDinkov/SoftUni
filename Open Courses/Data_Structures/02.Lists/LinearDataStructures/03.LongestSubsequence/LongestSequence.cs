//---------------------------------------------------
// SoftUni											 
// Course:      Data Structures						 
// Lecture:     Linear Data Structures - Lists		 
// Problem:     03.Remove Odd Occurences							 
// Description: Write a method that finds the longest subsequence of 
//              equal numbers in given List<int> and returns the result as new List<int>. 
//              If several sequences has the same longest length, return the leftmost of them. 
//              Write a program to test whether the method works correctly					 
//													 
// Date:        Tuesday 02.2016 22:06 								 
//---------------------------------------------------


// NOTE: the test method is actually a unit test in a separate project -
// "LongestSubsequenceTests"
// You can add your test cases in a file called data.csv
namespace _03.LongestSubsequence

{
    using System;
    using System.Collections.Generic;

    public class LongestSequence
    {
        private static void Main(string[] args)
        {
            var ints = new List<int> {12, 2, 7, 4, 3, 3, 8};

            var longestSequence = FindLongestSequence(ints);

            Console.WriteLine(string.Join(" ", longestSequence));
        }

        private static int CountSequenceFromIndex(List<int> list, int index)
        {
            if (index == list.Count - 1)
            {
                return 1;
            }
            if (list[index] == list[index + 1])
            {
                return 1 + CountSequenceFromIndex(list, index + 1);
            }
            return 1;
        }

        public static List<int> FindLongestSequence(List<int> integers)
        {
            var longestSequence = new List<int>();
            var currentIndex = 0;

            while (currentIndex < integers.Count)
            {
                var sequenceLength = CountSequenceFromIndex(integers, currentIndex);
                if (sequenceLength > longestSequence.Count)
                {
                    longestSequence = integers.GetRange(currentIndex, sequenceLength);
                }
                currentIndex += sequenceLength;
            }
            return longestSequence;
        }
    }
}