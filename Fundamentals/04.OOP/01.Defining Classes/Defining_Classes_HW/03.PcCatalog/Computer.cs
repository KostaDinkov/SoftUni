using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace _03.PcCatalog
{
    internal class Computer
    {
        private string name;
        private Dictionary<string, Component> components;
        private decimal totalPrice;

        public Computer(string name, params Component[] comps)
        {
            this.Name = name;
            this.components = new Dictionary<string, Component>();
            if (comps != null)
            {
                foreach (var comp in comps)
                {
                    this.components.Add(comp.Name,comp);
                    this.totalPrice += comp.Price;
                }
            }
            
        }

        public string GetInfo()
        {
            StringBuilder output = new StringBuilder();
            output.Append($"Computer Name: {name}\n");
            foreach (var component in components)
            {
                output.Append($"Component: {component.Key}, ");
                if (component.Value.Details != null)
                {
                    output.Append($"{component.Value.Details}, ");
                }
                output.Append(
                    $"price: {component.Value.Price.ToString("C2", CultureInfo.CreateSpecificCulture("bg-BG"))}\n");
            }
            output.Append(
                    $"Total Price: {totalPrice.ToString("C2", CultureInfo.CreateSpecificCulture("bg-BG"))}");
            return output.ToString();
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Computer name cannot be empty or null");
                }
                name = value;
            }
        }

        public void AddComponent(Component component)
        {
            if (component != null)
            {
                if (this.components.ContainsKey(component.Name))
                {
                    this.components[component.Name] = component;
                }
                else
                {
                    this.components.Add(component.Name, component);
                    this.totalPrice += component.Price;
                }
            }
            else
            {
                throw new ArgumentNullException("Component object cannot be null");
            }
        }

        public void RemoveComponent(string name)
        {
            if (components.ContainsKey(name))
            {
                components.Remove(name);
            }
        }

        public decimal TotalPrice
        {
            get { return totalPrice; }
        }
    }
}