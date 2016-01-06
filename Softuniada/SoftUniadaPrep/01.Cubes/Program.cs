namespace _01.Cubes
{
    using System;
    using System.Linq;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var numbers = 
                Console.ReadLine()
                .Split()
                .Select(n => int.Parse(n))
                .ToArray();

        }
    }
}