using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private const int MinWeight = 1;
        private const int MaxWeight = 50;

        private string name;
        private int weight;

        public Topping(string name, int weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                Validator.ThrowIfValueIsNotAllowed(new HashSet<string> { "meat", "veggies", "cheese", "sauce" },
                    value.ToLower(),
                    $"Cannot place {value} on top of your pizza.");
                
                this.name = value;
            }
        }

        public int Weight
        {
            get => this.weight;
            private set
            {
                Validator.ThrowIfNumberIsNotInRange(MinWeight, MaxWeight, value, $"{name} weight should be in the range [{MinWeight}..{MaxWeight}].");

                this.weight = value;
            }
        }

        public double GetCalories()
        {
            var modifier = GetModifier();
            return this.Weight * 2 * modifier;
        }

        private double GetModifier()
        {
            var nameToLower = this.Name.ToLower();
            var modifirer = 0.0;
            switch (nameToLower)
            {
                case "meat":
                    modifirer = 1.2;
                    break;
                case "veggies":
                    modifirer = 0.8;
                    break;
                case "cheese":
                    modifirer = 1.1;
                    break;
                case "sauce":
                    modifirer = 0.9;
                    break;
            }

            return modifirer;
        }
    }
}
