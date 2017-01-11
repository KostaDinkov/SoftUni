using System;
using System.Collections.Generic;
using System.Text;

public class EscapeFromLabyrinth
{
    private const char VisitedCell = 's';
    private static int cols = 9;
    private static int rows = 7;

    private static char[,] labyrinth =
    {
        {'*', '*', '*', '*', '*', '*', '*', '*', '*'},
        {'*', '-', '-', '-', '-', '*', '*', '-', '-'},
        {'*', '*', '-', '*', '-', '-', '-', '-', '*'},
        {'*', '-', '-', '*', '-', '*', '-', '*', '*'},
        {'*', 's', '*', '-', '-', '*', '-', '*', '*'},
        {'*', '*', '-', '-', '-', '-', '-', '-', '*'},
        {'*', '*', '*', '*', '*', '*', '*', '-', '*'}
    };

    public static void Main()
    {
        ReadLabyrinth();
        var shortestPathToExit = FindShortestPathToExit();
        if (shortestPathToExit == null)
        {
            Console.WriteLine("No exit!");
        }
        else if (shortestPathToExit == "")
        {
            Console.WriteLine("Start is at the exit.");
        }
        else
        {
            Console.WriteLine($"Shortest exit: " + shortestPathToExit);
        }
    }

    private static string FindShortestPathToExit()
    {
        var queue = new Queue<Point>();
        var startPosition = FindStartPosition();
        if (startPosition == null)
        {
            return null;
        }
        queue.Enqueue(startPosition);
        while (queue.Count > 0)
        {
            var currentCell = queue.Dequeue();
            if (IsExit(currentCell))
            {
                return TracePathBack(currentCell);
            }
            TryDirection(queue, currentCell, "U", 0, -1);
            TryDirection(queue, currentCell, "R", 1, 0);
            TryDirection(queue, currentCell, "D", 0, 1);
            TryDirection(queue, currentCell, "L", -1, 0);
        }
        return null;
    }

    private static string TracePathBack(Point currentCell)
    {
        var path = new StringBuilder();
        while (currentCell.PreviousPoint != null)
        {
            path.Append(currentCell.Direction);
            currentCell = currentCell.PreviousPoint;
        }
        var pathReversed = new StringBuilder(path.Length);
        for (var i = path.Length - 1; i >= 0; i--)
        {
            pathReversed.Append(path[i]);
        }
        return pathReversed.ToString();
    }

    private static void TryDirection(Queue<Point> queue, Point currentCell, string direction,
        int deltaCol, int deltaRow)
    {
        var newRow = currentCell.Row + deltaRow;
        var newCol = currentCell.Col + deltaCol;

        if ((newCol >= 0) &&
            (newCol < cols) &&
            (newRow >= 0) &&
            (newRow < rows) &&
            (labyrinth[newRow, newCol] == '-'))
        {
            labyrinth[newRow, newCol] = VisitedCell;
            var nextCell = new Point
            {
                Row = newRow,
                Col = newCol,
                Direction = direction,
                PreviousPoint = currentCell
            };
            queue.Enqueue(nextCell);
        }
    }

    private static bool IsExit(Point currentCell)
    {
        if ((currentCell.Row == 0) ||
            (currentCell.Row == rows - 1) ||
            (currentCell.Col == 0) ||
            (currentCell.Col == cols - 1))
        {
            return true;
        }
        return false;
    }

    private static Point FindStartPosition()
    {
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                if (labyrinth[i, j] == VisitedCell)
                {
                    return new Point {Row = i, Col = j};
                }
            }
        }
        return null;
    }

    private static void ReadLabyrinth()
    {
        cols = int.Parse(Console.ReadLine());
        rows = int.Parse(Console.ReadLine());
        labyrinth = new char[rows, cols];
        for (var row = 0; row < rows; row++)
        {
            var rowInput = Console.ReadLine();
            for (var col = 0; col < cols; col++)
            {
                labyrinth[row, col] = rowInput[col];
            }
        }
    }
}

public class Point
{
    public int Row { get; set; }
    public int Col { get; set; }

    public string Direction { get; set; }

    public Point PreviousPoint { get; set; }
}