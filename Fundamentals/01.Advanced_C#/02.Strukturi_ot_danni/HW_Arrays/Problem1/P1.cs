//  SoftUni
//  Course:     Advanced C#
//  Lecture:    Arrays, Lists, Stacks, Queues
//  Problem:    1.Sort Array of Numbers
//              Write a program to read an array of numbers from the console,
//              sort them and print them back on the console.The numbers should
//              be entered from the console on a single line, separated by a space. 


//NOTE : Based on the given example, lets assume the input numbers to be all integers
//NOTE : Using functionality from C# v.6

using System;
using System.Linq;
using static System.Console;

namespace Problem1
{
    class P1
    {
        static void Main(string[] args)
        {
            WriteLine("Enter integers separated by a single space: ");
            WriteLine(string.Join(" ", ReadLine()
                .Split(' ')
                .Select(n => Convert.ToInt32(n))
                .OrderBy(i => i)
                .Select(v => v.ToString())));
        }
    }
}
