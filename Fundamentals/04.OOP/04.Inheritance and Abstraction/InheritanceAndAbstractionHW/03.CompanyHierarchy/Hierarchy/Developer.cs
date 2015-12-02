using System.Collections.Generic;
using _03.CompanyHierarchy.Utils;

namespace _03.CompanyHierarchy.Hierarchy
{
    internal class Developer : Employee, IDeveloper
    {
        public Developer(long id, string firstName, string lastName) : base(id, firstName, lastName)
        {
        }

        public Developer(long id, string firstName, string lastName, double salary)
            : base(id, firstName, lastName, salary, Departments.Production)
        {
        }

        public List<Project> Projects { get; set; } = new List<Project>();
    }
}