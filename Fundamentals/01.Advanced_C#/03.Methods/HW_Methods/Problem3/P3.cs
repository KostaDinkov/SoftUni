//  SoftUni
//  Course:     Advanced C#
//  Lecture:    Methods
//  Problem:    3.Larger Than Neighbors
//              Write a method that checks if the element at 
//              given position in a given array of integers is 
//              larger than its two neighbors (when such exist).
using System;

namespace Problem3
{
     class P3
    {
        static void Main()
        {
            
            int[] numbers = {1, 3, 4, 5, 1, 0, 5}; //change the numbers to test for other cases

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(IsLargerThanNeighbors(numbers, i));
            }
        }

        public static bool IsLargerThanNeighbors(int[] numbers, int i)
        {
            if (numbers.Length==1)
            {
                return false;
            }
            if (i ==0)
            {
                return numbers[i] > numbers[i + 1];
            }
            if (i == numbers.Length - 1)
            {
                return numbers[i] > numbers[i - 1];
            }

            return (numbers[i] > numbers[i + 1] && numbers[i] > numbers[i - 1]);


        }
    }
}
