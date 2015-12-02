//---------------------------------------------------
// SoftUni
// Course:      OOP
// Lecture:     Inheritance And Abstraction
// Problem:     3.Company Hierarchy
// Description: ...too long
//
// Date:        Thursday 11.2015 22:48 
//---------------------------------------------------

using System;
using System.Collections.Generic;
using _03.CompanyHierarchy.Hierarchy;

namespace _03.CompanyHierarchy
{
    internal class Program
    {
        private static void Main()
        {
            var employees = new List<Employee>();

            employees.Add(new Manager(2234, "Obi-Wan", "Kenobi", 10000, Departments.Sales));
            employees.Add(new Manager(1345, "Mace", "Windu", 12000, Departments.Marketing));
            employees.Add(new SalesRmployee(12345, "Depa", "Ballaba", 9000));
            employees.Add(new SalesRmployee(4363, "Qui-Gon", "Jinn", 10001));
            employees.Add(new Developer(46372, "Anakin", "Skywalker", 1));
            employees.Add(new Developer(543234, "Bastila", "Shan", 20000));

            Console.WriteLine(string.Join("\n", employees));
        }
    }
}