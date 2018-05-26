using System;
using System.Linq;

class VowelOrDigit
{
    static void Main()
    {
        int[] vowelCodes = {65, 69, 73, 79, 85, 89, 97, 101, 105, 111, 117, 121, 129};
        char ch = char.Parse(Console.ReadLine());

        if (vowelCodes.Contains(ch))
        {
            Console.WriteLine("vowel");
        }
        else if (Char.IsDigit(ch))
        {
            Console.WriteLine("digit");
        }
        else
        {
            Console.WriteLine("other");
        }
    }
}