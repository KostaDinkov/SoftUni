//  SoftUni
//  Course:     Advanced C#
//  Lecture:    Strings
//  Problem:    5. Unicode Characters
//              Write a program that converts a string to a sequence of 
//              C# Unicode character literals. 


using System;

namespace _05.UnicodeCharacters
{
    class P5
    {
        static void Main()
        {
            string input = Console.ReadLine();
            foreach (var character in input)
            {
                Console.Write(($"\\u{(int)character:X4}").ToLower());
            }
            Console.WriteLine();

        }
    }
}
