//  SoftUni
//  Course:     Advanced C#
//  Lecture:    Methods
//  Problem:    4.First Larger Than Neighbors
//              Write a method that returns the index of the first element 
//              in array that is larger than its neighbors, or -1 if there's 
//              no such element. Use the method from the previous exercise in order to re.

using System;


namespace Problem4
{
    class P4
    {
        static void Main()
        {
            int[] sequenceOne = {1, 3, 4, 5, 1, 0, 5};
            int[] sequenceTwo = {1, 2, 3, 4, 5, 6, 6};
            int[] sequenceThree = {1, 1, 1};

            Console.WriteLine(GetIndexOfFirstElementLargerThanNeighbors(sequenceOne));
            Console.WriteLine(GetIndexOfFirstElementLargerThanNeighbors(sequenceTwo));
            Console.WriteLine(GetIndexOfFirstElementLargerThanNeighbors(sequenceThree));

        }

        private static int GetIndexOfFirstElementLargerThanNeighbors(int[] sequence)
        {
            for (int i = 0; i < sequence.Length; i++)
            {
                if (IsLargerThanNeighbors(sequence,i))
                {
                    return i;
                }
            }
            return -1;
        }

        public static bool IsLargerThanNeighbors(int[] numbers, int i)
        {
            if (numbers.Length == 1)
            {
                return false;
            }
            if (i == 0)
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
