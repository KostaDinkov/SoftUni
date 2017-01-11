//---------------------------------------------------
// SoftUni											 
// Course:      Data Structures						 
// Lecture:     Linear Data Structures - Stacks and Queues	 
// Problem:     03.Ride The Horse							 
// Description: ...						 
//													 
// Date:        Monday 03.2016 18:34 								 
//---------------------------------------------------
namespace _03.RideTheHorse
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        private static readonly Queue<KnightNode> queue = new Queue<KnightNode>();

        private static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());
            var startRow = int.Parse(Console.ReadLine());
            var startCol = int.Parse(Console.ReadLine());

            var matrix = new int[rows, cols];
            var startNode = new KnightNode(new Position(startRow, startCol));
            queue.Enqueue(startNode);
            MoveKnight(matrix);
            var printColumn = cols/2;
            for (var row = 0; row < rows; row++)
            {
                Console.WriteLine(matrix[row, printColumn]);
            }
        }

        private static void MoveKnight(int[,] matrix)
        {
            // PrintMatrix(matrix); // for debugging only

            if (queue.Count == 0)
            {
                return;
            }
            var currentNode = queue.Dequeue();

            // The current node has a valid position (i.e. inside the matrix bounds)
            // so mark the position with the current mark
            matrix[currentNode.Position.Row, currentNode.Position.Col] = currentNode.Mark;

            // Generate all possible moves from the current position
            currentNode.GenerateNeighbours();

            foreach (var neighbour in currentNode.Neighbours)
            {
                // check if the generated node has a valid position inside the matrix
                // and if the mark at that position is 0 (which means unvisited)
                if (NodeIsValid(neighbour, matrix))
                {
                    queue.Enqueue(neighbour);
                }
            }

            // proceed with other elements in queue
            MoveKnight(matrix);
        }

        private static bool NodeIsValid(KnightNode node, int[,] matrix)
        {
            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);

            if ((node.Position.Row < 0) ||
                (node.Position.Row >= rows) ||
                (node.Position.Col < 0) ||
                (node.Position.Col >= cols))
            {
                return false;
            }
            if (matrix[node.Position.Row, node.Position.Col] != 0)
            {
                return false;
            }
            return true;
        }

        private static void PrintMatrix(int[,] matrix)
        {
            Console.WriteLine();
            for (var row = 0; row < matrix.GetLength(0); row++)
            {
                for (var col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }

    internal class KnightNode
    {
        public KnightNode(Position position, int mark = 1)
        {
            this.Position = position;
            this.Mark = mark;
        }

        public int Mark { get; set; }

        public Position Position { get; set; }
        public List<KnightNode> Neighbours { get; set; }

        public void GenerateNeighbours()
        {
            this.Neighbours = new List<KnightNode>
            {
                new KnightNode(new Position(this.Position.Row - 2, this.Position.Col - 1),
                    this.Mark + 1),
                new KnightNode(new Position(this.Position.Row - 2, this.Position.Col + 1),
                    this.Mark + 1),
                new KnightNode(new Position(this.Position.Row - 1, this.Position.Col - 2),
                    this.Mark + 1),
                new KnightNode(new Position(this.Position.Row - 1, this.Position.Col + 2),
                    this.Mark + 1),
                new KnightNode(new Position(this.Position.Row + 1, this.Position.Col - 2),
                    this.Mark + 1),
                new KnightNode(new Position(this.Position.Row + 1, this.Position.Col + 2),
                    this.Mark + 1),
                new KnightNode(new Position(this.Position.Row + 2, this.Position.Col - 1),
                    this.Mark + 1),
                new KnightNode(new Position(this.Position.Row + 2, this.Position.Col + 1),
                    this.Mark + 1)
            };
        }
    }

    internal class Position
    {
        public Position(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; set; }
        public int Col { get; set; }
    }
}