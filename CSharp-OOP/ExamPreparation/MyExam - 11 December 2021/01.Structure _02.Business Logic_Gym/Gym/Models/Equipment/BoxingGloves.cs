using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Equipment
{
    public class BoxingGloves : Equipment
    {
        private const double Weights = 227;
        private const decimal InitialPrice = 120m;
        public BoxingGloves()
            : base(Weights, InitialPrice)
        {
        }
    }
}
