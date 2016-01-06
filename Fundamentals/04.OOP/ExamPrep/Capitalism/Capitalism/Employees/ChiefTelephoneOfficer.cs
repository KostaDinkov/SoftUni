namespace Capitalism.Employees
{
    using CompanyMechanics;
    using Interfaces;

    public class ChiefTelephoneOfficer : Employee
    {
        private const double positionBonus = 0.98;
        private ISalaryCalculator salaryCalculator = new BasicSalaryCalculator();

        public ChiefTelephoneOfficer(string firstName, string lastName, string position, ICompany company, string department) : base(firstName, lastName, position, company, department)
        {
            this.PositionBonus = positionBonus;
        }
    }
}