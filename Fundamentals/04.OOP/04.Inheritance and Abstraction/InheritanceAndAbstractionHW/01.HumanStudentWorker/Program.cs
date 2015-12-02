/*
** SoftUni
** Course:		OOP
** Lecture:		Inheritance and Abstraction
** Problem:		1.Human Student and Worker
** Description:	...
** 	
** Date:		Wednesday 11.2015 19:15 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using RandomNameGenerator;

namespace _01.HumanStudentWorker
{
    internal class Program
    {
        private const int StudentCount = 10;
        private const int WorkerCount = 10;
        private static Random rnd = new Random();

        private static void Main()
        {
            // generate a list of students
            List<Student> students = new List<Student>();
            for (int i = 0; i < StudentCount; i++)
            {
                Gender gender = (Gender) rnd.Next(0, 2);
                string firstName = NameGenerator.GenerateFirstName(gender);
                string lastName = NameGenerator.GenerateLastName();
                students.Add(new Student(firstName, lastName));
            }
            // generate a list of workers
            List<Worker> workers = new List<Worker>();
            for (int i = 0; i < WorkerCount; i++)
            {
                Gender gender = (Gender) rnd.Next(0, 2);
                string firstName = NameGenerator.GenerateFirstName(gender);
                string lastName = NameGenerator.GenerateLastName();
                double weekSalary = rnd.Next(1000, 2001);
                double workHoursPerDay = rnd.Next(2, 12);

                workers.Add(new Worker(firstName, lastName, weekSalary, workHoursPerDay));
            }

            //sort students and print them
            students = students.OrderBy(n => n.FacultyNo).ToList();
            Console.WriteLine("Students:\n" + string.Join("\n", students));

            //sort workers and print them
            workers = workers.OrderByDescending(n => n.MoneyPerHour()).ToList();
            Console.WriteLine("Workers:\n" + string.Join("\n", workers));

            // merge, sort and print
            List<Human> merged =
                students.Concat<Human>(workers).OrderBy(n => n.FirstName).ThenBy(n => n.LastName).ToList();
            Console.WriteLine("All humans:");
            foreach (var human in merged)
            {
                Console.WriteLine($"{human.FirstName} {human.LastName}");
            }
        }
    }
}