using System;

namespace Problem6.IntervalOfNumbers
{
    class IntervalOfNumbers
    {
        static void Main()
        {
            var numA = int.Parse(Console.ReadLine());
            var numB = int.Parse(Console.ReadLine());

            for (int i = Math.Min(numA,numB); i <= Math.Max(numA,numB); i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}