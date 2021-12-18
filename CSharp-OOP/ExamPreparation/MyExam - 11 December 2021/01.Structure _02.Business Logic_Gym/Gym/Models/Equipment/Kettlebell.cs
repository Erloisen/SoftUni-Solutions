using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Equipment
{
    public class Kettlebell : Equipment
    {
        private const double Weights = 10000;
        private const decimal InitialPrice = 80m;
        public Kettlebell()
            : base(Weights, InitialPrice)
        {
        }
    }
}
