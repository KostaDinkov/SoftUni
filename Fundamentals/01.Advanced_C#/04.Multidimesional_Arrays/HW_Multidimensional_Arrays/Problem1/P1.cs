//  SoftUni
//  Course:     Advanced C#
//  Lecture:    Multidimensional Arrays, Sets, Dictionaries
//  Problem:    1.Fill the Matrix
//              Write two programs that fill and print a matrix of size N x N. 
//              Filling a matrix in the regular pattern (top to bottom and left to right) 
//              is boring. Fill the matrix as described in both patterns below:         

using System;


namespace Problem1
{
    class P1
    {
        static void Main()
        {
            //change the next two values to generate matrices of different size
            int rows = 5;
            int cols = 7;
            
            int[,] matrixA = GenerateMatrixA(rows, cols);
            PrintMatrix(matrixA);
            
            int[,] matrixB = GenerateMatrixB(rows, cols);
            PrintMatrix(matrixB);

        }

        private static int[,] GenerateMatrixB(int rows, int cols)
        {
            int counter = 1;
            int[,] matrixB = new int[rows, cols];
            for (int i = 0; i < cols; i++)
            {
                if (i % 2 != 0)
                {
                    for (int j = rows - 1; j >= 0; j--)
                    {
                        matrixB[j, i] = counter;
                        counter++;
                    }
                }
                else
                {
                    for (int j = 0; j < rows; j++)
                    {
                        matrixB[j, i] = counter;
                        counter++;
                    }
                }
            }
            return matrixB;
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

        private static int[,] GenerateMatrixA(int rows, int cols)
        {
            int counter = 1;
            int[,] matrixA = new int[rows, cols];
            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    matrixA[j, i] = counter;
                    counter++;
                }
            }
            return matrixA;

        }
    }
}
