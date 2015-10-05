//SoftUni
//Course:   Advanced C#
//Lecture:  Functional Programming
//Problems: 1 - 10
using System;
using System.Collections.Generic;
using System.Linq;


namespace Student
{
    class MainClass
    {
        static void Main()
        {
            //Problem 1. Class Student (continued)
            List<Student> studentList = GenerateStudentsList();

            //Problem 2. Students By Group
            var studentsByGroup =
                studentList.Where(student => student.GroupNumber == 2)
                    .Select(student => new { student.GroupNumber, student.FirstName, student.LastName })
                    .OrderBy(student => student.FirstName);
            Console.WriteLine("2. Students By Group");
            PrintCollection(studentsByGroup);
            Pause();

            //Problem 3. Students By First and Last Name
            var studentsByFirstAndLastName =
                studentList.Where(student => (string.Compare(student.LastName, student.FirstName, StringComparison.Ordinal) == 1))
                    .Select(student => new { student.FirstName, student.LastName });
            Console.WriteLine("3. Students By First And Last Name");
            PrintCollection(studentsByFirstAndLastName);
            Pause();

            //Problem 4. Students by Age
            var studentsByAge =
                studentList.Where(student => (student.Age >= 18 && student.Age <= 24))
                    .Select(student => new { student.FirstName, student.LastName, student.Age });
            Console.WriteLine("4. Students by age between 18 and 24");
            PrintCollection(studentsByAge);
            Pause();

            //Problem 5. Sort Students
            var sortedStudents =
                studentList.OrderByDescending(student => student.FirstName)
                    .ThenByDescending(student => student.LastName).Select(student => new { student.FirstName, student.LastName });
            var sortedStudents2 = from student in studentList
                                  orderby student.FirstName descending, student.LastName descending
                                  select new { student.FirstName, student.LastName };

            Console.WriteLine("5. Sort Students");
            PrintCollection(sortedStudents);
            PrintCollection(sortedStudents2);
            Pause();

            //Problem 6. Filter Students by Email Domain
            var studentsByMail =
                studentList.Where(student => student.Email.Contains("abv.bg"))
                    .Select(student => new { student.FirstName, student.LastName, student.Email });
            Console.WriteLine("6. Filter Students by Email Domain");
            PrintCollection(studentsByMail);
            Pause();

            //Problem 7. Filter Students by Phone
            var studentsByPhone =
                studentList.Where(
                    student =>
                        student.Phone.StartsWith("02") ||
                        student.Phone.StartsWith("+3592") ||
                        student.Phone.StartsWith("+359 2"))
                    .Select(student => new { student.FirstName, student.LastName, student.Phone });
            Console.WriteLine("7. Filter Students by Phone");
            PrintCollection(studentsByPhone);
            Pause();

            //Problem 8. Excellent Students
            var excellentStudents =
                studentList.Where(student => student.Marks.Any(mark => mark == 6))
                    .Select(student => new { student.FirstName, student.LastName, student.Marks });
            Console.WriteLine("8. Excellent Students");
            Console.WriteLine("Note : grades (marks) are generated randomly so there might be no result sometimes\n");
            foreach (var excellentStudent in excellentStudents)
            {
                Console.WriteLine("" + excellentStudent.FirstName + " " + excellentStudent.LastName);
                Console.WriteLine("Grades :" + string.Join(", ", excellentStudent.Marks));
                Console.WriteLine(new string('-', 30));
            }
            Pause();

            //Problem 9. Weak Students
            var weakStudents =
                studentList.Where(student => student.Marks.Count(mark => mark == 2) == 2)
                    .Select(student => new { student.FirstName, student.LastName, student.Marks });
            Console.WriteLine("9. Weak Students");
            Console.WriteLine("Note : grades (marks) are generated randomly so there might be no result sometimes\n");

            foreach (var weakStudent in weakStudents)
            {
                Console.WriteLine("" + weakStudent.FirstName + " " + weakStudent.LastName);
                Console.WriteLine("Grades :" + string.Join(", ", weakStudent.Marks));
                Console.WriteLine(new string('-', 30));
            }
            Pause();

            //Problem 10. Students Enrolled in 2014
            Console.WriteLine("10. Students Enrolled in 2014");
            Console.WriteLine("Note : enrollment year is  being generated randomly (between 13 nad 14) so there might be no result sometimes\n");
            var studentsByYear = studentList.Where(student => student.FacultyNumber.ToString()[4] == '1' &&
                                                              student.FacultyNumber.ToString()[5] == '4')
                .Select(student => new { student.FacultyNumber, student.FirstName, student.LastName, student.Marks });
            foreach (var student in studentsByYear)
            {
                Console.WriteLine("" + student.FacultyNumber + " " + student.FirstName + " " + student.LastName);
                Console.WriteLine("Grades :" + string.Join(", ", student.Marks));
                Console.WriteLine(new string('-', 30));
            }

        }

        static void PrintCollection<T>(IEnumerable<T> items)
        {
            var props = typeof(T).GetProperties();
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var prop in props)
            {
                Console.Write("{0,10}\t", prop.Name);
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var item in items)
            {
                foreach (var prop in props)
                {
                    Console.Write("{0,10}\t", prop.GetValue(item, null));
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static Random rnd = new Random();

        static List<Student> GenerateStudentsList()
        {
            List<Student> students = new List<Student>();
            students.Add(new Student("Emma", "Stone", 23, "1-541-754-3010", "emma@studentmail.org", 1));
            students.Add(new Student("Scarlett", "Johansson", 33, "1-345-245-3010", "scarlett@studentmail.org", 1));
            students.Add(new Student("Natalie", "Portman", 24, "+359 2 88534", "natalie@studentmail.org", 1));
            students.Add(new Student("Charlize", "Theron", 25, "1-165-378-2761", "emma@studentmail.org", 1));
            students.Add(new Student("Jessica", "Alba", 19, "1-267-165-2877", "jessica@studentmail.org", 1));
            students.Add(new Student("Anne", "Hathawat", 30, "+35972483329", "anne@studentmail.org", 1));
            students.Add(new Student("Johnny", "Depp", 45, "02-443-5687", "johny@abv.bg", 2));
            students.Add(new Student("Tom", "Cruise", 46, "1-214-587-2877", "tom.c@abv.bg", 2));
            students.Add(new Student("Tom", "Hanks", 50, "1-436-190-389", "tom.h@abv.bg", 2));
            students.Add(new Student("Christian", "Bale", 37, "+3592567465", "christian@abv.bg", 2));
            students.Add(new Student("Matt", "Damon", 40, "1-256-723-4587", "matt@abv.bg", 2));

            foreach (var student in students)
            {
                for (int mark = 0; mark < 5; mark++)
                {
                    student.Marks.Add(rnd.Next(2, 7));
                }
            }
            return students;
        }

        static void Pause()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Press Any Key To continue to next solution!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
            Console.Clear();
        }
    }
}
