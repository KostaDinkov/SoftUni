//  SoftUni
//  Course:     Advanced C#
//  Lecture:    Arrays, Lists, Stacks, Queues
//  Problem:    2.Sort Array of Numbers Using Selection Sort
//              Write a program to sort an array of numbers and then print them 
//              back on the console.The numbers should be entered from the 
//              console on a single line, separated by a space.Refer to the 
//              examples for problem 1.
//              Note: Do not use the built-in sorting method, you should write 
//              your own.Use the selection sort algorithm. 

//NOTE : Using functionality from C# v.6

using System;
using System.Linq;
using static System.Console;

namespace Problem2
{
    class P2
    {
        static void Main(string[] args)
        {
            //getting the input
            WriteLine("Enter integers separated by a single space: ");
            int[] inputArr = ReadLine().Split(' ').Select(v => Convert.ToInt32(v)).ToArray();

            //Selection Sort
            int i, j, minIndex, tmp;
            
            //Repeat (number of elements - 1) times
            for ( i = 0; i < inputArr.Length-1; i++)
            {
                //set the first unsorted element as the minimum 
                minIndex = i;
                //for each of the unsorted elements
                for (j = i+1; j < inputArr.Length; j++)
                {
                    //check if the element is smaller than the  current minimum
                    if (inputArr[j]<inputArr[minIndex])
                    {
                        //and if true, set the element as the new minimum
                        minIndex = j;
                    }
                }
                //swap minimum with first unsorted position
                tmp = inputArr[i];// using a temporary variable to store the value of the first unsorted element
                inputArr[i] = inputArr[minIndex]; // this becomes sorted number and the sorting loop continues with the i+1 index
                inputArr[minIndex] = tmp;
            }

            //print the result
            WriteLine(string.Join(" ", inputArr.Select(n => n.ToString())));

        }

        
    }
}
