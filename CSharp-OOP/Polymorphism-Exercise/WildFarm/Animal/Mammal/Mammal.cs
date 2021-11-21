using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Mammal : Animal
    {
        protected Mammal(string name, double weight, HashSet<string> allowedFood, double weightModifier, string livingRegion)
            : base(name, weight, allowedFood, weightModifier)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion { get; set; }
    }
}
