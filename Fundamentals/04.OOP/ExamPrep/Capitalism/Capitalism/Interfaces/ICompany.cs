namespace Capitalism.Interfaces
{
    public interface ICompany : IAdministrationUnit
    {
        string CeoFirstName { get; set; }
        string CeoLastName { get; set; }
        decimal CEOSalary { get; set; }

        void PaySalaries();
    }
}