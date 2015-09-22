//  SoftUni
//  Course:     Algorithms
//  Lecture:    Recursion
//  Problem:    5.Paths between Cells in Matrix
//              We are given a matrix of passable and non-passable cells.Write a recursive 
//              program for finding all paths between two cells in the matrix. The matrix 
//              can be represented by a two-dimensional char array or a string array, passable 
//              cells are represented by a space (' '), non-passable cells are represented by 
//              asterisks('*'), the start cell is represented by the symbol 's' and the exit cell is 
//              represented by 'e'. Movement is allowed in all four directions(up, down, left, right) and a cell 
//              can be passed only once in a given path.Print on the console all paths and on the last
//              line the count of paths found.You can represent the directions with symbols, e.g. 'D' 
//                  for down, 'U' for up, etc.The ordering of the paths is not relevant.


using System;
using System.Collections.Generic;

namespace Problem5
{

    class P5
    {
        private static List<char> path = new List<char>();
        static void Main()
        {
            char[,] labytinth =
            {
                {' ',' ',' ',' '},
                {' ','*','*',' '},
                {' ','*','*',' '},
                {' ','*','e',' '},
                {' ',' ',' ',' '}
            };
            //TODO get matrix from user input or text file
            FindPath(labytinth,0,0,'S');
        }

        static void FindPath(char[,] labyrinth, int row, int col, char direction)
        {
            if (row < 0 || row >= labyrinth.GetLength(0) || col < 0 || col >= labyrinth.GetLength(1) )
            {
                return;
            }
            if (labyrinth[row, col] == 'e')
            {
                Console.WriteLine(string.Join("", path).Substring(1) + direction);
            }
            if (labyrinth[row,col]!=' ')
            {
                return;
            }
            
            labyrinth[row, col] = 'x';
            path.Add(direction);
            FindPath(labyrinth, row + 1, col, 'D'); //Down
            FindPath(labyrinth, row, col + 1,'R'); //Left
            FindPath(labyrinth, row - 1, col,'U'); //Up
            FindPath(labyrinth, row, col - 1,'L'); //Right
            labyrinth[row, col] = ' ';
            path.RemoveAt(path.Count-1);
        }
    }
}
