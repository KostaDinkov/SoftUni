using System;

namespace _03.CompanyHierarchy.Hierarchy
{
    internal class Customer : Person, ICustomer
    {
        private decimal totalMoneySpent;

        public Customer(long id, string firstName, string lastName) : base(id, firstName, lastName)
        {
        }

        public decimal TotalMoneySpent
        {
            get { return this.totalMoneySpent; }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Total money spent cannot be negative!");
                this.totalMoneySpent = value;
            }
        }
    }
}