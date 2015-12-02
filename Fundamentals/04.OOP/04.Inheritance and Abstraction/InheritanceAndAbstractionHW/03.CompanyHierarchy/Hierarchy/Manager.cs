using System.Collections.Generic;

namespace _03.CompanyHierarchy.Hierarchy
{
    internal class Manager : Employee, IManager
    {
        public Manager(long id, string firstName, string lastName) : base(id, firstName, lastName)
        {
        }

        public Manager(long id, string firstName, string lastName, double salary, Departments department)
            : base(id, firstName, lastName, salary, department)
        {
        }

        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}