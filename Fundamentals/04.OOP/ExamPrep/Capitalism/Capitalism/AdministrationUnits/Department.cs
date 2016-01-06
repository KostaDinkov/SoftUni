namespace Capitalism.AdministrationUnits
{
    using System.Collections.Generic;
    using Employees;
    using Interfaces;

    public class Department : IDepartment
    {
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
        public IEmployee Manager { get; set; }
        public IDepartment MainDepartment { get; set; }
        public double DepartmentBonus { get; set; }
    }
}