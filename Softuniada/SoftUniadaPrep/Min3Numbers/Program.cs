namespace Min3Numbers
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var numCount = int.Parse(Console.ReadLine());
            var numbers = new int[numCount];

            for (var i = 0; i < numCount; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }
            Array.Sort(numbers);
            if (numbers.Length <= 3)
            {
                Console.WriteLine(string.Join("\n", numbers));
            }
            else
            {
                for (var i = 0; i < 3; i++)
                {
                    Console.WriteLine(numbers[i]);
                }
            }
        }
    }
}