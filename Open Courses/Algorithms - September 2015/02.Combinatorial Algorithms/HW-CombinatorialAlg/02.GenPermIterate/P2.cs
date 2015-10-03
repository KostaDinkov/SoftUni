//SoftUni
//Course:       Algorithms
//Lecture:      Combinatorial Algorithms
//Problem:      2. Generate Permutations Iteratively
//              Write a recursive program for generating and printing all 
//              permutations (without repetition) of the numbers 1, 2, ..., 
//              n for a given integer number n (n > 0). The number of 
//              permutations is found by calculating n!
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.GenPermIterate
{
    class P2
    {
        static void Main()
        {
            int n = 3;
            int k = 3;
            int[] arr = new int[k];

            while (true)
            {
                Print(arr);
                int digitIndex = k - 1;
                while (digitIndex >= 0 && arr[digitIndex] == n - 1)
                {
                    digitIndex--;
                }
                if (digitIndex < 0)
                {
                    break;
                }
                arr[digitIndex]++;
                for (int i = digitIndex + 1; i < k; i++)
                {
                    arr[i] = 0;
                }
            }

        }
        static void Print(int[] arr)
        {
            Console.WriteLine("(" + string.Join(", ", arr) + ")");
        }
    }
}
