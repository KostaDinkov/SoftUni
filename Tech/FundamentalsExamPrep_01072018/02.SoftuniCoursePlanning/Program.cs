using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SoftuniCoursePlanning
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var InitialCourseTitles = Console.ReadLine().Split(", ");
            var schedule = new List<Course>();
            foreach (var title in InitialCourseTitles)
            {
                schedule.Add(new Course {Title = title, HasExercise = false});
            }

            var commandInput = Console.ReadLine();
            while (commandInput != "course start")
            {
                var (command, parameters) = commandInput.Split(":").ToArray();

                switch (command)
                {
                    case "Add":
                        Add(parameters, schedule);
                        break;
                    case "Insert":
                        Insert(parameters, schedule);
                        break;
                    case "Remove":
                        Remove(parameters, schedule);
                        break;
                    case "Swap":
                        Swap(parameters, schedule);
                        break;
                    case "Exercise":
                        Exercise(parameters, schedule);
                        break;
                }

                commandInput = Console.ReadLine();
            }

            var counter = 1;
            foreach (var course in schedule)
            {
                Console.WriteLine($"{counter}.{course.Title}");
                counter++;
                if (course.HasExercise)
                {
                    Console.WriteLine($"{counter}.{course.Title}-Exercise");
                    counter++;
                }
            }
        }

        private static void Exercise(string[] parameters, List<Course> schedule)
        {
            var title = parameters[0];
            var course = schedule.Find(x => x.Title == title);
            if (course != null)
            {
                course.HasExercise = true;
            }
            else
            {
                schedule.Add(new Course {Title = title, HasExercise = true});
            }
        }

        private static void Swap(string[] parameters, List<Course> schedule)
        {
            var (title1, (title2, rest)) = parameters;
            var index1 = schedule.FindIndex(x => x.Title == title1);
            var index2 = schedule.FindIndex(x => x.Title == title2);

            if (index1 < 0 || index2 < 0) return;
            var tmp = schedule[index1];
            schedule[index1] = schedule[index2];
            schedule[index2] = tmp;
        }

        private static void Remove(string[] parameters, List<Course> schedule)
        {
            var title = parameters[0];
            var index = schedule.FindIndex(x => x.Title == title);
            if (index > 0)
            {
                schedule.RemoveAt(index);
            }
        }

        private static void Insert(string[] parameters, List<Course> schedule)
        {
            var (title, (indexStr, rest)) = parameters;
            var index = int.Parse(indexStr);
            if (schedule.All(x => x.Title != title) && index >= 0 && index < schedule.Count)
            {
                schedule.Insert(index, new Course {Title = title, HasExercise = false});
            }
        }

        private static void Add(string[] parameters, List<Course> schedule)
        {
            var title = parameters[0];
            if (schedule.All(x => x.Title != title))
            {
                schedule.Add(new Course {Title = title, HasExercise = false});
            }
        }
    }

    public class Course
    {
        public string Title { get; set; }
        public bool HasExercise { get; set; }
    }

    public static class ArrayExtensions
    {
        public static void Deconstruct<T>(this T[] array, out T first, out T[] rest)
        {
            first = array.Length > 0 ? array[0] : default(T);
            rest = array.Skip(1).ToArray();
        }
    }
}