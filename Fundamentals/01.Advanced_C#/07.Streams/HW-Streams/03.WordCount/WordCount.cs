//SoftUni
//Course:   Advanced C#
//Lecture:  Streams and Files
//Problem:  3. Word Count   
//          Write a program that reads a list of words from the file words.txt 
//          and finds how many times each of the words is contained in another 
//          file text.txt.Matching should be case-insensitive.
//          Write the results in file results.txt.Sort the words by frequency 
//          in descending order. Use StreamReader in combination with StreamWriter.


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03.WordCount
{
    class WordCount
    {
        static void Main()
        {
            string wordsFile = "../../words.txt";
            string textFile = "../../text.txt";
            string resultFile = "../../result.txt";
            Dictionary<string, int> results = new Dictionary<string, int>();

            string[] keywords = GetWordsFromFile(wordsFile);
            string[] text = GetWordsFromFile(textFile);
            
            //count the occurrences of each keyword in the text
            foreach (var keyword in keywords)
            {
                CountKeyWordInArray(text, keyword,results);
            }
            //sort the dictionary
            var sortedResult = from entry in results orderby entry.Value descending select entry;
            using (StreamWriter writer = new StreamWriter(resultFile,true))
            {
                foreach (var result in sortedResult)
                {
                    writer.WriteLine(result.Key + " - " + result.Value);
                }
            }
        }

        static string[] GetWordsFromFile(string file)
        {
            string text;
            using (StreamReader reader = new StreamReader(file))
            {
                text = reader.ReadToEnd();

            }
            return text.Split(new[] { '.', '?', '!', ' ', ';', ':', ',','\n','\r','-' },
                StringSplitOptions.RemoveEmptyEntries);
        }

        private static void CountKeyWordInArray(string [] text, string keyword, Dictionary<string, int> result)
        {
            var matchQuery = from word in text
                             where word.ToLowerInvariant() == keyword.ToLowerInvariant()
                             select word;

            result.Add(keyword,matchQuery.Count());
        }
    }
}
