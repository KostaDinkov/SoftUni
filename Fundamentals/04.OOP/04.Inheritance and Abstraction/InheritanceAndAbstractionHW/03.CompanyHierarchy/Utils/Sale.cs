using System;

namespace _03.CompanyHierarchy.Utils
{
    internal class Sale
    {
        private decimal price;

        public Sale(string productName, decimal price, DateTime date)
        {
            this.ProductName = productName;
            this.Price = price;
            this.Date = date;
        }

        public string ProductName { get; set; }
        public DateTime Date { get; set; }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Price cannot be less then 0");

                this.price = value;
            }
        }
    }
}