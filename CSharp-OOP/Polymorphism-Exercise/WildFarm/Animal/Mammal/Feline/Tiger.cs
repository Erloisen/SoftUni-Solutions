using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Tiger : Feline
    {
        private const double BaseWeightModifire = 1.0;
        private static HashSet<string> AllowedFood = new HashSet<string> { nameof(Meat) };

        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, AllowedFood, BaseWeightModifire, livingRegion, breed)
        {
        }

        public override string ProducingASound()
        {
            return "ROAR!!!";
        }
    }
}
