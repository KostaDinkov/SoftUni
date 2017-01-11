//---------------------------------------------------
// SoftUni											 
// Course:      Data Structures						 
// Lecture:     Linear Data Structures - Stacks and Queues	 
// Problem:     04.Longest Path In A Tree							 
// Description: You are given a tree holding N nodes. 
//              Each node holds a unique number. Each node can have child nodes. 
//              Find the longest path by sum of the nodes from leaf to leaf.						 
//													 
// Date:        Monday 03.2016 21:19 								 
//---------------------------------------------------


// NOTE: It is verry sloppy, but didnt have the time to polish it
// It Finds the longest path that includes the root
// If a longest path(sum) exists in a subtree I dont think it will work

namespace _04.LongestPathInATree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var tree = new Dictionary<int, TreeNode<int>>();

            var nodeCount = int.Parse(Console.ReadLine());
            var edgeCount = int.Parse(Console.ReadLine());

            // Building the tree
            for (var i = 0; i < edgeCount; i++)
            {
                var input = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

                var parentValue = input[0];
                var childValue = input[1];
                var childNode = new TreeNode<int>(childValue);
                if (tree.ContainsKey(childValue))
                {
                    childNode = tree[childValue];
                }
                else
                {
                    tree.Add(childValue, childNode);
                }

                if (tree.ContainsKey(parentValue))
                {
                    tree[parentValue].Children.Add(childNode);
                    childNode.Parent = tree[parentValue];
                }
                else
                {
                    var parentNode = new TreeNode<int>(parentValue);
                    parentNode.Children.Add(childNode);
                    childNode.Parent = parentNode;
                    tree.Add(parentValue, parentNode);
                }
            }


            var root = FindRoot(tree);

            // now we need to find the two longest paths from the root 
            // and sum them together
            var maxOne = 0;
            var maxTwo = 0;

            foreach (var treeNode in root.Children)
            {
                var maxSubTreeSum = 0;
                var currentSum = 0;
                FindMaxSum(treeNode, ref currentSum, ref maxSubTreeSum);
                if (maxSubTreeSum > maxOne)
                {
                    if (maxOne > maxTwo)
                    {
                        maxTwo = maxOne;
                    }
                    maxOne = maxSubTreeSum;
                }
                else if (maxSubTreeSum > maxTwo)
                {
                    maxTwo = maxSubTreeSum;
                }
            }

            var totalMaxPath = maxTwo + maxOne + root.Value;

            Console.WriteLine("Max sum path = " + totalMaxPath);
        }

        private static void FindMaxSum(TreeNode<int> treeNode, ref int currentSum, ref int maxSum)
        {
            currentSum += treeNode.Value;
            if (treeNode.Children.Count == 0)
            {
                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                }
                currentSum -= treeNode.Value;
                return;
            }
            foreach (var child in treeNode.Children)
            {
                FindMaxSum(child, ref currentSum, ref maxSum);
            }
        }

        private static TreeNode<int> FindRoot(Dictionary<int, TreeNode<int>> tree)
        {
            foreach (var node in tree)
            {
                if (node.Value.Parent == null)
                {
                    return node.Value;
                }
            }
            return null;
        }
    }

    internal class TreeNode<T>
    {
        public TreeNode(T value)
        {
            this.Value = value;
            this.Children = new List<TreeNode<T>>();
        }

        public T Value { get; set; }
        public List<TreeNode<T>> Children { get; set; }

        public TreeNode<T> Parent { get; set; }
    }
}