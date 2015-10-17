//This template is used for the SoftUni Exams
//It redirects from getting user input from the console to getting the input from a input.txt file
//NOTE: comment the 2 lines that have "//COMMNET THIS LINE" comments at the end, 
//to enable user input from the Console instead from the text file
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;

namespace P1
{
    class Program
    {
        static void Main()
        {
            string filePath = "../../input.txt";
            using (var reader = new StreamReader(filePath)) //COMMNET THIS LINE
            {
                Console.SetIn(reader);//COMMNET THIS LINE

                //New Code Starts Here
                int[] arr = Console.ReadLine().Split(' ').Select(n => int.Parse(n)).ToArray();
                string line = Console.ReadLine();
                while (line!="end")
                {
                    string[] lineArgs = line.Split(' ').ToArray();
                    ProcessCommand(arr, lineArgs);
                    line = Console.ReadLine();

                }
                Console.WriteLine("[" + string.Join(", ",arr)+"]");

            }
        }

        private static void ProcessCommand(int[] arr, string[] lineArgs)
        {
            string command = lineArgs[0];
            string type = "";
            BigInteger count = BigInteger.Zero;
            switch (command)
            {
                    
                case "exchange":
                    BigInteger index = BigInteger.Parse(lineArgs[1]);
                    int[] exchanged = SplitArr(arr, index);
                    exchanged.CopyTo(arr,0);
                    
                    break;
                case "min":
                    type = lineArgs[1];
                    GetMin(arr, type);
                    break;
                case "max":
                    type = lineArgs[1];
                    GetMax(arr,type);
                    break;
                case "first":
                    count = BigInteger.Parse(lineArgs[1]);
                    type = lineArgs[2];
                    GetFirst(arr, count, type);
                    break;
                case "last":
                    count = BigInteger.Parse(lineArgs[1]);
                    type = lineArgs[2];
                    GetLast(arr, count, type);
                    break;
            }
        }

        private static void GetLast(int[] arr, BigInteger count, string type)
        {
            if (count > arr.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            if (type == "odd")
            {
                var reversed = arr.Reverse();
                var firstNOdd = reversed.Where(n => n % 2 != 0).Take((int)count);
                firstNOdd = firstNOdd.Reverse();
                Console.WriteLine("[" + string.Join(", ", firstNOdd) + "]");
            }
            else
            {
                var reversed = arr.Reverse();
                var firstNEven = reversed.Where(n => n % 2 == 0).Take((int)count);
                firstNEven = firstNEven.Reverse();
                Console.WriteLine("[" + string.Join(", ", firstNEven) + "]");

            }
        }

        private static void GetFirst(int[] arr, BigInteger count, string type)
        {
            if (count>arr.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            if (type == "odd")
            {
                try
                {
                    var firstNOdd = arr.Where(n => n % 2 != 0).Take((int)count);
                    Console.WriteLine("[" + string.Join(", ", firstNOdd) + "]");
                }
                catch (InvalidOperationException)
                {

                    Console.WriteLine("[]");
                }
            }
            else
            {
                try
                {
                    var firstNEven = arr.Where(n => n % 2 == 0).Take((int)count);
                    Console.WriteLine("[" + string.Join(", ", firstNEven) + "]");
                }
                catch (InvalidOperationException)
                {

                    Console.WriteLine("[]");
                    
                }

            }
        }

        private static void GetMin(int[] arr, string type)
        {
            if (type == "odd")
            {
                try
                {
                    int minOdd = arr.Where(n => n % 2 != 0).Min();
                    Console.WriteLine(Array.LastIndexOf(arr,minOdd));
                }
                catch (InvalidOperationException)
                {

                    Console.WriteLine("No matches");
                }

            }
            else
            {
                try
                {
                    int minEven = arr.Where(n => n % 2 == 0).Min();
                    Console.WriteLine(Array.LastIndexOf(arr,minEven));
                }
                catch (InvalidOperationException)
                {

                    Console.WriteLine("No matches");
                }
            }
        }

        private static void GetMax(int[] arr, string type)
        {
            if (type =="odd")
            {
                try
                {
                    int maxOdd = arr.Where(n => n % 2 != 0).Max();
                    Console.WriteLine(Array.LastIndexOf(arr, maxOdd));
                }
                catch (InvalidOperationException)
                {

                    Console.WriteLine("No matches");
                }
                
            }
            else
            {
                try
                {
                    int maxEven = arr.Where(n => n % 2 == 0).Max();
                    Console.WriteLine(Array.LastIndexOf(arr, maxEven));
                }
                catch (InvalidOperationException)
                {

                    Console.WriteLine("No matches");
                }
            }
            
        }

        private static int[] SplitArr(int[] arr, BigInteger index)
        {
            if (index>=arr.Length || index<-0)
            {
                Console.WriteLine("Invalid index");
                return arr;
            }

            int []first = arr.Take((int)index+1).ToArray();
            int []second = arr.Skip((int)index+1).ToArray();
            int[] exchanged = new int[arr.Length];
            Array.Copy(second, exchanged, second.Length);
            Array.Copy(first, 0, exchanged, second.Length, first.Length);
            return exchanged;
        }
    }
}
