//  SoftUni
//  Course:     Advanced C#
//  Lecture:    Arrays, Lists, Stacks, Queues
//  Problem:    4.Sequences of Equal Strings
//              Write a program that reads an array of strings and finds in it all 
//              sequences of equal elements(comparison should be case-sensitive). 
//              The input strings are given as a single line, separated by a space.

//NOTE : Using functionality from C# v.6
//NOTE : Tried to not use any additional arrays or lists except the input array

using System.Linq;
using static System.Console;

namespace Problem4
{
    class P4
    {
        static void Main()
        {
            string[] input = ReadLine().Split(' ').ToArray();
            int currentIndex = 0;
            int offset = 1;

            while (true)
            {
                
                if (currentIndex + offset !=input.Length)
                {
                    if (input[currentIndex] == input [currentIndex+offset])
                    {
                         offset++;
                    }
                    else
                    {
                        for (int i = currentIndex; i < currentIndex+offset; i++)
                        {
                            Write(input[currentIndex] + " ");
                        }
                        WriteLine();
                        currentIndex = currentIndex + offset;
                        offset = 1;
                     }
                }
                else
                {
                    for (int i = currentIndex; i < input.Length; i++)
                    {
                        Write(input[currentIndex] + " ");
                    }
                    WriteLine();
                    break;
                }
            }
        }
    }
}
