using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.BombNumbers
{
    class BombNumbers
    {
        static void Main(string[] args)
        {
            var list = new List<int>(Console.ReadLine().Split(" ").Select(int.Parse));
            var special = new List<int>(Console.ReadLine().Split(" ").Select(int.Parse));
            var bomb = special[0];
            var power = special[1];


            while (true)
            {
                if (!list.Contains(bomb)) break;
                var bombIndex = list.IndexOf(bomb);
                for (int i = bombIndex - power; i <= bombIndex + power; i++)
                {
                    if (i < 0 || i >= list.Count)
                    {
                        continue;
                    }

                    list[i] = 0;
                }
            }

            Console.WriteLine(list.Sum());
        }
    }
}