//SoftUni
//Course:   Advanced C#
//Lecture:  Streams and Files
//Problem:  1. Odd Lines
//          Write a program that reads a text file and prints on 
//          the console its odd lines. Line numbers starts from 0. 
//          Use StreamReader.

//NOTE: Assuming that the 1st line in the text file is the actual line we want to start printing from.
using System.IO;
using static System.Console;

namespace _01.OddLines
{
    class OddLines
    {
        static void Main()
        {
            string filePath = "../../Sample.txt";
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                int lineNumber = 1;
                while ((line=reader.ReadLine())!=null)
                {
                    if (lineNumber %2 !=0)
                    {
                        WriteLine(line);
                    }
                    lineNumber++;
                }
            }
        }
    }
}
