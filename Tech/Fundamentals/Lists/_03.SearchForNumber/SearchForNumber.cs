using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SearchForNumber
{
    class SearchForNumber
    {
        static void Main()
        {
            var list = new List<int>(Console.ReadLine().Split(" ").Select(int.Parse));
            var tokens = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            var take = tokens[0];
            var delete = tokens[1];
            var search = tokens[2];
            
            var filtered = list.GetRange(0,take);
            filtered.RemoveRange(0,delete);
            Console.WriteLine(filtered.Contains(search)?"YES!":"NO!");
        }
    }
}