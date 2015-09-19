//  SoftUni
//  Course:     Advanced C#
//  Lecture:    Multidimensional Arrays, Sets, Dictionaries
//  Problem:    4.Sequence in Matrix
//              We are given a matrix of strings of size N x M. 
//              Sequences in the matrix we define as sets of several neighbour elements 
//              located on the same line, column or diagonal. Write a program that finds 
//              the longest sequence of equal strings in the matrix. 
using System;

namespace Problem4
{
    class P4
    {
        static void Main(string[] args)
        {
            //note: since not mentioned in the specification that the matrix must be read from the use input
            //I will be using hard coded matrices for faster testing and debugging
            //Feel free to change the values of the matrices to test for other cases
            string[,] matrix = 
            {
                {"ha", "fifi", "ho", "hi"},
                {"fo", "ha", "hi", "xx"},
                {"xxx", "ho", "ha", "xx"}
            };

            string[,] matrix2 =
            {
                {"s", "qq", "s"},
                {"pp", "pp", "s"},
                {"pp", "qq", "s"}
            };
            string[,] matrix3 =
            {
                {"aa", "qq", "s","v"},
                {"pp", "s", "s", "r"},
                {"pp", "tt", "tt", "tt"},
                {"x", "f", "b", "tt" }
            };
            FindLongestSequence(matrix);
            Console.WriteLine();
            FindLongestSequence(matrix2);
            Console.WriteLine();
            FindLongestSequence(matrix3);
        }

        private static void FindLongestSequence(string[,] matrix)
        {
            int bestSequenceLen = 0;
            string bestSequence = String.Empty;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    string[] longestSequenceAtPosition = GetLongestSequenceAtPosition(matrix, i, j);
                    if (int.Parse(longestSequenceAtPosition[1]) > bestSequenceLen)
                    {
                        bestSequenceLen = int.Parse(longestSequenceAtPosition[1]);
                        bestSequence = longestSequenceAtPosition[0];
                    }
                }
            }
            string output = String.Empty;
            for (int i = 0; i < bestSequenceLen; i++)
            {
                output = output + bestSequence + ", ";
            }
            
            Console.WriteLine(output.Trim(',', ' '));
            
        }

        private static string[] GetLongestSequenceAtPosition(string[,] matrix, int row, int col)
        {
            int offsetRow = 1;
            int offsetCol = 1;
            string[] result = new string[2];

            int bestSequenceLength = 0;
            string bestSequence = String.Empty;

            //check direction up/right - up=-1, right=+1
            int currentSequenceLength = GetSequenceLengthAtDirection(matrix, row, col, -1, 1);

            if (currentSequenceLength > bestSequenceLength)
            {
                bestSequenceLength = currentSequenceLength;
                bestSequence = matrix[row, col];
            }
            //check direction right - up = 0, right = +1
            currentSequenceLength = GetSequenceLengthAtDirection(matrix, row, col, 0, 1);

            if (currentSequenceLength > bestSequenceLength)
            {
                bestSequenceLength = currentSequenceLength;
                bestSequence = matrix[row, col];
            }
            //check direction down/right - down = +1, right = +1
            currentSequenceLength = GetSequenceLengthAtDirection(matrix, row, col, 1, 1);

            if (currentSequenceLength > bestSequenceLength)
            {
                bestSequenceLength = currentSequenceLength;
                bestSequence = matrix[row, col];
            }
            //check direction down - down = +1, right = 0
            currentSequenceLength = GetSequenceLengthAtDirection(matrix, row, col, 1, 0);

            if (currentSequenceLength > bestSequenceLength)
            {
                bestSequenceLength = currentSequenceLength;
                bestSequence = matrix[row, col];
            }

            result[0] = bestSequence;
            result[1] = bestSequenceLength.ToString();
            return result;

        }

        private static int GetSequenceLengthAtDirection(string[,] matrix, int row, int col, int dirRow, int dirCol)
        {
            int currentSequenceLength =1;
            while ((row + dirRow >= 0 && row+dirRow<matrix.GetLength(0)) && col + dirCol < matrix.GetLength(1))
            {
                if (matrix[row, col] == matrix[row + dirRow, col + dirCol])
                {
                    currentSequenceLength++;
                    //if the direction is zero then don't increment
                    if (dirRow!=0) dirRow++;
                    if (dirCol!=0)dirCol++;
                }
                else
                {
                    break;
                }
            }
            return currentSequenceLength;
        }
    }
}
