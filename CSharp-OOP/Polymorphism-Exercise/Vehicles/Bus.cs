using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, int tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override void Driven(double distance)
        {
            double currentFuelQuantity = this.FuelQuantity - distance * (this.FuelConsumption + 1.4);
            if (currentFuelQuantity >= 0)
            {
                this.FuelQuantity -= distance * (this.FuelConsumption + 1.4);
                Console.WriteLine($"Bus travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Bus needs refueling");
            }
        }

        public void Driven(double distance, string str)
        {
            base.Driven(distance);
        }

        public override void Refueled(double fuelAmount)
        {
            base.Refueled(fuelAmount);
        }
    }
}
