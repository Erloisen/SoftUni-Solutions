using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Animal
    {
        protected Animal(string name, double weight, HashSet<string> allowedFood, double weightModifier)
        {
            this.Name = name;
            this.Weight = weight;
            this.AllowedFood = allowedFood;
            this.WeightModifire = weightModifier;
        }

        private HashSet<string> AllowedFood { get; set; }

        private double WeightModifire { get; set; }

        public string Name { get; set; }

        public double Weight { get; set; }

        public int FoodEaten { get; set; }

        public abstract string ProducingASound();

        public void Eat(Food food)
        {
            if (!AllowedFood.Contains(food.GetType().Name))
            {
                throw new InvalidOperationException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            this.FoodEaten += food.Quantity;

            this.Weight += this.WeightModifire * food.Quantity;
        }
    }
}
