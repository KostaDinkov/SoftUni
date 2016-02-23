//SoftUni
//Course:       Algorithms
//Lecture:      Combinatorial Algorithms
//Problem:      1. Permutations
//              Write a recursive program for generating and printing all 
//              permutations (without repetition) of the numbers 1, 2, ..., 
//              n for a given integer number n (n > 0). The number of 
//              permutations is found by calculating n!
using System;
using System.Linq;


namespace _01.Permutations
{
    class P1
    {
        private static int countOfPermutations;
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var array = Enumerable.Range(1, n).ToArray();
            Permute(array);

            Console.WriteLine($"Total permutations: {countOfPermutations}");
        }

        private static void Permute(int[] array, int startIndex = 0)
        {
            if (startIndex>= array.Length -1)
            {
                Console.WriteLine(string.Join(", ",array));
                countOfPermutations++;
            }
            else
            {
                for (int i = startIndex; i < array.Length; i++)
                {
                    Swap(ref array[startIndex],ref array[i]);
                    Permute(array, startIndex+1);
                    Swap(ref array[startIndex],ref array[i]);
                }
            }
        }

        private static void Swap(ref int i, ref int j)
        {
            if (i==j)
            {
                return;
            }
            i ^= j;
            j ^= i;
            i ^= j;
        }
        
    }
}
