//This template is used for the SoftUni Exams
//It redirects from getting user input from the console to getting the input from a input.txt file
//NOTE: comment the 2 lines that have "//COMMNET THIS LINE" comments at the end, 
//to enable user input from the Console instead from the text file

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace P2
{
    internal class Program
    {
        private static int rows;
        private static int cols;
        private static bool isDead = false;
        private static bool isWin;
        private static int[] playerPosition;
        private static char[,] matrix;
        private static int[] lastPosition;

        private static void Main()
        {
#if DEBUG
            var filePath = "../../input.txt";
            using (var reader = new StreamReader(filePath)) //COMMNET THIS LINE

            {

                Console.SetIn(reader); //COMMNET THIS LINE
#endif

                //New Code Starts Here
                matrix = BuildMatrix();
                var commands = Console.ReadLine();

                //get the starting player position
                getPlayerPosition();

                //main loop
                foreach (var command in commands)
                {
                    //Move Player
                    MovePlayer(command);
                    DebugPrint();
                    //Move bunnies
                    MoveBunnies();
                    DebugPrint();

                    //Check Win / Dead condition
                    CheckWinLoose();
                    
                }
#if DEBUG
        }
#endif
        }
        [Conditional("DEBUG")]
        private static void DebugPrint()
        {
            PrintMatrix();
            Console.ReadKey();
            Console.Clear();
        }

        private static void MoveBunnies()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        MarkPosition(row, col - 1);
                        MarkPosition(row, col + 1);
                        MarkPosition(row - 1, col);
                        MarkPosition(row + 1, col);
                    }
                }
            }
            // Populate marked positions
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] == '*')
                    {
                        matrix[row, col] = 'B';
                    }
                }
            }
        }

        private static void MarkPosition(int row, int col)
        {
            if (isInMatrix(row, col) )
            {
                if (matrix[row, col] == '.')
                {
                    matrix[row, col] = '*';
                }
                else if (matrix[row, col] == 'P')
                {
                    isDead = true;
                    matrix[row, col] = '*';
                }
            }
        }

        private static void MovePlayer(char command)
        {
            int row = playerPosition[0];
            int col = playerPosition[1];

            matrix[row, col] = '.';

            switch (command)
            {
                case 'U':
                    Move(row - 1, col);
                    break;
                case 'D':
                    Move(row + 1, col);
                    break;
                case 'R':
                    Move(row, col + 1);
                    break;
                case 'L':
                    Move(row, col - 1);
                    break;
            }
        }

        private static void Move(int row, int col)
        {
            if (isInMatrix(row, col))
            {
                //check for collision
                if (matrix[row, col] == 'B')
                {
                    isDead = true;
                    playerPosition[0] = row;
                    playerPosition[1] = col;
                }
                //if cell is free...
                if (matrix[row, col] == '.')
                {
                    matrix[row, col] = 'P';
                    playerPosition[0] = row;
                    playerPosition[1] = col;
                }
            }
            else
            {
                isWin = true;
            }
        }

        private static bool isInMatrix(int row, int col)
        {
            if (row < 0 || row >= rows || col < 0 || col >= cols)
            {
                return false;
            }
            return true;
        }

        private static void CheckWinLoose()
        {
            if (isWin || isDead)
            {
                PrintMatrix();
                var text = isDead ? "dead" : "won";
                Console.WriteLine($"{text}: {playerPosition[0]} {playerPosition[1]}");
                
                Environment.Exit(0);
            }
        }

        private static char[,] BuildMatrix()
        {
            var dims = Console.ReadLine().Split(' ').Select(n => int.Parse(n)).ToArray();
            rows = dims[0];
            cols = dims[1];
            var matrix = new char[rows, cols];
            for (var i = 0; i < rows; i++)
            {
                var inputLine = Console.ReadLine();
                for (var j = 0; j < cols; j++)
                {
                    matrix[i, j] = inputLine[j];
                }
            }
            return matrix;
        }

        private static void PrintMatrix()
        {
            for (var row = 0; row < rows; row++)
            {
                for (var col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void getPlayerPosition()
        {
            playerPosition = new int[2];
            for (var row = 0; row < rows; row++)
            {
                for (var col = 0; col < cols; col++)
                {
                    if (matrix[row, col] == 'P')
                    {
                        playerPosition[0] = row;
                        playerPosition[1] = col;
                        return;
                    }
                }
            }
        }
    }
}