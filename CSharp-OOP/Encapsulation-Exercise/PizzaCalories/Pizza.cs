using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private const int NameMinLeght = 1;
        private const int NameMaxLeght = 15;
        private const int MaxToppingCount = 10;

        private string name;
        private Dough dough;

        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.dough = dough;

            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                Validator.ThrowIfNumberIsNotInRange(NameMinLeght, NameMaxLeght, value.Length, $"Pizza name should be between {NameMinLeght} and {NameMaxLeght} symbols.");

                this.name = value;
            }
        }

        public void AddTopping(Topping topping)
        {
            Validator.ThrowIfNumberIsNotInRange(0, MaxToppingCount, this.toppings.Count, $"Number of toppings should be in range [0..{MaxToppingCount}].");

            this.toppings.Add(topping);
        }

        public double GetCalories()
        {
            return this.dough.CalculatingCalories() + this.toppings.Sum(t => t.GetCalories());
        }
    }
}
