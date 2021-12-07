using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private List<Item> items;

        protected Bag(int capacity)
        {
            this.items = new List<Item>();
            this.Items = this.items.AsReadOnly();
            this.Capacity = capacity;
        }

        public int Capacity { get; set; } = 100;

        public int Load => Items.Sum(i => i.Weight);

        public IReadOnlyCollection<Item> Items { get; }

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }

            var currentItem = items.FirstOrDefault(i => i.GetType().Name == name);
            if (currentItem == null)
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }

            this.items.Remove(currentItem);
            return currentItem;
        }
    }
}
