using System;
using System.IO;
using System.Linq;


namespace _02.TargetPractice
{
    class Program
    {
        private static int rows;
        private static int cols;

        static void Main()
        {
            char[,] arr;
            string filePath = @"../../input.txt";
            using (TextReader reader = new StreamReader(filePath))
            {
                Console.SetIn(reader);

                //Build the stairs
                int[] dims = Console.ReadLine().Split(' ').Select(i => Convert.ToInt32(i)).ToArray();
                rows = dims[0];
                cols = dims[1];
                arr = new char[rows, cols];

                //Release the snakes
                ReleaseTheSnakes(arr);

                //Shoot the snakes
                ShootEmAll(arr);

                //Collect snake bits
                SnakeTris(arr);

                //Print the gore
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        Console.Write(arr[row,col]);
                    }
                    Console.WriteLine();
                }
            }
        }

        private static void SnakeTris(char[,] arr)
        {
            for (int row = rows - 1; row > 0; row--)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (arr[row, col] == ' ')
                    {
                        arr[row, col] = GetCharFromAbove(arr, row - 1, col);
                    }
                }
            }
        }

        private static char GetCharFromAbove(char[,] arr, int row, int col)
        {
            if (row < 0)
            {
                return ' ';
            }

            if (arr[row, col] == ' ')
            {
                return GetCharFromAbove(arr, row - 1, col);
            }
            char goinDown = arr[row, col];
            arr[row, col] = ' ';
            return goinDown;


        }

        private static void ShootEmAll(char[,] arr)
        {
            int[] shot = Console.ReadLine().Split(' ').Select(i => Convert.ToInt32(i)).ToArray();
            int shotRow = shot[0];
            int shotCol = shot[1];
            int shotRadius = shot[2];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    int cellDistance = (row - shotRow) * (row - shotRow) + (col - shotCol) * (col - shotCol);
                    if (cellDistance <= shotRadius * shotRadius)
                    {
                        arr[row, col] = ' ';
                    }
                }
            }
        }

        private static void ReleaseTheSnakes(char[,] arr)
        {
            string snake = Console.ReadLine();
            int snakeIndex = 0;
            string dir = "left";
            for (int row = rows - 1; row >= 0; row--)
            {
                if (dir == "left")
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        arr[row, col] = snake[snakeIndex % snake.Length];
                        snakeIndex++;
                    }
                    dir = "right";
                }
                else
                {
                    for (int col = 0; col < cols; col++)
                    {
                        arr[row, col] = snake[snakeIndex % snake.Length];
                        snakeIndex++;
                    }
                    dir = "left";
                }
            }
        }
    }
}
