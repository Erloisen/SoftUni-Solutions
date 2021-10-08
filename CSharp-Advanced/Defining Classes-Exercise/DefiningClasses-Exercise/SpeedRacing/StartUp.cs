using System;
using System.Collections.Generic;
using System.Linq;

namespace Cars
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine().Split();
                string model = carInfo[0];
                double fuelAmount = double.Parse(carInfo[1]);
                double fuelConsumptionPerKilometer = double.Parse(carInfo[2]);
                Car currentCar = new Car(model, fuelAmount, fuelConsumptionPerKilometer);
                cars.Add(currentCar);
            }

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] drive = input.Split();
                string carModel = drive[1];
                int amountOfKm = int.Parse(drive[2]);

                foreach (var car in cars.Where(c => c.Model == carModel))
                {
                    car.Drive(amountOfKm);
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
