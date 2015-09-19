//  SoftUni
//  Course:     Advanced C#
//  Lecture:    Multidimensional Arrays, Sets, Dictionaries
//  Problem:    6.Count Symbols
//              Write a program that reads some text from the console and counts 
//              the occurrences of each character in it.Print the results in 
//              alphabetical(lexicographical) order.
using System;
using System.Collections.Generic;


namespace Problem6
{
    class P6
    {
        static void Main()
        {
            string input = Console.ReadLine();
            SortedDictionary<char,int> dict = new SortedDictionary<char, int>();

            foreach (var character in input)
            {
                int value;
                if (dict.TryGetValue(character,out value))
                {
                    dict[character] = value + 1;
                }
                else
                {
                    dict.Add(character,1);
                }
            }
            foreach (var entry in dict)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value} time/s");
            }
        }
    }
}
