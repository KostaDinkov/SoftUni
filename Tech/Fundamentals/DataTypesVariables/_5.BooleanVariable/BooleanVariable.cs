using System;

namespace _5.BooleanVariable
{
    class BooleanVariable
    {
        static void Main(string[] args)
        {
            var input = bool.Parse(Console.ReadLine());
            Console.WriteLine(input?"Yes":"No");
        }
    }
}