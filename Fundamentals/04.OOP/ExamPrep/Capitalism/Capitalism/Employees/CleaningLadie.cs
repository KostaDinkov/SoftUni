namespace Capitalism.Employees
{
    using CompanyMechanics;
    using Interfaces;

    public class CleaningLady : Employee
    {
        private const double positionBonus = 0.98;
        private ISalaryCalculator salaryCalculator = new BasicSalaryCalculator();

        public CleaningLady(string firstName, string lastName, string position, ICompany company, string department) : base(firstName, lastName, position, company, department)
        {
            this.PositionBonus = positionBonus;
        }
    }
}