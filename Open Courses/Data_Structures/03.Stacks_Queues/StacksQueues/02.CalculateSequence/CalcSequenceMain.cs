//---------------------------------------------------
// SoftUni											 
// Course:      Data Structures						 
// Lecture:     Linear Data Structures - Stacks and Queues	 
// Problem:     02.Calculate Sequence with a Queue							 
// Description: We are given the following sequence of numbers:
//              •	S1 = N
//              •	S2 = S1 + 1
//              •	S3 = 2* S1 + 1
//              •	S4 = S1 + 2
//              •	S5 = S2 + 1
//              •	S6 = 2* S2 + 1
//              •	S7 = S2 + 2
//              •	…
//              Using the Queue<T> class, write a program to print its first 50 members for given N.					 
//													 
// Date:        Friday 02.2016 10:58 								 
//---------------------------------------------------

namespace _02.CalculateSequence
{
    using System;
    using System.Collections.Generic;

    internal class CalcSequenceMain
    {
        private static void Main(string[] args)
        {
            const int sequenceLength = 50;
            var startValue = int.Parse(Console.ReadLine());

            // This should work with any standard numeric type 
            // (int, long, float, double, decimal, etc...) for startValue.
            var sequence = CalculateSequence(sequenceLength, startValue);
            Console.WriteLine(string.Join(", ", sequence));
        }

        private static List<T> CalculateSequence<T>(int sequenceLength, T startValue)
        {
            // Note: using a list to store all the calculated 
            // values instead of just printing them to the console
            var result = new List<T>();
            var workingSequence = new Queue<T>();

            workingSequence.Enqueue(startValue);
            result.Add(startValue);
            for (var i = 1; i < sequenceLength; i++)
            {
                var baseValue = workingSequence.Peek();
                if (i%3 == 1)
                {
                    var calculatedValue = (dynamic) baseValue + 1;
                    workingSequence.Enqueue(calculatedValue);
                    result.Add(calculatedValue);
                }
                else if (i%3 == 2)
                {
                    var calculatedValue = (dynamic) baseValue*2 + 1;
                    workingSequence.Enqueue(calculatedValue);
                    result.Add(calculatedValue);
                }
                else if (i%3 == 0)
                {
                    var calculatedValue = (dynamic) baseValue + 2;
                    workingSequence.Enqueue(calculatedValue);
                    result.Add(calculatedValue);

                    //we have done all  types of calculations, 
                    //so we dequeue and the next time the loop executes
                    //the baseValue will be set to the one at the start of the queue
                    workingSequence.Dequeue();
                }
            }
            return result;
        }
    }
}