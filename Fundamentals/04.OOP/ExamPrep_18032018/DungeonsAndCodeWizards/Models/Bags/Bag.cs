using System;
using System.Collections.Generic;
using System.Linq;
using DungeonsAndCodeWizards.Models.Items;

namespace DungeonsAndCodeWizards.Models.Bags
{
    public abstract class Bag
    {
        public readonly List<Item> Items;

        public Bag(int capacity = 100)
        {
            Capacity = capacity;
            Items = new List<Item>();
            Load = 0;
        }

        public int Capacity { get; set; }

        public int Load { get; private set; }

        public void AddItem(Item item)
        {
            if (Load + item.Weight <= Capacity)
            {
                Items.Add(item);
                Load += item.Weight;
            }
            else
            {
                throw new InvalidOperationException("Bag is full!");
            }
        }

        public Item GetItem(string name)
        {
            if (Items.Count == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }

            var Item = Items.FirstOrDefault(i => i.GetType().ToString() == name);
            if (Item != null)
            {
                Items.Remove(Item);
                return Item;
            }
            else
            {
                throw new ArgumentException($"No Item with name {name} is bag!");
            }
        }
    }
}