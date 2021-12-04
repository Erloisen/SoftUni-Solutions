using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Bunnies
{
    public class HappyBunny : Bunny
    {
        private const int HappyBunnyEnergy = 100;
        public HappyBunny(string name)
            : base(name, HappyBunnyEnergy)
        {
        }

        public override void Work()
        {
            this.Energy -= 10;
        }
    }
}
