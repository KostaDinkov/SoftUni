using System;
using System.Linq;
using System.Numerics;



namespace _02.ArraySlider
{
    class Program
    {
        static int currIndex;

        static void Main()
        {
            string[] input = Console.ReadLine().Split(default(char[]), StringSplitOptions.RemoveEmptyEntries);
            BigInteger[] arr = input.Select(BigInteger.Parse).ToArray();
            while (true)
            {
                string command = Console.ReadLine();
                if (command.Equals("stop"))
                {
                    break;
                }
                ExecuteCommand(arr, command);
            }
            PrintArray(arr);
        }

        private static void ExecuteCommand(BigInteger[] arr, string command)
        {
            // Process command
            string[] commandArgs = command.Split(' ');
            BigInteger offset = BigInteger.Parse(commandArgs[0]);
            string operation = commandArgs[1];
            BigInteger operand = BigInteger.Parse(commandArgs[2]);
            currIndex = (int)(currIndex + offset) % arr.Length;
            if (currIndex < 0) currIndex = arr.Length + (currIndex % arr.Length);
            //Do work
            switch (operation)
            {
                case "&": arr[currIndex] = arr[currIndex] & operand; break;
                case "|": arr[currIndex] = arr[currIndex] | operand; break;
                case "^": arr[currIndex] = arr[currIndex] ^ operand; break;
                case "+": arr[currIndex] = arr[currIndex] + operand; break;
                case "-":
                    arr[currIndex] = arr[currIndex] - operand;
                    if (arr[currIndex] < 0) arr[currIndex] = 0; break;
                case "*": arr[currIndex] = arr[currIndex] * operand; break;
                case "/": arr[currIndex] = arr[currIndex] / operand; break;
            }
        }
        private static void PrintArray(BigInteger[] arr)
        {
            Console.WriteLine("[" + string.Join(", ", arr) + "]");
        }
    }
}
