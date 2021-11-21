using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Cat : Feline
    {
        private const double BaseWeightModifire = 0.3;
        private static HashSet<string> AllowedFood = new HashSet<string>
        { 
            nameof(Vegetable),
            nameof(Meat)
        };

        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, AllowedFood, BaseWeightModifire, livingRegion, breed)
        {
        }

        public override string ProducingASound()
        {
            return "Meow";
        }
    }
}
