using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private double money;
        private readonly List<Product> bagOfProducts;

        public Person(string name, double money)
        {
            this.Name = name;
            this.Money = money;

            this.bagOfProducts = new List<Product>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                Validator.ThrowIfStringIsNullOrEmpty(value);

                name = value;
            }
        }

        public double Money
        {
            get => this.money;
            set
            {
                Validator.ThrowIfValueIsNegative(value);

                money = value;
            }
        }

        public void BuyProduct(Product product)
        {
            if (product.Cost > this.Money)
            {
                throw new InvalidOperationException($"{this.Name} can't afford {product.Name}");
            }

            this.bagOfProducts.Add(product);
            this.Money -= product.Cost;
        }

        public override string ToString()
        {
            if (this.bagOfProducts.Count == 0)
            {
                return $"{this.Name} - Nothing bought";
            }

            return $"{this.Name} - {string.Join(", ", this.bagOfProducts.Select(p => p.Name))}";
        }
    }
}
