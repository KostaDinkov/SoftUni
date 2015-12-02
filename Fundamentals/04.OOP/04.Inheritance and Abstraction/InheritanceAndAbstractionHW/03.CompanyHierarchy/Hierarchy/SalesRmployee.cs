using System.Collections.Generic;
using _03.CompanyHierarchy.Utils;

namespace _03.CompanyHierarchy.Hierarchy
{
    internal class SalesRmployee : Employee, ISalesRmployee
    {
        public SalesRmployee(long id, string firstName, string lastName)
            : base(id, firstName, lastName)
        {
        }

        public SalesRmployee(long id, string firstName, string lastName, double salary)
            : base(id, firstName, lastName, salary, Departments.Sales)
        {
        }

        public List<Sale> Sales { get; set; } = new List<Sale>();
    }
}