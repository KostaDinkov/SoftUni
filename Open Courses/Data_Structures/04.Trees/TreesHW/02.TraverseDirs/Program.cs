//---------------------------------------------------
// SoftUni											 
// Course:      Data Structures						 
// Lecture:     Linear Data Structures - Stacks and Queues	 
// Problem:     02.Traverse Dirs							 
// Description: Write a program to build a tree keeping all files and folders from the 
//              hard drive starting from C:\WINDOWS. You may use the .NET directory listing APIs: 
//              DirectoryInfo.GetFiles() and DirectoryInfo.GetDirectories().
//              Implement a method that calculates the sum of the file sizes in given subtree of 
//              the tree and test it accordingly.Use recursive tree traversal.

//													 
// Date:        Tuesday 03.2016 13:28 								 
//---------------------------------------------------
namespace _02.TraverseDirs
{
    using System;
    using System.IO;
    using System.Linq;
    using _01.PlayWithTrees;

    internal class Program
    {
        private static void Main(string[] args)
        {
            // NOTE: I have made a test directory in the solution folder - ROOT.
            // You can change the path to your liking.
            // Each file in the test directory is of size 20 bytes.
            // Also there is little or no use for classes File and Folder, so I have not implemented them

            var path = "../../ROOT";
            var root = new DirectoryInfo(path);
            var dirTree = new Tree<DirectoryInfo>(root);

            // Build a directory tree with the dirTree as root directory
            BuildTree(dirTree);

            PrintTree(dirTree, 0);
            Console.WriteLine(
                $"Sum of file sizes in {dirTree.Value.Name} = {SumFileSizes(dirTree)} bytes");

            // Get the sum from a subtree
            var subTree = dirTree.Children[0];
            Console.WriteLine(
                $"Sum of file sizes in {subTree.Value.Name} = {SumFileSizes(subTree)} bytes");
        }

        private static void PrintTree(Tree<DirectoryInfo> tree, int indent)
        {
            Console.WriteLine(new string(' ', 2*indent) + tree.Value.Name);
            indent += 1;
            foreach (var file in tree.Value.GetFiles())
            {
                Console.WriteLine(new string(' ', 2*indent) + file.Name);
            }
            foreach (var child in tree.Children)
            {
                PrintTree(child, indent);
            }
        }

        private static long SumFileSizes(Tree<DirectoryInfo> tree)
        {
            var localSum = tree.Value.GetFiles().Sum(file => file.Length);

            foreach (var child in tree.Children)
            {
                localSum += SumFileSizes(child);
            }
            return localSum;
        }

        private static void BuildTree(Tree<DirectoryInfo> rootNode)
        {
            var dirs = rootNode.Value.GetDirectories();
            foreach (var directoryInfo in dirs)
            {
                rootNode.Children.Add(new Tree<DirectoryInfo>(directoryInfo));
            }

            foreach (var child in rootNode.Children)
            {
                BuildTree(child);
            }
        }
    }
}