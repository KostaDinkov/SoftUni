namespace Capitalism.Employees
{
    using CompanyMechanics;
    using Interfaces;

    public class Manager : Employee
    {
        private const double positionBonus = 1;
        private ISalaryCalculator salaryCalculator = new BasicSalaryCalculator();

        public Manager(string firstName, string lastName, string position, ICompany company, string department) : base(firstName, lastName, position, company, department)
        {
            this.PositionBonus = positionBonus;
        }
    }
}