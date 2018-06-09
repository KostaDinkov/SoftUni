using System;

namespace p03.EnglishNameOfLastDigit
{
    class EnglishNameOfLastDigit
    {
        static void Main()
        {
            var number = Console.ReadLine();
            var digit = (int)Char.GetNumericValue(number[number.Length - 1]);
            Console.WriteLine(GetDigitName(digit));
        }

        static string GetDigitName(int digit)
        {
            var digitNames = new [] { "zero","one","two","three","four","five","six","seven","eight","nine"};
            return digitNames[digit];
        }
    }
}