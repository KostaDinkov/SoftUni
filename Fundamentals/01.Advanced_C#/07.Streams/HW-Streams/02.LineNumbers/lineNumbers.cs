//SoftUni
//Course:   Advanced C#
//Lecture:  Streams and Files
//Problem:  2. Line Numbers
//          Write a program that reads a text file and inserts line numbers 
//          in front of each of its lines.The result should be written 
//          to another text file. Use StreamReader in combination with 
//          StreamWriter.


using System.IO;

namespace _01.OddLines
{
    class LineNumbers

    {
        static void Main()
        {
            string filePath = "../../Sample.txt";
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                int lineNumber = 1;
                while ((line = reader.ReadLine()) != null)
                {
                    using (StreamWriter writer = new StreamWriter("../../Sample-numbers.txt", true))
                    {
                        writer.WriteLine(lineNumber+ " " + line);
                    }
                    lineNumber++;
                }
            }
        }
    }
}