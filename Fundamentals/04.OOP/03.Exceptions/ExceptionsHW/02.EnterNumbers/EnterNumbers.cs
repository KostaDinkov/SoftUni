/*
** SoftUni
** Course:		OOP
** Lecture:		Exception Handling
** Problem:		2.EnterNumbers
** Description:	Write a method ReadNumber(int start, int end) that enters an integer number 
**              in given range [start…end]. If an invalid number or non-number text is entered, the method 
**              should throw an exception. Using this method write a program that enters 10 numbers: 
**              a1, a2, … a10, such that 1 < a1 < … < a10 < 100. If the user enters an invalid number, 
**              let the user to enter again.
** 	
** Date:		Tuesday 11.2015 13:54 
*/


using System;
using System.Collections.Generic;

namespace _02.EnterNumbers
{
    internal class EnterNumbers
    {
        private static void Main(string[] args)
        {
            var numbers = new List<int>();

            for (var i = 0; i < 10; i++)
            {
                AddNumberToList(numbers, 1, 100);
            }
            // print the numbers
            Console.WriteLine(string.Join(", ", numbers));
        }

        private static int ReadNumber(int start, int end)
        {
            var inputNumber = int.Parse(Console.ReadLine());
            if (inputNumber < start || inputNumber > end)
            {
                throw new ArgumentOutOfRangeException();
            }
            return inputNumber;
            //Note: the ArgumentNullException, FormatException and OverflowExceptions 
            //are thrown by the Parse method
            //so I will not catch and re-throw them.
        }

        /// <summary>
        ///     Adds a 32 bit integer to a list if the input is in the range start:end
        ///     and the input is larger than the last entered number in the list
        /// </summary>
        /// <param name="list">The list to add the number to</param>
        /// <param name="start">Range low margin</param>
        /// <param name="end">Range high margin</param>
        private static void AddNumberToList(List<int> list, int start, int end)
        {
            int number;
            int lastInput;
            if (list.Count == 0)
            {
                lastInput = int.MinValue;
            }
            else
            {
                lastInput = list[list.Count - 1];
            }
            try
            {
                number = ReadNumber(1, 100);
                
                //check if the input is greater than the last input
                if (number <= lastInput)
                {
                    do
                    {
                        Console.WriteLine($"The input must be greater than {lastInput}!");
                        number = ReadNumber(1, 100);
                    } while (number <= lastInput);
                }
                list.Add(number);
            }

            catch (ArgumentNullException)
            {
                Console.WriteLine("Invalid input. Try again!");
                AddNumberToList(list, 1, 100);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Invalid input. Try again!");
                AddNumberToList(list, 1, 100);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Try again!");
                AddNumberToList(list, 1, 100);
            }
            catch (OverflowException)
            {
                Console.WriteLine("Invalid input. Try again!");
                AddNumberToList(list, 1, 100);
            }
        }
    }
}