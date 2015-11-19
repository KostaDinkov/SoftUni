using System;

namespace _02.LaptopShop
{
    internal class Battery
    {
        private string type;
        private int cellCount;
        private double capacity;

        public Battery(string type, int cellCount, double capacity)
        {
            Type = type;
            CellCount = cellCount;
            Capacity = capacity;
        }
        
        public string Type
        {
            get { return type; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Battery type cannot be empty!");
                }
                type = value;
            }
        }

        public int CellCount
        {
            get { return cellCount; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Cell count cannot be negative!");
                }
                cellCount = value;
            }
        }

        public double Capacity
        {
            get { return capacity; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Capacity cannot be negative!");
                }
                capacity = value;
            }
        }
    }
}