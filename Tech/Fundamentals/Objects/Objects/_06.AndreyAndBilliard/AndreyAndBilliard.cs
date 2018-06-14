namespace _06.AndreyAndBilliard
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    internal class AndreyAndBilliard
    {
        private static void Main()
        {
            //Console.SetIn(new StreamReader("input.txt"));

            var priceList = new Dictionary<string, decimal>();
            var customers = new SortedDictionary<string, Customer>();
            getProducts(priceList);

            while (true)
            {
                var lineInput = Console.ReadLine();
                if (lineInput == "end of clients") break;

                var customerInput = lineInput.Split(new[] {'-', ','}, StringSplitOptions.RemoveEmptyEntries);
                var name = customerInput[0];
                var product = customerInput[1];
                var qtty = int.Parse(customerInput[2]);

                if (priceList.ContainsKey(product))
                {
                    if (customers.ContainsKey(name))
                    {
                        customers[name].AddProduct(product, qtty, priceList);
                    }
                    else
                    {
                        var customer = new Customer(name);
                        customer.AddProduct(product, qtty, priceList);
                        customers.Add(name, customer);
                    }
                }
            }

            PrintBill(customers);
        }

        private static void PrintBill(SortedDictionary<string, Customer> customers)
        {
            var totalBill = 0m;
            foreach (var customer in customers)
            {
                Console.WriteLine(customer.Key);
                foreach (var product in customer.Value.Products)
                    Console.WriteLine($"-- {product.Key} - {product.Value}");

                totalBill += customer.Value.Bill;
                Console.WriteLine($"Bill: {string.Format("{0:0.00}", customer.Value.Bill)}");
            }

            Console.WriteLine($"Total bill: {string.Format("{0:0.00}", totalBill)}");
        }

        private static void getProducts(Dictionary<string, decimal> products)
        {
            var prodCount = int.Parse(Console.ReadLine());
            for (var i = 0; i < prodCount; i++)
            {
                var product = Console.ReadLine().Split("-");
                var name = product[0];
                var price = decimal.Parse(product[1]);
                if (products.ContainsKey(name))
                    products[name] = price;
                else
                    products.Add(name, price);
            }
        }
    }

    internal class Customer
    {
        public Customer(string name)
        {
            this.Name = name;
            this.Products = new Dictionary<string, int>();
            this.Bill = 0;
        }

        public string Name { get;}
        public Dictionary<string, int> Products { get; }
        public decimal Bill { get; private set; }

        public void AddProduct(string name, int qtty, Dictionary<string, decimal> priceList)
        {
            if (this.Products.ContainsKey(name))
                this.Products[name] += qtty;
            else
                this.Products.Add(name, qtty);

            this.Bill += qtty * priceList[name];
        }
    }
}