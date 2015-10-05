//SoftUni
//Course:   Advanced C#
//Lecture:  Functional Programming
//Problems:  1. Student Class
//          Create a class Student with properties FirstName, LastName, Age, 
//          FacultyNumber, Phone, Email, Marks (IList<int>), GroupNumber. Create a List<Student> 
//          with sample students. These students will be used for the next few tasks.

using System;
using System.Collections.Generic;

namespace Student
{
    public class Student
    {
        private static Random rnd = new Random();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public IList<int> Marks { get; } = new List<int>();
        public int GroupNumber { get; set; }
        public static int FacultyNumberCounter { get; private set; } = 1;
        public int FacultyNumber { get; }
        

        public Student(string firstName, string lastName, int age, string phone, string email, int groupNumber )
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Phone = phone;
            Email = email;
            GroupNumber = groupNumber;
            FacultyNumber = 100000 * FacultyNumberCounter + rnd.Next(13,15) ;
            FacultyNumberCounter++;

        }

        public void PrintInfo()
        {
            Console.WriteLine($"{FirstName} {LastName} - No:{FacultyNumber}; group: {GroupNumber}; age:{Age}; phone:{Phone}; email: {Email};");
            Console.WriteLine("Grades :"+ String.Join(", ",Marks));
            Console.WriteLine();
        }
    }
}
