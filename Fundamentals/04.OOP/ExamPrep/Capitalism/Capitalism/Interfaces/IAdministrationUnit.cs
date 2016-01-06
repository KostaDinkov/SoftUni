namespace Capitalism.Interfaces
{
    using System.Collections.Generic;
    using Employees;

    public interface IAdministrationUnit
    {
        string Name { get; set; }
        List<Employee> Employees { get; set; }
    }
}