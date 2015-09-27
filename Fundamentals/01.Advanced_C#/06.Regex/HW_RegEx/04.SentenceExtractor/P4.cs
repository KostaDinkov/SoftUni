//  SoftUni
//  Course:     Advanced C#
//  Lecture:    Regular Expressions
//  Problem:    4.Sentence Extractor
//              Write a program that reads a keyword and some text from the console and prints all 
//              sentences from the text, containing that word.A sentence is any sequence of words 
//              ending with '.', '!' or '?'. 

//NOTE Assumptions
//  Sentences must start with a capital letter
//  Keyword match is case insensitive
//  Supports quotations and informal double punctuation

using System;
using System.Text.RegularExpressions;

namespace _04.SentenceExtractor
{
    class P4
    {
        static void Main()
        {
            string keyword = Console.ReadLine();
            string inputText = Console.ReadLine();
            MatchCollection matches = Regex.Matches(inputText,
                @"([A-Z][^.?!]*?)?(?<!\w)(?i)" + keyword + @"(?!\w)[^.?!]*?[.?!]{1,2}""?",RegexOptions.IgnoreCase);
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
        }
    }
}
