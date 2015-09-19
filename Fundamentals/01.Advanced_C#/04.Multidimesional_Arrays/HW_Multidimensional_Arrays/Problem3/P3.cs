//  SoftUni
//  Course:     Advanced C#
//  Lecture:    Multidimensional Arrays, Sets, Dictionaries
//  Problem:    3.Matrix Shuffling
//              Write a program which reads a string matrix from the console 
//              and performs certain operations with its elements.User input is provided like 
//              in the problem above – first you read the dimensions and then the data.
//              Remember, you are not required to do this step first, you may add this functionality later.  
//              Your program should then receive commands in format: "swap x1 y1 x2 y2" 
//              where x1, x2, y1, y2 are coordinates in the matrix. In order for a command to be valid, 
//              it should start with the "swap" keyword along with four valid coordinates '
//              (no more, no less). You should swap the values at the given coordinates(cell[x1, y1] 
//              with cell[x2, y2]) and print the matrix at each step(thus you'll be able to check if the 
//              operation was performed correctly). 
//              If the command is not valid (doesn't contain the keyword "swap", has fewer or more 
//              coordinates entered or the given coordinates do not exist), print "Invalid input!" and 
//              move on to the next command. Your program should finish when the string "END" is entered. 

using System;
using System.Linq;


namespace Problem3
{
    class P3
    {
        static void Main()
        {
            String[,] matrix = GetMatrixFromUserInput();
            string command = String.Empty;
            string tmp = String.Empty;

            while (!command.Equals("END"))
            {
                string commandLine = Console.ReadLine();
                string[] arguments = commandLine.Split(' ').ToArray();
                command = arguments[0];

                if (!command.Equals("END") && arguments.Length!=5)
                {
                    Console.WriteLine("Invalid Input");
                }
                else if (command.Equals("swap"))
                {
                    int rowA = int.Parse(arguments[1]);
                    int colA = int.Parse(arguments[2]);
                    int rowB = int.Parse(arguments[3]);
                    int colB = int.Parse(arguments[4]);
                    try
                    {
                        tmp = matrix[rowA, colA];
                        matrix[rowA, colA] = matrix[rowB, colB];
                        matrix[rowB, colB] = tmp;
                        PrintMatrix(matrix);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("Invalid Input");
                    }
                }
            }
        }
        private static string[,] GetMatrixFromUserInput()
        {
            

            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            string[,] matrix = new string[rows, cols];
            
            for (int i = 0; i < rows; i++)
            {
                
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = Console.ReadLine();
                }
            }
            return matrix;
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j].ToString().PadLeft(5, ' '));
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
