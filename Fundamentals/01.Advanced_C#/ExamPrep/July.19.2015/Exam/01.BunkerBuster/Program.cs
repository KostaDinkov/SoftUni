using System;
using System.Linq;


namespace _01.BunkerBuster
{
    public class Program
    {
        private static int[] dims;
        private static int cols;
        private static int rows;
        private static int[,] field;

        public static void Main()
        {
            dims = Console.ReadLine().Split(' ').Select(i => Convert.ToInt32(i)).ToArray();
            rows = dims[0];
            cols = dims[1];
            field = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                int[] input = Console.ReadLine().Split(' ').Select(element => Convert.ToInt32(element)).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    field[i, j] = input[j];
                }
            }


            //bomb the area
            while (true)
            {
                string targetInput = Console.ReadLine();
                if (targetInput.Equals("cease fire!"))
                {
                    break;
                }
                int[] target = GetTarget(targetInput);
                BombField(target);


            }
            int bunkersDestroyed = 0;
            foreach (var cell in field)
            {
                if (cell <= 0)
                {
                    bunkersDestroyed++;
                }
            }
            Console.WriteLine($"Destroyed bunkers: {bunkersDestroyed}");
            double damage = (((double) bunkersDestroyed)/(rows*cols))*100;
            Console.WriteLine("Damage done: {0:F1} %", damage);


        }

        private static void BombField(int[] target)
        {

            int row = target[0];
            int col = target[1];
            int bombValue = target[2];

            field[row, col] -= bombValue;

            SeekAndDestroy(row, col, -1, -1, bombValue);
            SeekAndDestroy(row, col, -1, 0, bombValue);
            SeekAndDestroy(row, col, -1, 1, bombValue);
            SeekAndDestroy(row, col, 0, -1, bombValue);
            SeekAndDestroy(row, col, 0, 1, bombValue);
            SeekAndDestroy(row, col, 1, -1, bombValue);
            SeekAndDestroy(row, col, 1, 0, bombValue);
            SeekAndDestroy(row, col, 1, 1, bombValue);

        }

        private static void SeekAndDestroy(int row, int col, int rowOffset, int colOffset, int bombValue)
        {
            int fieldHeight = field.GetLength(0);
            int fieldWidth = field.GetLength(1);

            if (row + rowOffset < 0 || row + rowOffset >= fieldHeight || col + colOffset < 0 || col + colOffset >= fieldWidth)
            {
                return;
            }
            field[row + rowOffset, col + colOffset] -= (int)Math.Ceiling(((double)bombValue / 2));

        }

        private static int[] GetTarget(string targetInput)
        {
            string[] tmp = targetInput.Split(' ').ToArray();
            int[] target = new int[3];
            target[0] = int.Parse(tmp[0]);
            target[1] = int.Parse(tmp[1]);
            target[2] = Convert.ToChar(tmp[2]);
            return target;

        }
    }
}
