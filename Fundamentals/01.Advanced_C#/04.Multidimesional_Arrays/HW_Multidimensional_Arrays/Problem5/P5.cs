//  SoftUni
//  Course:     Advanced C#
//  Lecture:    Multidimensional Arrays, Sets, Dictionaries
//  Problem:    5.Collect the cons
//              Working with multidimensional arrays can be(and should be) 
//              fun.Let's make a game out of it.
//              You receive the layout of a board from the console.Assume it will 
//              always have 4 rows which you'll get as strings, each on a separate line. Each character 
//              in the strings will represent a cell on the board. Note that the strings may be of different length.
//              You are the player and start at the top-left corner (that would be position [0, 0] on 
//              the board). On the fifth line of input you'll receive a string with movement 
//              commands which tell you where to go next, it will contain only these four characters – '>' (move right), '<' (move left), '^' (move up) and 'v' (move down). 
//              You need to keep track of two types of events – collecting coins
//              (represented by the symbol '$', of course) and hitting the walls of the board
//              (when the player tries to move off the board to invalid coordinates). 
//              When all moves are over, print the amount of money collected and the number of walls hit.

using System;


namespace Problem5
{
    class P5
    {
        static int wallCount ;
        static void Main()
        {
            char[][] testBoard = 
            {
                new[] {'S', 'j', '0','u', '$', 'h', 'b', 'c'},
                new[] { '$', '8', '7', 'y', 'i', 'h', 'c', '8', '7'},
                new[] { 'E', 'w', 'g', '3', '4', '4', '4'},
                new[] { '$', '4', '$', '$' }
            };
            string testCommandLine = "V>>^^>>>VVV<<";


            char[][] board = new char[4][];
            for (int i = 0; i < 4; i++)
            {
                board[i] = Console.ReadLine().ToCharArray();
            }
            string commandLine = Console.ReadLine();

            int coinCount = 0;
            
            int[] currentPos = { 0, 0 };
            coinCount = coinCount + CheckPosition(board, currentPos);
            foreach (var command in commandLine)
            {
                //Move
                currentPos = Move(board, currentPos, command);
                //check current position for coins and if any are found, increment coinCount
                coinCount = coinCount + CheckPosition(board, currentPos);
            }
            Console.WriteLine("Coins collected: " + coinCount);
            Console.WriteLine("Walls hit: " + wallCount);
        }

        private static int[] Move(char[][] board, int[] currentPos, char command)
        {
            command = char.ToLower(command);
            switch (command)
            {
                case '>':
                    if (DoesPositionExist(board, currentPos[0], currentPos[1] + 1))
                    {
                        currentPos[1]++;
                        return currentPos;
                    }
                    wallCount++;
                    break;

                case ('^'):
                    if (DoesPositionExist(board, currentPos[0] - 1, currentPos[1]))
                    {
                        currentPos[0]--;
                        return currentPos;
                    }
                    wallCount++;
                    break;
                case ('<'):
                    if (DoesPositionExist(board, currentPos[0], currentPos[1] - 1))
                    {
                        currentPos[1]--;
                        return currentPos;
                    }
                    wallCount++;
                    break;
                case ('v'):
                    if (DoesPositionExist(board, currentPos[0] + 1, currentPos[1]))
                    {
                        currentPos[0]++;
                        return currentPos;
                    }
                    wallCount++;
                    break;
            }

            return currentPos;
        }

        private static bool DoesPositionExist(char[][] board, int row, int col)
        {
            int[] position = new[] { row, col };
            try
            {
                CheckPosition(board, position);
                return true;
            }
            catch (IndexOutOfRangeException)
            {

                return false;
            }
        }

        private static int CheckPosition(char[][] board, int[] currentPos)
        {
            if (board[currentPos[0]][currentPos[1]]=='$')
            {
                return 1;
            }
            return 0;
        }
    }
}
