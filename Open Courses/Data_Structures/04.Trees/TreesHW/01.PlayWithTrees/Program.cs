//---------------------------------------------------
// SoftUni											 
// Course:      Data Structures						 
// Lecture:     Linear Data Structures - Stacks and Queues	 
// Problem:     01.Play With Trees							 
// Description: ...						 
//													 
// Date:        Monday 02.2016 19:28 								 
//---------------------------------------------------
namespace _01.PlayWithTrees
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    internal class Program
    {
        private static readonly Dictionary<int, Tree<int>> nodeByValue =
            new Dictionary<int, Tree<int>>();

        private static void Main(string[] args)
        {
            // Note: For easier debugging and testing, 
            // I have redirected the input from the console to a file - "input.txt".
            // Feel free to change the values in the file to test new cases.
            var sr = new StreamReader("input.txt");
            Console.SetIn(sr);

            var nodesCount = int.Parse(Console.ReadLine());

            for (var i = 1; i < nodesCount; i++)
            {
                var edge = Console.ReadLine().Split(' ');
                var parentValue = int.Parse(edge[0]);
                var parentNode = GetTreeNodeByValue(parentValue);
                var childValue = int.Parse(edge[1]);
                var childNode = GetTreeNodeByValue(childValue);
                parentNode.Children.Add(childNode);
                childNode.Parent = parentNode;
            }

            var pathSum = int.Parse(Console.ReadLine());
            var subTreeSum = int.Parse(Console.ReadLine());

            //Print Root Node
            var rootNode = GetRootNode();
            Console.WriteLine($"Root node: {rootNode.Value}");

            //Print Leaf Nodes
            var leafNodes = GetLeafNodes();
            Console.WriteLine($"Leaf nodes: {string.Join(", ", leafNodes.Select(n => n.Value))}");

            //Print Middle Nodes
            var middleNodes = GetMiddleNodes();
            Console.WriteLine($"Middle nodes: {string.Join(", ", middleNodes.Select(n => n.Value))}");

            //Print Longest Path
            var longestPath = new List<Tree<int>>();
            FindLongestPath(rootNode, ref longestPath, new Stack<Tree<int>>());
            Console.WriteLine(
                $"Longest path: {string.Join(", ", longestPath.Select(n => n.Value).Reverse())}");

            //Print paths with specified sum
            var pathsWithSum = new List<Stack<Tree<int>>>();
            var pathStack = new Stack<Tree<int>>();
            GetPathsWithSum(rootNode, 0, pathSum, ref pathStack, ref pathsWithSum);

            Console.WriteLine($"Paths with sum:{pathSum}");
            foreach (var path in pathsWithSum)
            {
                Console.WriteLine(string.Join(" -> ", path.Select(n => n.Value)));
            }

            // Print subtrees with specified sum
            // Note: Assuming that a subtree consists of a parent node and ALL its descendants
            var subTreesWithSum = new List<Tree<int>>();
            GetSubTreesWithSum(rootNode, subTreeSum, 0, ref subTreesWithSum);
            Console.WriteLine($"Subtrees with sum {subTreeSum}: {string.Join(", ",subTreesWithSum.Select(n =>n.Value))}");

            sr.Close();
        }

        private static void GetSubTreesWithSum(Tree<int> root,int targetSum, int currentSum, ref List<Tree<int>> subTreesWithSum)
        {
            currentSum = GetSumFromNodeSubtree(root, currentSum);
            if (currentSum == targetSum)
            {
                subTreesWithSum.Add(root);
            }
            foreach (var child in root.Children)
            {
                GetSubTreesWithSum(child,targetSum,0,ref subTreesWithSum);
            }


        }

        private static int GetSumFromNodeSubtree(Tree<int> root, int currentSum)
        {
            currentSum += root.Value;
            foreach (var child in root.Children)
            {
                currentSum = GetSumFromNodeSubtree(child, currentSum);
            }
            return currentSum;
            
        }

        private static void GetPathsWithSum(Tree<int> root, int currentSum, int targetSum,
            ref Stack<Tree<int>> currentPath, ref List<Stack<Tree<int>>> resultList)
        {
            currentPath.Push(root);
            currentSum = currentSum + root.Value;

            if (currentSum == targetSum)
            {
                resultList.Add(new Stack<Tree<int>>(currentPath));
            }

            foreach (var child in root.Children)
            {
                GetPathsWithSum(child, currentSum, targetSum, ref currentPath, ref resultList);
            }
            currentPath.Pop();
        }

        private static Tree<int> GetRootNode()
        {
            var rootNode = nodeByValue.Values.FirstOrDefault(n => n.Parent == null);
            return rootNode;
        }

        private static List<Tree<int>> GetMiddleNodes()
        {
            var middleNodes =
                nodeByValue.Values.Where(n => (n.Parent != null) && (n.Children.Count > 0)).
                    OrderBy(n => n.Value).
                    ToList();
            return middleNodes;
        }

        private static List<Tree<int>> GetLeafNodes()
        {
            var leafNodes =
                nodeByValue.Values.Where(n => n.Children.Count == 0).OrderBy(n => n.Value).ToList();
            return leafNodes;
        }

        private static Tree<int> GetTreeNodeByValue(int value)
        {
            if (!nodeByValue.ContainsKey(value))
            {
                nodeByValue[value] = new Tree<int>(value);
            }
            return nodeByValue[value];
        }

        private static void FindLongestPath(Tree<int> root, ref List<Tree<int>> longestPath,
            Stack<Tree<int>> currentPath)
        {
            currentPath.Push(root);

            //Console.WriteLine($"Current Path: {string.Join(", ", currentPath.Select(n => n.Value))}");
            if (root.Children.Count == 0)
            {
                if (currentPath.Count > longestPath.Count)
                {
                    longestPath = currentPath.ToList();
                }
                currentPath.Pop();
                return;
            }
            foreach (var child in root.Children)
            {
                FindLongestPath(child, ref longestPath, currentPath);
            }
            currentPath.Pop();
        }
    }
}