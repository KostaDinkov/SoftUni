//  SoftUni
//  Course:     Advanced C#
//  Lecture:    Methods
//  Problem:    7.Generic Array Sort
//              Write a method which takes an array of any type and sorts it. 
//              Use bubble sort or selection sort (your own implementation). 
//              you may re-use your code from a previous homework and modify it. 
//              Use a generic method(read in Internet about generic methods in C#). 
//              Make sure that what you're trying to sort can be sorted – your method 
//              should work with numbers, strings, dates, etc., but not necessarily with 
//              custom classes like Student.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem7
{
    class P7
    {
        static void Main(string[] args)
        {
        }

        static void SelectionSort<T>(T[] inputArr)
        {
            Array.Sort(inputArr);
            //Selection Sort
            int i, j, minIndex, tmp;

            //Repeat (number of elements - 1) times
            for (i = 0; i < inputArr.Length - 1; i++)
            {
                //set the first unsorted element as the minimum 
                minIndex = i;
                //for each of the unsorted elements
                for (j = i + 1; j < inputArr.Length; j++)
                {
                    //check if the element is smaller than the  current minimum
                    if (inputArr[j].CompareTo() inputArr[minIndex])
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
        }
    }
}
