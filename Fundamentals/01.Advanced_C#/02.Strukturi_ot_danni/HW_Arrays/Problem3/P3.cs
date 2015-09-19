//  SoftUni
//  Course:     Advanced C#
//  Lecture:    Arrays, Lists, Stacks, Queues
//  Problem:    3.Categorize Numbers and Find Min / Max / Average
//              Write a program that reads N floating-point numbers 
//              from the console. Your task is to separate them in two sets, one containing
//              only the round numbers (e.g. 1, 1.00, etc.) and the other containing the 
//              floating-point numbers with non-zero fraction. Print both arrays along with 
//              their minimum, maximum, sum and average (rounded to two decimal places).  

//NOTE : Using functionality from C# v.6
using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace Problem3
{
    class P3
    {
        static void Main(string[] args)
        {

            WriteLine("Enter numbers separated by a single space: ");
            double[] inputArr = ReadLine().Split(' ').Select(Convert.ToDouble).ToArray();

            List<double> floats = new List<double>();
            List<double> ints = new List<double>();

            for (int i = 0; i < inputArr.Length; i++)
            {
                if (inputArr[i] == Math.Floor(inputArr[i]))
                {
                    ints.Add(Convert.ToInt32(inputArr[i]));
                }
                else
                {
                    floats.Add(inputArr[i]);
                }
            }

            PrintResults(ints);
            PrintResults(floats);
        }

        static void PrintResults(List<double> inputsList)
        {
            string arr = string.Join(", ", inputsList.Select(i => i.ToString()));
            double min = inputsList.Min();
            double max = inputsList.Max();
            double sum = inputsList.Sum(i => Convert.ToDouble(i));
            double avg = inputsList.Average(i => Convert.ToDouble(i));

            WriteLine($"[{arr}] -> min: {min}, max: {max}, sum: {sum}, avg: {avg:f2}");
        }
    }
    
}
