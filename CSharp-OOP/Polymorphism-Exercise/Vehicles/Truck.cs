using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double FuelConsumptionDuringSummer = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption, int tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption = fuelConsumption + FuelConsumptionDuringSummer;
        }

        public override void Driven(double distance)
        {
            double currentFuelQuantity = FuelQuantity - (distance * FuelConsumption);
            if (currentFuelQuantity >= 0)
            {
                FuelQuantity -= distance * FuelConsumption;
                Console.WriteLine($"Truck travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"Truck needs refueling");
            }
        }

        public override void Refueled(double fuelAmount)
        {
            var currentFuelQuantity = this.FuelQuantity + fuelAmount * 0.95;
            if (fuelAmount <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else if (currentFuelQuantity > this.TankCapacity)
            {
                Console.WriteLine($"Cannot fit {fuelAmount} fuel in the tank");
            }
            else
            {
                this.FuelQuantity += fuelAmount * 0.95;
            }
        }
    }
}
