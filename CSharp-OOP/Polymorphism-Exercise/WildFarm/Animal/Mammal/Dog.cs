using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Dog : Mammal
    {
        private const double BaseWeightModifire = 0.40;
        private static HashSet<string> AllowedFood = new HashSet<string> { nameof(Meat) };
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, AllowedFood, BaseWeightModifire, livingRegion)
        {
        }

        public override string ProducingASound()
        {
            return "Woof!";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
