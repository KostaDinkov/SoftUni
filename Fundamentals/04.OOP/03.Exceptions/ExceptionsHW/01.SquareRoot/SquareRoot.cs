/*
** SoftUni
** Course:		OOP
** Lecture:		Exception Handling
** Problem:		1.SquareRoot
** Description:	Write a program that reads an integer number and calculates and prints 
**              its square root. If the number is invalid or negative, print "Invalid number". 
**              In all cases finally print "Good bye". Use try-catch-finally.
** 	
** Date:		Tuesday 11.2015 13:39 
*/
using System;

namespace _01.SquareRoot
{
    class SquareRoot
    {
        static void Main()
        {
            uint input;
            try
            {
                Console.WriteLine("Enter a positive  32 bit integer:");
                input = uint.Parse(Console.ReadLine());
                Console.WriteLine($"The square root of {input} is: {Math.Sqrt(input)} ");
            }
            catch (ArgumentNullException)
            {
                PrintError();

            }
            catch (FormatException)
            {
                PrintError();
            }
            catch (OverflowException)
            {
                PrintError();
            }
            finally
            {
                Console.WriteLine("Good Bye!");
            }
        }

        static void PrintError()
        {
            Console.WriteLine("Invalid number");
        }
    }
}
