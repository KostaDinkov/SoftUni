using System;
using System.Linq;

namespace Problem10.TriangleOfNumbers
{
    class TriangleOfNumbers
    {
        static void Main()
        {
            int input = int.Parse(Console.ReadLine());
            for (int i = 1; i <= input; i++)
            {
                Console.WriteLine(string.Concat(Enumerable.Repeat(i+" ",i)));
            }
        }
    }
}