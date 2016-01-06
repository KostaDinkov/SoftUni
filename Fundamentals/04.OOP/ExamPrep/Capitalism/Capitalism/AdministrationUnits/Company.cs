namespace Capitalism.AdministrationUnits
{
    using System.Collections.Generic;
    using Employees;
    using Interfaces;

    public class Company : ICompany
    {
        public Company(string name, string ceoFirstName,string seoLastName, decimal ceoSalary)
        {
            this.Name = name;
           
            
            this.CEOSalary = ceoSalary;
        }
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
        public string CeoFirstName { get; set; }
        public string CeoLastName { get; set; }
        public decimal CEOSalary { get; set; }

        public void PaySalaries()
        {
            //TODO Pay Salaries
            throw new System.NotImplementedException();
        }
    }
}