using System;

namespace _03.CompanyHierarchy.Hierarchy
{
    internal class Person : IPerson
    {
        private string firstName;
        private string lastName;

        public Person(long id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public long Id { get; set; }

        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("Name cannot be empty");
                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("Name cannot be empty");
                this.lastName = value;
            }
        }

        public override string ToString()
        {
            return $"ID: {this.Id}, {firstName}, {lastName}";
        }
    }
}