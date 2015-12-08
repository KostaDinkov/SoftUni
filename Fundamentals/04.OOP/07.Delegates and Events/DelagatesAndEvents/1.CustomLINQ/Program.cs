namespace _1.CustomLINQ
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static readonly List<int> numbers = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

        private static void Main(string[] args)
        {
            var oddNumbers = numbers.WhereNot(x => x%2 == 0).ToList();
            Console.WriteLine(string.Join(", ", oddNumbers));

            Student[] students =
            {
                new Student("Boba", 4.11),
                new Student("Jango", 5.11),
                new Student("Bane", 3.55)
            };

            //print the max grade in the collection of students
            var max = students.MaxWithSelector(st => st.Grade);
            Console.WriteLine(max);
        }
    }

    internal class Student
    {
        public Student(string name, double grade)
        {
            this.Name = name;
            this.Grade = grade;
        }

        public string Name { get; set; }
        public double Grade { get; set; }
    }
}