using System;
using System.Linq;

namespace _06.SumReversedNumbers
{
    class SumReversedNumbers
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .Select(ReverseInt)
                    .Sum());
        }

        private static int ReverseInt(int num)
        {
            int result = 0;
            while (num > 0)
            {
                result = result * 10 + num % 10;
                num /= 10;
            }

            return result;
        }
    }
}