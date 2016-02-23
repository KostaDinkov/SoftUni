//  SoftUni
//  Course:     Algorithms
//  Lecture:    Recursion
//  Problem:    2. Nested Loops to Recursion
//              Write a program that simulates the execution of n nested loops from 1 
//              to n which prints the values of all its iteration variables at any given 
//              time on a single line.Use recursion.
using System;


namespace Problem2
{
    class P2

    {
        private static int _variationCount=0;
        static void Main()
        
        {
            Console.WriteLine("Enter number of nested loops:");
            int loopCount = int.Parse(Console.ReadLine());
            int[] variations = new int[loopCount];
            GenVarRep(variations,variations.Length-1);
            Console.WriteLine($"Number of variations with repetition = {_variationCount}");
        }

        static void GenVarRep( int [] variation, int counter)
        {
            if (counter<0)
            {
                PrintIntArray(variation);
                _variationCount++;
                return;
            }
            for (int i = 1; i <= variation.Length; i++)
            {
                variation[counter] = i;
                
                GenVarRep(variation, counter-1);
                
            }
            
            
        }
        static void PrintIntArray(int[] variation)
        {
            foreach (int i in variation)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }
    }
}
