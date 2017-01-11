using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using DatabaseFirst.Models;

namespace DatabaseFirst
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var softUniDb = new SoftUniContext())
            {
                //softUniDb.Database.Log = Console.WriteLine;
                var fileStream = new FileStream("../../result.txt", FileMode.Create, FileAccess.ReadWrite);
                using (var sr = new StreamWriter(fileStream))
                {
                   
                    Task19(sr);
                }
            }
        }

        private static void Task3(SoftUniContext context, StreamWriter sr)
        {
            var employees = context.Employees.ToList();
            foreach (var employee in employees)
                sr.WriteLine($"{employee.FirstName} " +
                             $"{employee.LastName} " +
                             $"{employee.MiddleName} " +
                             $"{employee.JobTitle} " +
                             $"{employee.Salary}");
        }

        private static void Task4(SoftUniContext context, StreamWriter sr)
        {
            var employeesFirstNames = context.Employees.Where(e => e.Salary > 50000).Select(e => e.FirstName);
            foreach (var employee in employeesFirstNames)
                sr.WriteLine($"{employee}");
        }

        private static void Task5(SoftUniContext context, StreamWriter sr)
        {
            var rdEmployees =
                context.Employees.Where(e => e.Department.Name == "Research and Development")
                       .Select(e => new {e.FirstName, e.LastName, DepartmentName = e.Department.Name, e.Salary})
                       .OrderBy(e => e.Salary)
                       .ThenByDescending(e => e.FirstName).ToList();
            foreach (var employee in rdEmployees)
                sr.WriteLine(
                    $"{employee.FirstName} {employee.LastName} from {employee.DepartmentName} - ${employee.Salary:F2}");
        }

        private static void Task6(SoftUniContext context, StreamWriter sr)
        {
            var address = new Address
                          {
                              AddressText = "Vitoshka 15",
                              TownID = 4
                          };
            var nakov = context.Employees.FirstOrDefault(e => e.LastName == "Nakov");
            nakov.Address = address;
            context.SaveChanges();

            var adresses = context.Employees.OrderByDescending(e => e.AddressID).Take(10).Select(e => e.Address);
            foreach (var a in adresses)
                sr.WriteLine(a.AddressText);
        }

        private static void Task7(SoftUniContext context, StreamWriter sr)
        {
            var project = context.Projects.Find(2);

            project.Employees.Clear();

            context.Projects.Remove(project);
            context.SaveChanges();

            var projects = context.Projects.Take(10).Select(p => p.Name);
            foreach (var a in projects)
                sr.WriteLine(a);
        }

        private static void Task8(SoftUniContext context, StreamWriter sr)
        {
            var query =
                context.Employees
                       .Where(e => e.Projects.Any((p => (p.StartDate.Year >= 2001) && (p.StartDate.Year <= 2003))))
                       .Take(30)
                       .Select(e => new {e.FirstName, e.LastName, e.Manager, e.Projects});

            foreach (var e in query)
            {
                sr.WriteLine($"{e.FirstName} {e.LastName} {e.Manager.FirstName}");
                foreach (Project project in e.Projects)
                {
                    sr.WriteLine(
                        $"--{project.Name} " +
                        $"{project.StartDate.ToString("M'/'d'/'yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} " +
                        $"{project.EndDate?.ToString("M'/'d'/'yyyy h:mm:ss tt", CultureInfo.InvariantCulture)}");
                }
            }
        }

        private static void Task9(SoftUniContext context, StreamWriter sr)
        {
            var query =
                context.Addresses.Select(a => new {a.AddressText, a.Town, a.Employees.Count})
                       .OrderByDescending(a => a.Count)
                       .ThenBy(a => a.Town)
                       .Take(10);


            foreach (var a in query)
            {
                sr.WriteLine($"{a.AddressText}, {a.Town.Name} - {a.Count} employees");
            }
        }

        private static void Task10(SoftUniContext context, StreamWriter sr)
        {
            var employee147 = context.Employees.Find(147);

            sr.WriteLine($"{employee147.FirstName} {employee147.LastName} {employee147.JobTitle}");
            foreach (Project p in employee147.Projects.OrderBy(p => p.Name))
            {
                sr.WriteLine($"{p.Name}");
            }
        }

        private static void Task11(SoftUniContext context, StreamWriter sr)
        {
            var query = context.Departments
                               .Select(e => new
                                            {
                                                DepartmentName = e.Name,
                                                ManagerName = e.Employee.FirstName,
                                                Employees = e.Employees,
                                                EmployeeCount = e.Employees.Count
                                            })
                               .Where(d => d.EmployeeCount > 5)
                               .OrderBy(d => d.EmployeeCount);

            foreach (var dep in query)
            {
                sr.WriteLine($"{dep.DepartmentName} {dep.ManagerName}");
                foreach (Employee employee in dep.Employees.OrderBy(e => e.EmployeeID))
                {
                    sr.WriteLine($"{employee.FirstName} {employee.LastName} {employee.JobTitle}");
                }
            }
        }

        private static void Task12(SoftUniContext context, StreamWriter sr)
        {
            var timer = new Stopwatch();
            timer.Start();
            PrintNamesWithSqlQuery(context, sr);

            timer.Stop();
            Console.WriteLine($"SQL Query: {timer.Elapsed}");

            timer.Restart();
            PrintNamesWithLinq(context, sr);
            timer.Stop();
            Console.WriteLine($"Linq Query: {timer.Elapsed}");
        }

        private static void Task15(SoftUniContext context, StreamWriter sr)
        {
            var query = context.Projects.OrderByDescending(p => p.StartDate).Take(10);

            foreach (Project project in query.OrderBy(p => p.Name))
            {
                sr.WriteLine(
                    $"{project.Name} {project.Description} {project.StartDate.ToString("M'/'d'/'yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} {project.EndDate}");
            }
        }

        private static void Task16(SoftUniContext context, StreamWriter sr)
        {
            var departments = new string[] {"Engineering", "Tool Design", "Marketing", "Information Services"};
            var query = context.Employees.Where(e => departments.Contains(e.Department.Name));

            foreach (Employee employee in query)
            {
                //sr.WriteLine("Before :");
                //sr.WriteLine($"{employee.FirstName} {employee.LastName} ${employee.Salary}");
                employee.Salary *= 1.12m;
                //sr.WriteLine("After :");
                sr.WriteLine($"{employee.FirstName} {employee.LastName} (${employee.Salary})");
                
            }
            context.SaveChanges();
        }

        private static void Task18(SoftUniContext context, StreamWriter sr)
        {
            var query = context.Employees.Where(e => e.FirstName.StartsWith("SA"));
            foreach (Employee employee in query)
            {
                sr.WriteLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary})");
            }
        }
        private static void Task19(StreamWriter sr)
        {
            using (GringoDb db = new GringoDb())
            {
                var query =
                    db.WizzardDeposits.Where(wd => wd.DepositGroup == "Troll Chest")
                      .Select(wd => wd.FirstName).ToList();
                      

                foreach (var s in query.Select(s => s.First()).OrderBy(e => e).Distinct())
                {
                    sr.WriteLine(s);
                }
            }
            
        }

        private static void PrintNamesWithSqlQuery(SoftUniContext context, StreamWriter sr)
        {
            string sqlQuery = "select e.FirstName from Employees e\r\n" +
                              "join EmployeesProjects ep on e.EmployeeID = ep.EmployeeID\r\n" +
                              "join Projects p\ton p.ProjectID= ep.ProjectID\r\n" +
                              "where DatePart(Year,p.StartDate) = 2002" +
                              "\r\ngroup by e.FirstName";

            var query = context.Database.SqlQuery<string>(sqlQuery);
            foreach (var employee in query)
            {
                sr.WriteLine(employee);
            }
        }

        private static void PrintNamesWithLinq(SoftUniContext context, StreamWriter sr)
        {
            var query =
                context.Employees.Where(e => e.Projects.Any(p => p.StartDate.Year == 2002)).Select(e => e.FirstName);

            foreach (string s in query)
            {
                sr.WriteLine(s);
            }
        }
    }
}