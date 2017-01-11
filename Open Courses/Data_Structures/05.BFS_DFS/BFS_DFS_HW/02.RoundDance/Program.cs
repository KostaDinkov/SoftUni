//---------------------------------------------------
// SoftUni											 
// Course:      Data Structures						 
// Lecture:     Linear Data Structures - Stacks and Queues	 
// Problem:     02.Round Dance							 
// Description: ...						 
//													 
// Date:        Friday 03.2016 23:22 								 
//---------------------------------------------------
namespace _02.RoundDance
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static int maxLen;
        private static readonly HashSet<int> visited = new HashSet<int>();

        private static void Main(string[] args)
        {
            var edges = int.Parse(Console.ReadLine());
            var startNodeValue = int.Parse(Console.ReadLine());
            var graph = GetGraph(edges);

            GetLongestPath(graph, startNodeValue, 0);

            Console.WriteLine(maxLen);
        }

        private static void GetLongestPath(Dictionary<int, List<int>> graph, int startNodeValue,
            int currentLen)
        {
            if (visited.Contains(startNodeValue))
            {
                return;
            }
            currentLen += 1;
            visited.Add(startNodeValue);
            if (currentLen > maxLen)
            {
                maxLen = currentLen;
            }

            foreach (var neighbour in graph[startNodeValue])
            {
                GetLongestPath(graph, neighbour, currentLen);
            }
            currentLen--;
        }

        private static Dictionary<int, List<int>> GetGraph(int edges)
        {
            var graph = new Dictionary<int, List<int>>();
            for (var i = 0; i < edges; i++)
            {
                var edge = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var first = edge[0];
                var second = edge[1];
                if (graph.ContainsKey(first))
                {
                    graph[first].Add(second);
                }
                else
                {
                    graph.Add(first, new List<int> {second});
                }
                if (!graph.ContainsKey(second))
                {
                    graph.Add(second, new List<int> {first});
                }
                else
                {
                    graph[second].Add(first);
                }
            }
            return graph;
        }
    }
}