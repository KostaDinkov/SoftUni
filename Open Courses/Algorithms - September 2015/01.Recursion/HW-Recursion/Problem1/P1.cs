//  SoftUni
//  Course:     Algorithms
//  Lecture:    Recursion
//  Problem:    1. Tower of Hanoi
//              Your task is to solve the famous Tower of Hanoi puzzle using recursion. 
//              In this problem, you have three rods (let’s call them source, destination and spare). 
//              Initially, there are n disks, all placed on the source rod .
//              Your objective is to move all disks from the source rod to the destination rod. 
//              There are several rules:
//                  1)	Only one disk can be moved at a time
//                  2)	Only the topmost disk on a rod can be moved
//                  3)	A disk can only be placed on top of a larger disk or on an empty rod

using System;
using System.Collections.Generic;
using System.Linq;


namespace Problem1
{
    class P1
    {
        
        private static int stepsTaken = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("TOWER OF HANOI\nEnter disk count:");

            int diskCount = int.Parse(Console.ReadLine());
            Stack<int> source = new Stack<int>(Enumerable.Range(1,diskCount).Reverse());
            Stack<int> destination = new Stack<int>();
            Stack<int> spare = new Stack<int>();
            
            MoveDisks(diskCount, source, destination, spare);
            Console.WriteLine($"Steps taken to solve Towers of Hanoi:{stepsTaken}");
           
        }

        static void MoveDisks(int bottomDisk, Stack<int> source, Stack<int> destination, Stack<int> spare)
        {
            stepsTaken++;
            if (bottomDisk ==1)
            {
                destination.Push(source.Pop());
            }
            else
            {
                MoveDisks(bottomDisk-1,source,spare,destination);
                destination.Push(source.Pop());
                MoveDisks(bottomDisk-1, spare, destination, source);
            }
        }
    }
}
