//---------------------------------------------------
// SoftUni
// Course:      OOP
// Lecture:     Delegates And Events
// Problem:     4.Student Class
// Description: Write a class Student that holds name and age. Add an event 
//              PropertyChanged that should fire whenever a property of Student is changed, 
//              displaying a message in the format Property changed: <property> (from <old 
//              value> to <new value>). Create a custom PropertyChangedEventArgs class 
//              to keep the property name, old value and new value. 
//
// Date:        Friday 12.2015 22:55 
//---------------------------------------------------

namespace _4.StudentClass
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var student = new Student("Petar", 22);
            student.PropertyChanged += (sender, eventArgs) =>
            {
                Console.WriteLine("Property changed: {0} (from {1} to {2})",
                    eventArgs.PropertyName, eventArgs.OldValue, eventArgs.NewValue);
            };
            student.Name = "Maria";
            student.Age = 19;
        }
    }
}