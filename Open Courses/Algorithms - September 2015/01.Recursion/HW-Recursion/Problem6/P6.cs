//  SoftUni
//  Course:     Algorithms
//  Lecture:    Recursion
//  Problem:    6.Connected Areas in a Matrix
//              Let’s define a connected area in a matrix as an area of cells in which there is a 
//              path between every two cells. Write a program to find all connected areas in a matrix. 
//              On the console, print the total number of areas found, and on a separate line some 
//              info about each of the areas – its position (top-left corner) and size. Order the 
//              areas by size (in descending order) so that the largest area is printed first. 
//              If several areas have the same size, order them by their position, first by the row, 
//              then by the column of the top-left corner. So, if there are two connected areas 
//              with the same size, the one which is above and/or to the left of the other will be printed first.


using System;
using System.Collections.Generic;

namespace Problem6
{
    class P6
    {
        private static int areaSize =0;
        private static List<Tuple<int,int,int>> areas = new List<Tuple<int, int, int>>(); 

        
        static void Main()
        {
            char[,] labytinth =
                //{
                //    {' ',' ',' ','*',' ',' ',' ','*',' '},
                //    {' ',' ',' ','*',' ',' ',' ','*',' '},
                //    {' ',' ',' ','*',' ',' ',' ','*',' '},
                //    {' ',' ',' ',' ','*',' ','*',' ',' '}
                
                //};
            {
                {'*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ',' '},
                {'*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ',' '},
                {'*', ' ', ' ', '*', '*', '*', '*', '*', ' ',' '},
                {'*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ',' '},
                {'*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ',' '}
            };
            //TODO get matrix from user input or text file
            FindAllAreas(labytinth);
            //Sort the list of areas
            areas.Sort((x, y) =>
            {
                //first sort by the size in descending order
                int result = y.Item1.CompareTo(x.Item1);
                //then by the row in ascending order
                result = result == 0 ? x.Item2.CompareTo(y.Item2) : result;
                //and finally by the column in ascending order
                return result == 0 ? x.Item3.CompareTo(y.Item3):result;
            });
            //Print the list
            for (int index = 0; index <areas.Count; index++)
            {
                Console.WriteLine($"Area #{index+1} at ({areas[index].Item2}, {areas[index].Item3}), size: {areas[index].Item1}");
            }
            
        }
/// <summary>
/// Finds all connected areas in a char matrix and collects data about area size, row and column
/// </summary>
/// <param name="labyrinth">A matrix containing  areas of similar symbols and a 'background'</param>
        static void FindAllAreas(char[,] labyrinth)
        {
            //TODO Optimize the matrix traversing
            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    if (labyrinth[row,col] != '*')
                    {
                        FindArea(labyrinth,row,col);
                        areas.Add(new Tuple<int, int, int>( areaSize, row, col ));
                        areaSize = 0;
                    }
                }
            }
        }

        static void FindArea(char[,] labyrinth, int row, int col)
        {
            if (row < 0 || row >= labyrinth.GetLength(0) || col < 0 || col >= labyrinth.GetLength(1))
            {
                return;
            }
            
            if (labyrinth[row, col] != ' ')
            {
                return;
            }
            labyrinth[row, col] = '*';
            areaSize++;
            FindArea(labyrinth, row + 1, col); 
            FindArea(labyrinth, row, col + 1); 
            FindArea(labyrinth, row - 1, col); 
            FindArea(labyrinth, row, col - 1); 
            
            
        }
    }
}
