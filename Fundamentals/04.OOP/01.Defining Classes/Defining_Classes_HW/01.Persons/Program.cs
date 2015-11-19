/*
// SoftUni
// Course:		OOP
// Lecture:		1. Defining Classes
// Problem:		01.Person
// Description:	Define a class Person that has name, age and email. The name and age are
//              mandatory. The email is optional. Define properties that accept non-empty name and age in the
//              range [1 ... 100]. In case of invalid arguments, throw an exception. 
//              Define a property for the email that accepts either null or non-empty 
//              string containing '@'. Define two constructors. The first constructor 
//              should take name, age and email. The second constructor should take name 
//              and age only and call the first constructor. Implement the ToString() 
//              method to enable printing persons at the console.
//		
// Date:		Monday 11.2015 22:30 h.
*/

using System;

namespace _01.Persons
{
    internal class Program
    {
        private static void Main()
        {
            Person stamat = new Person("Stamat", 86);
            Console.WriteLine(stamat);
        }
    }
}