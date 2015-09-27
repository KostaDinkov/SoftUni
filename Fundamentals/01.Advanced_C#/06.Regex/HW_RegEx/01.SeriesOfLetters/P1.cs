//  SoftUni
//  Course:     Advanced C#
//  Lecture:    Regular Expressions
//  Problem:    1. Series of letters
//              Write a program that reads a string from the console and 
//              replaces all series of consecutive identical letters with a single one
using System;
using System.Text.RegularExpressions;

namespace _01.SeriesOfLetters
{
    class P1
    {
        static void Main()
        {
            string input = Console.ReadLine();
            Console.WriteLine(Regex.Replace(input, @"(.)\1+", "$1"));
        }
    }
}
