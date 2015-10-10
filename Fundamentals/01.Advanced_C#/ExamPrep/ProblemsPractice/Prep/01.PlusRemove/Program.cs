//This template is used for the SoftUni Exams
//It redirects from getting user input from the console to getting the input from a input.txt file
//NOTE: comment the 2 lines that have "//COMMNET THIS LINE" comments at the end, 
//to enable user input from the Console instead from the text file
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _01.PlusRemove
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
                //Building the jagged array
                List<string> inputLines = new List<string>();
                string inputLine = Console.ReadLine();
                while (inputLine != "END")
                {
                    inputLines.Add(inputLine);
                    inputLine = Console.ReadLine();
                }
                char[][] matrix = new char[inputLines.Count][];
                for (int line = 0; line < inputLines.Count; line++)
                {
                    matrix[line] = inputLines[line].ToCharArray();
                }

                //Check PLUS regions 
                List<Tuple<int, int>> plusCenters = new List<Tuple<int, int>>();
                for (int row = 1; row < matrix.GetLength(0) - 1; row++)
                {
                    for (int col = 1; col < matrix[row].Length - 1; col++)
                    {
                        //check if its a plus
                        if (IsPlus(matrix, row, col))
                        {
                            //remember the center index
                            plusCenters.Add(new Tuple<int, int>(row, col));
                        }


                    }
                }
                //Mark the Pluses
                foreach (var center in plusCenters)
                {
                    MarkCenter(matrix, center.Item1, center.Item2);
                }
                //PrintMatrix(matrix);

                //Remove the marked cells and print
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    string resultLine = String.Join("",matrix[row]).Replace("Ю","");
                    Console.WriteLine(resultLine);
                }



            }
        }

        private static void PrintMatrix(char[][] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col]);
                }
                Console.WriteLine();
            }
        }

        private static void MarkCenter(char[][] matrix, int item1, int item2)
        {
            matrix[item1][item2] = 'Ю';
            matrix[item1+1][item2] = 'Ю';
            matrix[item1-1][item2] = 'Ю';
            matrix[item1][item2+1] = 'Ю';
            matrix[item1][item2-1] = 'Ю';
        }

        private static bool IsPlus(char[][] matrix, int row, int col)
        {
            char center = char.ToLower(matrix [row][col]);
            try
            {
                if (center == char.ToLower(matrix[row - 1][col]) &&
                        center == char.ToLower(matrix[row + 1][col]) &&
                        center == char.ToLower(matrix[row][col - 1])  &&
                        center == char.ToLower(matrix[row][col + 1]) )

                {
                    return true;
                }
                return false;
            }
            catch (IndexOutOfRangeException)
            {

                return false;
            }
        }
    }
}
