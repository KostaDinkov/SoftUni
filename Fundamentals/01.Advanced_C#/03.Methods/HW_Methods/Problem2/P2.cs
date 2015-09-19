//  SoftUni
//  Course:     Advanced C#
//  Lecture:    Methods
//  Problem:    2.Last Digit of Number
//              Write a method that returns the last digit of a
//              given integer as an English word. Test the method with different 
//              input values. Ensure you name the method properly.

using System;

namespace Problem2
{
    class P2
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            Console.WriteLine(GetLastDigitAsWord(input));
        }

        private static string GetLastDigitAsWord(int input)
        {
            int lastDigit = input%10;

            switch (lastDigit)
            {
                case 0:
                    return "zero";
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
                case 6:
                    return "six";
                case 7:
                    return "seven";
                case 8:
                    return "eight";
                case 9:
                    return "nine";
                default:
                    return "Invalid input";
            }
        }
    }
}
