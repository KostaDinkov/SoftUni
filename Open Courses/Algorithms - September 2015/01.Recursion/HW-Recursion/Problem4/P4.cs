//  SoftUni
//  Course:     Algorithms
//  Lecture:    Recursion
//  Problem:    4. Combinations without repetition
//              Modify the previous program to skip duplicates, e.g. (1 1) is not valid.

using System;

class P4

{
    //NOTE: The number of combinations without repetition should be nCk = n!/(k!*(n-k)!)
    //Example: How many ways are there to pick 2 cards(k) out of 4 card deck(n)  -> 4C2 = 4!/(2!*(4-2)!) = (4*3*2!)/(2!*2!) = 4*3/2 = 6
    private static int combinationCount = 0;
    public static void Main()
    {
        Console.Write("N = ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("K = ");
        int k = int.Parse(Console.ReadLine());

        int[] combination = new int[k];
        GenComRep(n, k, combination);
        Console.WriteLine($"Number of combinations = {combinationCount}");
    }

    static void GenComRep(int n, int k, int[] combination, int index = 0, int counter = 1)
    {
        if (index == k)
        {
            PrintIntArray(combination);
            combinationCount++; // remove this line for general usage of the method
            return;
        }
        while (counter <= n)
        {
            combination[index] = counter;
            //GenComRep(n,k,combination,index+1,counter); // combinations with repetition as in Problem3
            GenComRep(n, k, combination, index + 1, counter+1); // combination without repetition - just added +1 to counter
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