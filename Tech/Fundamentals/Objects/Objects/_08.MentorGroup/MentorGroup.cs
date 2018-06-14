namespace _08.MentorGroup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class MentorGroup
    {
        private static void Main()
        {
            //Console.SetIn(new StreamReader("input.txt"));
            var students = new Dictionary<string, Student>();

            //Read dates
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "end of dates") break;

                var inputTokens = input.Split(" ");
                var name = inputTokens[0];

                var dates = new List<DateTime>();
                if (inputTokens.Length > 1)
                {
                    var datesInput = inputTokens[1].Split(",").Select(d => DateTime.ParseExact(d, "dd/MM/yyyy", null));
                    dates = new List<DateTime>(datesInput);

                    if (students.ContainsKey(name))
                        foreach (var dateTime in dates)
                            students[name].Attendance.Add(dateTime);
                    else
                        students.Add(name, new Student(name) {Attendance = dates});
                }
                else
                {
                    students.Add(name, new Student(name));
                }
            }

            //Read comments
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "end of comments") break;

                var inputTokens = input.Split("-", StringSplitOptions.RemoveEmptyEntries);
                var name = inputTokens[0];
                var comment = inputTokens[1];

                if (!students.ContainsKey(name)) continue;

                students[name].Comments.Add(comment);
            }

            //Print Results
            var ordered = students.OrderBy(pair => pair.Key);

            foreach (var student in ordered)
            {
                Console.WriteLine($"{student.Key}");
                Console.WriteLine("Comments:");
                foreach (var comment in student.Value.Comments) Console.WriteLine($"- {comment}");

                Console.WriteLine("Dates attended:");
                var datesOrdered = student.Value.Attendance.OrderBy(dt => dt);
                var dateFormat = "{0:dd/MM/yyyy}";
                foreach (var dateTime in datesOrdered) Console.WriteLine($"-- " + string.Format(dateFormat, dateTime));
            }
        }
    }

    internal class Student
    {
        public Student(string name)
        {
            this.Name = name;
            this.Attendance = new List<DateTime>();
            this.Comments = new List<string>();
        }

        public string Name { get; set; }
        public List<string> Comments { get; set; }
        public List<DateTime> Attendance { get; set; }
    }
}