//  SoftUni
//  Course:     Algorithms
//  Lecture:    Recursion
//  Problem:    3. Combinations with repetition
//              Write a recursive program for generating and printing all 
//              combinations with duplicates of k elements from a set of n elements(k <= n). 
//              In combinations, the order of elements doesn’t matter, therefore (1 2) and(2 1) 
//              are the same combination, meaning that once you print/obtain(1 2), (2 1) 
//              is no longer valid.

using System;

class P3

{
    //NOTE: The number of combinations with repetition should be nCk = (n+k-1)!/(k!*(n-1)!)
    //Example: How many ways are there to pick 2(k) digits out of 4(n) digits  -> 4C2 = (4+2-1)!/(2!*(4-1)!) = (5*4*3!)/(2*3!) = 10
    private static int _combinationCount = 0;
    public static void Main()
    {
        Console.Write("N = ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("K = ");
        int k = int.Parse(Console.ReadLine());

        int[] combination = new int[k];
        GenComRep(n, k, combination);
        Console.WriteLine($"Number of combinations with repetition = {_combinationCount}");
    }

    static void GenComRep(int n, int k, int[] combination, int index = 0, int counter = 1)
    {
        if (index == k)
        {
            PrintIntArray(combination);
            _combinationCount++; // remove this line for general usage of the method
            return;
        }
        while (counter <= n)
        {
            combination[index] = counter;
            GenComRep(n, k, combination, index + 1, counter);
            counter++;
        }
    }

    static void PrintIntArray(int[] intArr)
    {
        foreach (var number in intArr)
        {
            Console.Write(number);
        }
        Console.WriteLine();
    }
}

