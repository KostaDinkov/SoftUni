namespace _04.AverageGrades
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class AverageGrades
    {
        private static void Main()
        {
            var students = new List<Student>();
            var count = int.Parse(Console.ReadLine());
            for (var i = 0; i < count; i++)
            {
                var input = Console.ReadLine().Split(" ");
                var name = input[0];

                var student = new Student(name);
                for (var j = 1; j < input.Length; j++) student.AddGrade(double.Parse(input[j]));

                students.Add(student);
            }

            const string gradeFormat = "{0:0.00}";
            students
                .Where(s => s.AverageGrade >= 5)
                .OrderBy(s => s.Name)
                .ThenByDescending(s => s.AverageGrade)
                .ToList()
                .ForEach(s => Console.WriteLine($"{s.Name} -> {string.Format(gradeFormat, s.AverageGrade)}"));
        }
    }

    internal class Student
    {
        public Student(string name)
        {
            this.Name = name;
            this.Grades = new List<double>();
        }

        public string Name { get; set; }

        private List<double> Grades { get; set; }

        public double AverageGrade => this.Grades.Average();

        public void AddGrade(double grade)
        {
            this.Grades.Add(grade);
        }
    }
}