using System;
using System.Text;

namespace _02.LaptopShop
{
    internal class Laptop
    {
        private string model;
        private string manufacturer;
        private string processor;
        private int ram;
        private string graphics;
        private string hdd;
        private double screen;
        private decimal price;
        private double batteryLife;
        private Battery laptopBattery;

        public string Model
        {
            get { return model; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Model name cannot be empty!");
                }
                model = value;
            }
        }

        public string Manufacturer
        {
            get { return manufacturer; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Manufacturer name cannot be empty!");
                }
                manufacturer = value;
            }
        }

        public string Processor
        {
            get { return processor; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Processor name cannot be empty!");
                }
                processor = value;
            }
        }

        public int Ram
        {
            get { return ram; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Ram capacity cannot be negative!");
                }
                ram = value;
            }
        }

        public string Graphics
        {
            get { return graphics; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Graphics Card cannot be empty!");
                }
                graphics = value;
            }
        }

        public string Hdd
        {
            get { return hdd; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("HDD cannot be empty!");
                }
                graphics = value;
            }
        }

        public double Screen
        {
            get { return screen; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Screen size cannot be negative!");
                }
                screen = value;
            }
        }

        public Battery LaptopBattery
        {
            get { return laptopBattery; }
            set
            {
                if (value != null)
                {
                    laptopBattery = value;
                }
            }
        }

        public decimal Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Processor name cannot be empty!");
                }
                price = value;
            }
        }

        public double BatteryLife
        {
            get { return batteryLife; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Battery Life cannot be negative!");
                }
                batteryLife = value;
            }
        }

        public Laptop(string model, decimal price)
        {
            Model = model;
            Price = price;
        }

        public Laptop(string model, decimal price, string processor, int ram)
        {
            Model = model;
            Price = price;
            Processor = processor;
            Ram = ram;
        }

        public override string ToString()
        {
            // prints only the fields holding actual information
            StringBuilder output = new StringBuilder();
            output.Append($"Model: {model}\n");
            if (manufacturer != null)
            {
                output.Append($"Manufacturer: {manufacturer}\n");
            }
            if (processor != null)
            {
                output.Append($"Processor: {processor}\n");
            }
            if (ram != 0)
            {
                output.Append($"RAM: {ram} GB\n");
            }
            if (graphics != null)
            {
                output.Append($"Graphics Card: {graphics}\n");
            }
            if (hdd != null)
            {
                output.Append($"HDD: {hdd}\n");
            }
            if (screen != 0)
            {
                output.Append($"Screen: {screen} in.\n");
            }
            if (laptopBattery != null)
            {
                output.Append(
                    $"Battery: {laptopBattery.Type}, {laptopBattery.CellCount}, {laptopBattery.Capacity} mAh\n");
            }
            if (batteryLife != 0)
            {
                output.Append($"Battery life: {batteryLife} hours\n");
            }
            output.Append($"Price: {price} lv.");

            return output.ToString();
        }
    }
}