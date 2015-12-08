namespace _2.Customer
{
    using System;

    internal class Payment : ICloneable
    {
        public Payment(string prodName, decimal price)
        {
            this.ProductName = prodName;
            this.Price = price;
        }

        public string ProductName { get; set; }
        public decimal Price { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}