namespace Capitalism.Interfaces
{
    public interface IDepartment : IAdministrationUnit
    {
        IEmployee Manager { get; set; }
        IDepartment MainDepartment { get; set; }
        double DepartmentBonus { get; set; }
    }
}