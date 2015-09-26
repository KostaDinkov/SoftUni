//  SoftUni
//  Course:     Advanced C#
//  Lecture:    Strings
//  Problem:    1.Reverse String
//              Write a program that reads a string from the console, 
//              reverses it and prints the result back at the console.

using System;

namespace _01.ReverseString
{
    class P1
    {
        static void Main()
        {
            string input = Console.ReadLine();
            
            Console.WriteLine(Reverse(input));

        }

        private static string Reverse(string input)
        {
            char[] chars = input.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }
    }
}

