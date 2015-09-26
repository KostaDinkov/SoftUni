//  SoftUni
//  Course:     Advanced C#
//  Lecture:    Strings
//  Problem:    3. Count Substring Occurrences
//              Write a program to find how many times a given string appears in a given text as 
//              substring.The text is given at the first input line.The search string is given 
//              at the second input line. The output is an integer number.Please ignore the 
//              character casing.Overlapping between occurrences is allowed.

using System;
using System.Text.RegularExpressions;

namespace _03.CountSubstringOccurances
{
    class P3
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string sub = Console.ReadLine();
            Console.WriteLine(Regex.Matches(input, $@"(?={sub})", RegexOptions.IgnoreCase).Count);
        }
    }
}
