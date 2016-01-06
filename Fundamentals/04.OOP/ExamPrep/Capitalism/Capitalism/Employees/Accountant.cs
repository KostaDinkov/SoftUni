namespace Capitalism.Employees
{
    using CompanyMechanics;
    using Interfaces;

    public class Accountant : Employee
    {
        private const double positionBonus = 1;
        private ISalaryCalculator salaryCalculator = new BasicSalaryCalculator();

        public Accountant(string firstName, string lastName, string position, ICompany company, string department) : base(firstName, lastName, position, company, department)
        {
            this.PositionBonus = positionBonus;
        }
    }
}