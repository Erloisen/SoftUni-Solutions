using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Mouse : Mammal
    {
        private const double BaseWeightModifire = 0.10;
        private static HashSet<string> AllowedFood = new HashSet<string>
        {
            nameof(Vegetable),
            nameof(Fruit)
        };

        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, AllowedFood, BaseWeightModifire, livingRegion)
        {
        }

        public override string ProducingASound()
        {
            return "Squeak";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
