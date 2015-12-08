//---------------------------------------------------
// SoftUni
// Course:      OOP
// Lecture:     Delegates And Events
// Problem:     3.Asynchronous Timer
// Description: Create a class AsyncTimer that executes a given method each t seconds.
//              •	The constructor should accept 3 arguments: Action(a method to be called 
//                  on every t milliseconds), ticks(the number of times the method should 
//                  be called) and t(time interval between each tick in milliseconds).
//              •	The main program's execution should NOT be paused at any time 
//                  (use some kind of background execution).
//              
// Date:        Friday 12.2015 21:30 
//---------------------------------------------------
namespace _3.AsynchronousTimer
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            
            var timer = new AsyncTimer(3000, 3, () => Console.WriteLine("Timer elapsed!"));
            var secondTimer = new AsyncTimer(1000, 10, () => Console.WriteLine("Second timer elapsed!"));

            timer.Start();
            secondTimer.Start();

            //the program will exit after a key is pressed
            Console.ReadKey();
        }
    }
}