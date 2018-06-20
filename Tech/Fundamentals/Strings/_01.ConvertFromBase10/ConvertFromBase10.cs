namespace _01.ConvertFromBase10
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    class ConvertFromBase10
    {
        static void Main(string[] args)
        {
            var stack = new Stack<int>();

            var inputTokens = Console.ReadLine().Split(" ");
            BigInteger number = BigInteger.Parse(inputTokens[1]);
            int baseSystem = int.Parse(inputTokens[0]);
            while (number > 0)
            {
                var rem = number % baseSystem;
                stack.Push((int)rem);
                number = number / baseSystem;

            }

            foreach (var digit in stack)
            {
                Console.Write(digit);
            }
        }
    }
}