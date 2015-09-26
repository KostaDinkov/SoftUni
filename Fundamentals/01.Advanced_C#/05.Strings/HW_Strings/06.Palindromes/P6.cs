//  SoftUni
//  Course:     Advanced C#
//  Lecture:    Strings
//  Problem:    6. Palindromes
//              Write a program that extracts from a given text all palindromes, 
//              e.g.ABBA, lamal, exe and prints them on the console on a single line, 
//              separated by comma and space.Use spaces, commas, dots, question marks and 
//              exclamation marks as word delimiters.Print only unique palindromes, sorted 
//              lexicographically
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace _06.Palindromes
{
    class P6
    {
        static void Main()
        {
            string input = Console.ReadLine();
            SortedSet<string> palindromes = new SortedSet<string>();
            string[] words = GetWords(input);
            foreach (var word in words)
            {
                if (word.SequenceEqual(word.Reverse()))
                {
                    palindromes.Add(word);
                }
            }
            Console.WriteLine(String.Join(", ",palindromes));


        }
        static string[] GetWords(string input)
        {
            MatchCollection matches = Regex.Matches(input, @"\b[\w]*\b");

            var words = from m in matches.Cast<Match>()
                        where !string.IsNullOrEmpty(m.Value)
                        select m.Value;

            return words.ToArray();
        }
        
    }
}
