//---------------------------------------------------
// SoftUni											 
// Course:      Data Structures						 
// Lecture:     Linear Data Structures - Stacks and Queues	 
// Problem:     01.Find The Root							 
// Description: You have a connected directed graph with N nodes and M edges. 
//              You are given the directed edges from one node to another. 
//              The nodes are numbered from 0 to N-1 inclusive. Check whether 
//              the graph is a tree and find its root.						 
//													 
// Date:        Friday 03.2016 21:11 								 
//---------------------------------------------------


// NOTE: By definition a tree is any undirected, acyclic and connected graph, 
// so the fourth exapmle in the homework is wrong - 0 and 6 are not roots, because the graph that
// contains them is not a tree (the author treats it as a "directed" tree, and there is no such thing).
// For the rest of the cases I will assume that the graps are not directed

// NOTE: After I finished this problem, I checked the hint solution which is quite simpler ... well, zdrave da e ;)

namespace _01.FindTheRoot
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static int[][] graph;
        private static int nodes;
        private static int edges;

        private static void Main(string[] args)
        {
            nodes = int.Parse(Console.ReadLine());
            edges = int.Parse(Console.ReadLine());
            graph = GetGraphFromInput();

            if (IsGraphTree(graph))
            {
                //we know the graph is a tree so the root is just one
                var root = FindRoots(graph).First();
                Console.WriteLine(root);
            }
            else
            {
                var roots = FindRoots(graph);

                //if there are multiple roots
                if (roots.Count > 1)
                {
                    Console.WriteLine("Multiple roots!");
                }
                else if (roots.Count == 0)
                {
                    Console.WriteLine("No Roots");
                }
            }
        }

        private static int[][] GetGraphFromInput()
        {
            var graph = new int[edges][];
            for (var i = 0; i < edges; i++)
            {
                graph[i] = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            }
            return graph;
        }

        private static HashSet<int> FindRoots(int[][] graph)
        {
            var childs = new HashSet<int>();

            //we add all child nodes in a set

            foreach (var edge in graph)
            {
                childs.Add(edge[1]);
            }

            var roots = new HashSet<int>();

            //the ones that are not in childs must be roots
            for (var root = 0; root < nodes; root++)
            {
                if (!childs.Contains(root))
                {
                    roots.Add(root);
                }
            }
            return roots;
        }

        private static bool IsGraphTree(int[][] graph)
        {
            // if the edges are not one less than the nodes
            // then the graph is not a tree 
            if (edges != nodes - 1)
            {
                return false;
            }
            var childs = new HashSet<int>();

            // checking if the graph has cycles or
            // in the case of a directed graph,
            // if a node has two or more parents

            foreach (var edge in graph)
            {
                var child = edge[1];

                if (childs.Contains(child))
                {
                    return false;
                }
                childs.Add(child);
            }
            return true;
        }
    }
}