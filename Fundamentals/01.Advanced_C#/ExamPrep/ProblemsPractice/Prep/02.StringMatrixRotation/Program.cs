//This template is used for the SoftUni Exams
//It redirects from getting user input from the console to getting the input from a input.txt file
//NOTE: comment the 2 lines that have "//COMMNET THIS LINE" comments at the end, 
//to enable user input from the Console instead from the text file
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.StringMatrixRotation
{
    class Program
    {
        static void Main()
        {
            string filePath = "../../input.txt";
            using (var reader = new StreamReader(filePath)) //COMMNET THIS LINE
            {
                Console.SetIn(reader);//COMMNET THIS LINE

                //New Code Starts Here

                List<string> inputLines = new List<string>();
                string command = Console.ReadLine();
                string inputLine = Console.ReadLine();
                int rows = 0;
                int cols = inputLine.Length;
                while (inputLine != "END")
                {
                    inputLines.Add(inputLine);
                    if (inputLine.Length > cols)
                    {
                        cols = inputLine.Length;
                    }
                    rows++;
                    inputLine = Console.ReadLine();
                }
                char[][] matrix = new char[rows][];
                
                //Populate Matrix
                PopulateMatrix(rows, cols, matrix, inputLines);

                //Get rotation degrees
                int degrees = GetDegrees(command);
                int rotCount = (degrees / 90) % 4;
                
                //Rotate matrix
                char[][] rotated = Rotate90(matrix, rotCount);
                
                //Print matrix
                foreach (var row in rotated)
                {
                    Console.WriteLine(new string(row));
                }


            }
        }

        private static char[][] Rotate90(char[][] matrix, int count)
        {
            if (count == 0)
            {
                return matrix;
            }

            int rows = matrix.GetLength(0);
            int cols = matrix[0].Length;
            char[][] result = new char[cols][];

            for (int row = 0; row < result.GetLength(0); row++)
            {
                result[row] = new char[rows];
                for (int col = 0; col < rows; col++)
                {

                    result[row][col] = matrix[col][row];
                }
            }
            for (int row = 0; row < result.GetLength(0); row++)
            {
                result[row] = result[row].Reverse().ToArray();
            }

            return Rotate90(result, count - 1);


        }

        private static int GetDegrees(string command)
        {
            return int.Parse(Regex.Match(command, @"\d+").Value) % 360;
        }

        private static void PopulateMatrix(int rows, int cols, char[][] matrix, List<string> inputLines)
        {
            for (int row = 0; row < rows; row++)
            {
                char[] line = (inputLines[row] + new string(' ', cols - inputLines[row].Length)).ToCharArray();
                matrix[row] = line;
            }
        }
    }
}
