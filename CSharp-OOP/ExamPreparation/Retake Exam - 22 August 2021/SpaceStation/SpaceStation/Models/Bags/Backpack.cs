using SpaceStation.Models.Bags.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Bags
{
    public class Backpack : IBag
    {
        public Backpack()
        {
            this.Items = new List<string>();
        }

        public ICollection<string> Items { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (this.Items.Count == 0)
            {
                sb.Append($"Bag items: none");
            }
            else
            {
                sb.Append($"Bag items: {string.Join(", ", this.Items)}");
            }
            
            return sb.ToString();
        }
    }
}
