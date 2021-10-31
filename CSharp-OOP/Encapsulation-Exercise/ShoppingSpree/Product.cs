using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Product
    {
        private string name;
        private double cost;
        public Product(string name, double cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public string Name
        { 
            get => this.name;
            set
            {
                Validator.ThrowIfStringIsNullOrEmpty(value);

                this.name = value;
            }
        }
        public double Cost
        {
            get => this.cost;
            private set
            {
                Validator.ThrowIfValueIsNegative(value);

                this.cost = value;
            }
        }
    }
}
