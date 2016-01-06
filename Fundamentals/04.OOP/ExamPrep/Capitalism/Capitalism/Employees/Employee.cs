namespace Capitalism.Employees
{
    using Interfaces;

    public abstract class Employee
    {
        protected Employee(string firstName, string lastName, string position, ICompany company, string department)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Position = position;
            this.Company = company;
            this.Department = department;
            
            //Todo put the employee to the respective department
            
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Position { get; set; }

        public ICompany Company { get; set; }

        public string Department { get; set; }

        public double PositionBonus { get; set; }

        public ISalaryCalculator SalaryCalculator { get; set; }

        public double GetDepartmentBonus()
        {
            throw new System.NotImplementedException();
        }
    }
}