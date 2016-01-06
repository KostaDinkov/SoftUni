namespace Capitalism.Employees
{
    using CompanyMechanics;
    using Interfaces;

    public class Salesman : Employee
    {
        private const double positionBonus = 1.015;
        private ISalaryCalculator salaryCalculator = new BasicSalaryCalculator();

        public Salesman(string firstName, string lastName, string position, ICompany company, string department) : base(firstName, lastName, position, company, department)
        {
            this.PositionBonus = positionBonus;
        }
    }
}