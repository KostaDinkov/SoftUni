//  SoftUni
//  Course:     Advanced C#
//  Lecture:    Multidimensional Arrays, Sets, Dictionaries
//  Problem:    1.Fill the Matrix
//              Write a program that reads a rectangular integer matrix of size N x M and 
//              finds in it the square 3 x 3 that has maximal sum of its elements. 
//              On the first line, you will receive the rows N and columns M.On the 
//              next N lines you will receive each row with its columns.
//              Print the elements of the 3 x 3 square as a matrix, along with their sum.


using System;
using System.Linq;


namespace Problem2
{
    class P2
    {
        static void Main(string[] args)
        {
            // polygon (rectangle) size
            int polyRows = 3;
            int polyCols = 3;
            // this is used for testing purposes
            int[,] testArray = new int[4,5]
            {
                 {1, 5, 5, 2, 4},
                 {2, 1, 4, 14, 3},
                 {3, 7, 11, 2, 8},
                 {4, 8, 12, 16, 4} 
            };
            var matrix = GetMatrixFromUserInput();
            int[,] maxSumMatrix = GetMaxSumArray(matrix, polyRows, polyCols);
            Console.WriteLine("Sum = " + GetSumAtIndex( maxSumMatrix, 0, 0, polyRows, polyCols));
            PrintMatrix(maxSumMatrix);
            


        }

        private static int[,] GetMatrixFromUserInput()
        {
            Console.WriteLine("Enter Dimensions: ");
            int[] dims = Console.ReadLine().Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
            int rows = dims[0];
            int cols = dims[1];
            int[,] matrix = new int[rows, cols];
            Console.WriteLine("Enter matrix: ");
            for (int i = 0; i < rows; i++)
            {
                int[] input = Console.ReadLine().Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = input[j];
                }
            }
            return matrix;
        }

        private static int[,] GetMaxSumArray(int[,] matrix, int rows, int cols)
        {
            int maxSum = 0;
            int maxSumRow = 0;
            int maxSumCol = 0;
            for (int i = 0; i <= matrix.GetLength(0)-rows; i++)
            {
                for (int j = 0; j <= matrix.GetLength(1)-cols; j++)
                {
                    int sum = GetSumAtIndex(matrix, i, j, rows, cols);
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxSumCol = j;
                        maxSumRow = i;
                    }
                }
            }
            return ExtractSubMatrixAt(matrix, maxSumRow, maxSumCol, rows, cols);

        }

        private static int[,] ExtractSubMatrixAt(int[,] matrix, int startRow, int startCol, int rows, int cols)
        {
            int [,] subMatrix = new int[rows,cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    subMatrix[i, j] = matrix[i + startRow, j + startCol];
                }
            }
            return subMatrix;

        }

        private static int GetSumAtIndex(int[,] matrix, int startRow, int startCol, int row, int col )
        {
            int sum = 0;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    sum = sum + matrix[startRow +i, startCol + j];
                }
            }
            return sum;
            
        }

        private static void PrintMatrix(int[,] matrixA)
        {
            for (int i = 0; i < matrixA.GetLength(0); i++)
            {
                for (int j = 0; j < matrixA.GetLength(1); j++)
                {
                    Console.Write(matrixA[i, j].ToString().PadLeft(5, ' '));
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
