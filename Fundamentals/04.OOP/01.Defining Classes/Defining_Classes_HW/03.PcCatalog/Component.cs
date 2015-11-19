
using System;

namespace _03.PcCatalog
{
    class Component
    {
        private string name;
        private string details;
        private decimal price;

        public Component(string name, decimal price, string details)
        {
            this.Name = name;
            this.Price = price;
            this.Details = details;
        }

        public Component(string name, decimal price) : this(name, price, null)
        {
            
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Component name cannot be empty or null!");
                }
                name = value;
            }
        }

        public string Details
        {
            get { return this.details; }
            set
            {
                if (value =="")
                {
                    throw new ArgumentOutOfRangeException("Details cannot be empty string!");
                }
                details = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price cannot be negative!");
                }
                price = value;
            }
        }
    }
}
