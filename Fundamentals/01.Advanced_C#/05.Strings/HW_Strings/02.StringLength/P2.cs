//  SoftUni
//  Course:     Advanced C#
//  Lecture:    Strings
//  Problem:    2. String Length
//              Write a program that reads from the console a string of maximum 20 
//              characters.If the length of the string is less than 20, the 
//              rest of the characters should be filled with*. Print the resulting 
//              string on the console.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _02.StringLength
{
    class P2
    {
        static void Main()
        {
            string input = Console.ReadLine();
            if (input.Length < 20)
            {
                string adjusted = input.PadRight(20, '*');
                Console.WriteLine(adjusted);
            }
            else
            {
                string adjusted = input.Substring(0, 20);
                Console.WriteLine(adjusted);
            }
        }
    }
}
