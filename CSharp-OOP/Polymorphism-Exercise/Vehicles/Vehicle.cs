using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        internal double fuelQuantity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, int tankCapacity)   
        {
            this.FuelQuantity = fuelQuantity > tankCapacity ? 0 : fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
        }

        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public int TankCapacity { get; set; }

        public virtual void Driven(double distance)
        {
            double currentFuelQuantity = FuelQuantity - (distance * FuelConsumption);
            if (currentFuelQuantity >= 0)
            {
                FuelQuantity -= distance * FuelConsumption;
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }

        public virtual void Refueled(double fuelAmount)
        {
            if (fuelAmount <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else if (fuelAmount + this.FuelQuantity > this.TankCapacity)
            {
                Console.WriteLine($"Cannot fit {fuelAmount} fuel in the tank");
            }
            else
            {
                FuelQuantity += fuelAmount;
            }
        }

        
    }
}
