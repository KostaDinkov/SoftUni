//---------------------------------------------------
// SoftUni
// Course:      OOP
// Lecture:     Common Type System
// Problem:     3.String Disperser
// Description: Define a class StringDisperser. 
//              •	The constructor should take several strings as arguments.
//              •	Override the standard methods, inherited by System.Object: 
//                  Equals(), ToString(), GetHashCode() and operators == and !=.
//              •	Implement the ICloneable interface. The Clone() method should 
//                  make a deep copy of all object fields into a new object of type StringDisperser.
//              •	Implement the IComparable<StringDisperser> interface to compare string 
//                  dispersers by their total string value lexicographically.
//              •	Implement the IEnumerable interface to allow foreach on objects of type 
//                  StringDisperser.The items returned should be the characters of each string.
//
// Date:        Tuesday 12.2015 22:12 
//---------------------------------------------------

namespace _3.StringDisperser
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var stringDisperser = new StringDisperser("gosho", "pesho", "tanio");
            foreach (var ch in stringDisperser)
            {
                Console.Write(ch + " ");
            }
        }
    }
}