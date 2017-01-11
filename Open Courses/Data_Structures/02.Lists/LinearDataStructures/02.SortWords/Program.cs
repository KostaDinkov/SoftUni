//---------------------------------------------------
// SoftUni
// Course:      Data Structures
// Lecture:     Linear Data Structures - Lists
// Problem:     02.Sort Words
// Description: Write a program that reads from the console 
//              a sequence of words (strings on a single line, separated by a space). 
//              Sort them alphabetically. Keep the sequence in List<string>.
//
// Date:        Tuesday 02.2016 21:29 
//---------------------------------------------------

namespace _02.SortWords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var input = Console.ReadLine().
                Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToList();

            var sorted = MergeSort(input);

            // or using the List.Sort method
            // input.Sort((str1, str2) => str1.CompareTo(str2));

            Console.WriteLine(string.Join(" ", sorted));
        }

        public static List<string> MergeSort(List<string> list)
        {
            if (list.Count <= 1)
            {
                return list;
            }

            var middleIndex = list.Count/2;
            var left = list.GetRange(0, middleIndex);
            var right = list.GetRange(middleIndex, list.Count - middleIndex);

            left = MergeSort(left);
            right = MergeSort(right);

            return Merge(left, right);
        }

        public static List<string> Merge(List<string> left, List<string> right)
        {
            var resultList = new List<string>();

            while ((left.Count > 0) || (right.Count > 0))
            {
                if ((left.Count > 0) && (right.Count > 0))
                {
                    if (left[0].CompareTo(right[0]) < 0)
                    {
                        resultList.Add(left[0]);
                        left.RemoveAt(0);
                    }

                    else
                    {
                        resultList.Add(right[0]);
                        right.RemoveAt(0);
                    }
                }

                else if (left.Count > 0)
                {
                    resultList.Add(left[0]);
                    left.RemoveAt(0);
                }

                else if (right.Count > 0)
                {
                    resultList.Add(right[0]);
                    right.RemoveAt(0);
                }
            }

            return resultList;
        }
    }
}