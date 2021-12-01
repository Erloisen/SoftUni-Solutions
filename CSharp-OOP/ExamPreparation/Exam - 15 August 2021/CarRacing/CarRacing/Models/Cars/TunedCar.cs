using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    public class TunedCar : Car
    {
        private const double TunedCarFuelAvailable = 65;
        private const double TunedCarFuelConsumptionPerRace = 7.5;

        public TunedCar(string make, string model, string vIN, int horsePower)
            : base(make, model, vIN, horsePower, TunedCarFuelAvailable, TunedCarFuelConsumptionPerRace)
        {
        }

        public override void Drive()
        {
            base.Drive();
            this.HorsePower -= (int)Math.Round(this.HorsePower * 0.03);
        }
    }
}
