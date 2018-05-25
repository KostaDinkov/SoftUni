using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantDiscount
{
    class RestaurantDiscount
    {
        private const string NOT_AVAILABLE = "We do not have an appropriate hall.";
        private const string AVAILABLE = "We can offer you the {0}";
        private const string PRICE_PER_PERSON = "The price per person is {0:#.00}$";

        private static List<Hall> halls = new List<Hall>
        {
            new Hall("Small Hall", 50, 2500m),
            new Hall("Terrace", 100, 5000m),
            new Hall("Great Hall", 120, 7500m)
        };

        private static Dictionary<string, Discount> discounts = new Dictionary<string, Discount>
        {
            {"Normal", new Discount("Normal", 5, 500)},
            {"Gold", new Discount("Gold", 10, 750)},
            {"Platinum", new Discount("Platinum", 15, 1000)}
        };

        static void Main()
        {
            var groupSize = int.Parse(Console.ReadLine());
            var discount = Console.ReadLine();

            var suitableHall = GetSuitableHall(groupSize);

            if (suitableHall==null)
            {
                Console.WriteLine(NOT_AVAILABLE);
                return;
            }

            var pricePerPerson = GetPricePerPerson(suitableHall, discounts[discount], groupSize);

            printResult(suitableHall, pricePerPerson);
        }

        private static void printResult(Hall suitableHall, decimal pricePerPerson)
        {
            Console.WriteLine(AVAILABLE,suitableHall.Name);
            Console.WriteLine(PRICE_PER_PERSON,pricePerPerson);
            
        }

        private static Hall GetSuitableHall(int groupSize)
        {
            try
            {
                return halls.Where(h => h.Capacity > groupSize).Min();
            }
            catch (ArgumentNullException)
            {
                return null;
            }
           
        }

        private static decimal GetPricePerPerson(Hall suitableHall, Discount discount, int groupSize)
        {
            return ((suitableHall.Price + discount.Price) * (1-(discount.DiscountPercent / 100))) / groupSize;
        }
    }

    class Discount
    {
        public Discount(string name, decimal discountPercent, decimal price)
        {
            this.Name = name;
            this.DiscountPercent = discountPercent;
            this.Price = price;
        }

        public string Name { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal Price { get; set; }
    }

    class Hall : IComparable<Hall>
    {
        public Hall(string name, int capacity, decimal price)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Price = price;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Capacity { get; set; }

        public int CompareTo(Hall other)
        {
            return this.Capacity - other.Capacity;
        }
    }
}