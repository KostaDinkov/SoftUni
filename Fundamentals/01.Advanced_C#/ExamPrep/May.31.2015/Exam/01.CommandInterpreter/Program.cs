using System;
using System.IO;
using System.Numerics;

namespace _01.CommandInterpreter
{
    class Program
    {
        static void Main()
        {
            string filePath = @"../../input.txt";
            using (TextReader reader = new StreamReader(filePath)) // comment this line
            {
                Console.SetIn(reader);// and this line
                string[] arr = Console.ReadLine().Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

                string commandLine = Console.ReadLine();
                while (!commandLine.Equals("end"))
                {
                    ProcessCommand(arr, commandLine);
                    commandLine = Console.ReadLine();
                }
                PrintArray(arr);
            }
        }

        private static void PrintArray(string[] arr)
        {
            Console.WriteLine("[" + string.Join(", ", arr) + "]");
        }

        private static void ProcessCommand(string[] arr, string commandLine)
        {
            string[] commandArgs = commandLine.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            string command = commandArgs[0];

            switch (command)
            {
                case "reverse":
                    Reverse(arr, commandArgs[2], commandArgs[4]);
                    break;
                case "sort":
                    Sort(arr, commandArgs[2], commandArgs[4]);
                    break;
                case "rollLeft":
                    Roll(arr, int.Parse(commandArgs[1]), "left");
                    break;
                case "rollRight":
                    Roll(arr, int.Parse(commandArgs[1]), "right");
                    break;

            }
        }


        internal static void Roll( object[] array, BigInteger offset, string dir)
        {
            if (offset<0)
            {
                Console.WriteLine("Invalid input parameters.");
                return;
            }
            if (dir=="left")
                offset *= -1;
            
            if (offset == 0 || array.Length <= 1)
                return;

            offset = offset % array.Length;
            if (offset == 0)
                return;

            if (offset < 0)
                offset =  array.Length + offset;

            Array.Reverse(array, 0, array.Length);
            Array.Reverse(array, 0, (int)offset);
            Array.Reverse(array, (int)offset, (int)(array.Length - offset));
        }

        private static void Sort(string[] arr, string index, string length)
        {
            BigInteger start = BigInteger.Parse(index);
            BigInteger count = BigInteger.Parse(length);
            if (start + count >arr.Length || start < 0 || count<0 || start>=arr.Length)
            {
                Console.WriteLine("Invalid input parameters.");
                return;
            }
            Array.Sort(arr,(int)start,(int)count );
            }

        private static void Reverse(string[] arr, string index, string length)
        {
            BigInteger start = BigInteger.Parse(index);
            BigInteger count = BigInteger.Parse(length);
            if (start + count >arr.Length || start < 0 || count<0 || start >= arr.Length)
            {
                Console.WriteLine("Invalid input parameters.");
                return;
            }
            Array.Reverse(arr, (int)start, (int)count);
        }
    }
}
