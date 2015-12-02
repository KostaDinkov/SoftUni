namespace _03.CompanyHierarchy.Hierarchy
{
    internal interface IEmployee
    {
        double Salary { get; set; }
        Departments Department { get; set; }
    }
}