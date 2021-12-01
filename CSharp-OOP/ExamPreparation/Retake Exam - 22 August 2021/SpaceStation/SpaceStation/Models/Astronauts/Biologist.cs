using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const double BiologistOxygen = 70;
        private const int BiologistDecreaseOxygen = 5;
        public Biologist(string name)
            : base(name, BiologistOxygen)
        {
        }

        public override void Breath()
        {
            if (CanBreath)
            {
                this.Oxygen -= BiologistDecreaseOxygen;
            }
        }
    }
}
