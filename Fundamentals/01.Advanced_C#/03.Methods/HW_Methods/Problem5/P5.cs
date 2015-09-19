//  SoftUni
//  Course:     Advanced C#
//  Lecture:    Methods
//  Problem:    5.Reverse Number
//              Write a method that reverses the digits of a given floating-point number.

using System;

namespace Problem5
{
    class P5
    {
        static void Main()
        {
            double decimalNumber = Double.Parse(Console.ReadLine());

            double reversed = GetReversedNumber(decimalNumber);
            Console.WriteLine(reversed);
        }

        private static double GetReversedNumber(double decimalNumber)
        {
            string reversedString = ReverseString(decimalNumber.ToString());
            return Double.Parse(reversedString);
        }

        public static string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
}
