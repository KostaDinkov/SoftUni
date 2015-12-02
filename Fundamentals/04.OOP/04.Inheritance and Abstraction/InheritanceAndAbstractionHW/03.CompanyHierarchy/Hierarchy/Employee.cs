using System;

namespace _03.CompanyHierarchy.Hierarchy
{
    internal class Employee : Person, IEmployee
    {
        private double salary;

        public Employee(long id, string firstName, string lastName) : base(id, firstName, lastName)
        {
        }

        public Employee(long id, string firstName, string lastName, double salary, Departments department)
            : base(id, firstName, lastName)
        {
            this.Salary = salary;
            this.Department = department;
        }

        public double Salary
        {
            get { return this.salary; }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Salary cannot be less than zero");
                this.salary = value;
            }
        }

        public Departments Department { get; set; }
        public override string ToString()
        {
            return base.ToString() + $"\n" +
                   $"\tDepartment: {this.Department}\n" +
                   $"\tSalary: {this.Salary}";

        }
    }
}