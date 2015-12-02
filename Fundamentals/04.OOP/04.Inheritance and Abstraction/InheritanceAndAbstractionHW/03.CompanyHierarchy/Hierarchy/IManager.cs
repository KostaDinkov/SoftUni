using System.Collections.Generic;

namespace _03.CompanyHierarchy.Hierarchy
{
    internal interface IManager
    {
        List<Employee> Employees { get; set; }
    }
}