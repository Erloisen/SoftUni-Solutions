using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double FuelConsumptionDuringSummer = 0.9;
        public Car(double fuelQuantity, double fuelConsumption, int tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption = fuelConsumption + FuelConsumptionDuringSummer;
        }

        public override void Driven(double distance)
        {
            double currentFuelQuantity = this.FuelQuantity - distance * this.FuelConsumption;
            if (currentFuelQuantity >= 0)
            {
                this.FuelQuantity -= distance * this.FuelConsumption;
                Console.WriteLine($"Car travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Car needs refueling");
            }
        }

        public override void Refueled(double fuelAmount)
        {
            base.Refueled(fuelAmount);
        }
    }
}
