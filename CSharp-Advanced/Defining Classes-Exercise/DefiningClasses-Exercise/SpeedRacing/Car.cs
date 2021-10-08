using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
        }
        
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; } = 0;

        public void Drive(double distance)
        {
            var consumedFuel = distance * FuelConsumptionPerKilometer;
            if (FuelAmount - consumedFuel >= 0)
            {
                FuelAmount -= consumedFuel;
                TravelledDistance += distance; 
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
