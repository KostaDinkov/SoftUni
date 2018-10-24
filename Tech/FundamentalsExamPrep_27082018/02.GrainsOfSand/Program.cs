using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.GrainsOfSand
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var sequence = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "Mort")
                {
                    break;
                }

                var commandArgs = input.Split();
                var command = commandArgs[0];
                int value;

                switch (command)
                {
                    case "Add":
                        value = int.Parse(commandArgs[1]);
                        Add(value, sequence);
                        break;
                    case "Remove":
                        value = int.Parse(commandArgs[1]);
                        Remove(value, sequence);
                        break;
                    case "Replace":
                        value = int.Parse(commandArgs[1]);
                        var replacement = int.Parse(commandArgs[2]);
                        Replace(value, replacement, sequence);
                        break;
                    case "Increase":
                        value = int.Parse(commandArgs[1]);
                        Increase(value, sequence);
                        break;
                    case "Collapse":
                        value = int.Parse(commandArgs[1]);
                        Collapse(value, sequence);
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", sequence));
        }

        private static void Collapse(int value, List<int> sequence)
        {
            sequence.RemoveAll(x => x < value);
        }

        private static void Add(int value, List<int> sequence)
        {
            sequence.Add(value);
        }

        private static void Remove(int value, List<int> sequence)
        {
            var removed = sequence.Remove(value);
            if (removed) return;
            if (value < sequence.Count)
            {
                sequence.RemoveAt(value);
            }
        }

        private static void Replace(int value, int replacement, List<int> sequence)
        {
            var index = sequence.IndexOf(value);
            if (index < 0)
            {
                return;
            }

            sequence[index] = replacement;
        }

        private static void Increase(int value, List<int> sequence)
        {
            var increment = sequence[sequence.Count - 1];
            foreach (var element in sequence)
            {
                if (element >= value)
                {
                    increment = element;
                    break;
                }
            }

            //increase all elements with increment amount

            for (var i = 0; i < sequence.Count; i++)
            {
                sequence[i] += increment;
            }
        }
    }
}