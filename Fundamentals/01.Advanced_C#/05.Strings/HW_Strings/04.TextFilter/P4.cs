//  SoftUni
//  Course:     Advanced C#
//  Lecture:    Strings
//  Problem:    4.Text Filter
//              Write a program that takes a text and a string of banned words.
//              All words included in the ban list should be replaced with asterisks "*", 
//              equal to the word's length. The entries in the ban list will be separated by a comma and space ", ".
//              The ban list should be entered on the first input line and the text on the second input line

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04.TextFilter
{
    class P4
    {
        
        private const string PatternTemplate = @"\b({0})\b";
        
        private const int TrimCount = 6;//the amount of special regex characters added to the censored word in the pattern above
        const RegexOptions Options = RegexOptions.IgnoreCase;
        static void Main()

        {
            string[] badWords = Regex.Split(Console.ReadLine(),", ");
            string input = Console.ReadLine();
               
            IEnumerable<Regex> badWordsMatchers = badWords.
                Select(x => new Regex(string.Format(PatternTemplate, x),Options));
            string output = badWordsMatchers.
                Aggregate(input,(current, matcher) => matcher.Replace(current, new string('*', matcher.ToString().Length-TrimCount)));
            Console.WriteLine(output);
        }
    }
}
