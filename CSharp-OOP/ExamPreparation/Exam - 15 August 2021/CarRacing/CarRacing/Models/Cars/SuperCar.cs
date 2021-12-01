using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    public class SuperCar : Car
    {
        private const double SuperCarFuelAvailable = 80;
        private const double SuperCarFuelConsumptionPerRace = 10;
        public SuperCar(string make, string model, string vIN, int horsePower)
            : base(make, model, vIN, horsePower, SuperCarFuelAvailable, SuperCarFuelConsumptionPerRace)
        {
        }
    }
}
