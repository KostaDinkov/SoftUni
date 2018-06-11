using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ChangeList
{
    class ChangeList
    {
        static void Main()
        {
            List<int> inputList = new List<int>(Console.ReadLine().Split(' ').Select(int.Parse));

            var command = Console.ReadLine();
            while (!command.Contains("Odd") && !command.Contains("Even"))
            {
                var tokens = command.Split(" ");

                switch (tokens[0])
                {
                    case "Delete":
                        inputList.RemoveAll(e => e == int.Parse(tokens[1]));
                        break;
                    case "Insert":
                        inputList.Insert(int.Parse(tokens[2]), int.Parse(tokens[1]));
                        break;
                }

                command = Console.ReadLine();
            }

            switch (command)
            {
                case "Odd":
                    Console.WriteLine(String.Join(' ', inputList.Where((e) => e % 2 != 0)));
                    break;
                case "Even":
                    Console.WriteLine(String.Join(' ', inputList.Where((e) => e % 2 == 0)));
                    break;
            }
        }
    }
}