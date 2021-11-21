using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Hen : Bird
    {
        private const double BaseWeightModifire = 0.35;
        private static HashSet<string> AllowedFood = new HashSet<string>
        {
            nameof(Meat),
            nameof(Seeds),
            nameof(Fruit),
            nameof(Vegetable) 
        };
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, AllowedFood, BaseWeightModifire, wingSize)
        {
        }

        public override string ProducingASound()
        {
            return "Cluck";
        }
    }
}
