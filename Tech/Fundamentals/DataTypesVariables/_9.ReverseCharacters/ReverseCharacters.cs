using System;
using System.Collections.Generic;


namespace _9.ReverseCharacters
{
    class ReverseCharacters
    {
        static void Main()
        {
            var chars = new List<string>();
            
            chars.Add(Console.ReadLine());
            chars.Add(Console.ReadLine());
            chars.Add(Console.ReadLine());
            chars.Reverse();

            Console.WriteLine(string.Join("",chars));
        }
    }
}