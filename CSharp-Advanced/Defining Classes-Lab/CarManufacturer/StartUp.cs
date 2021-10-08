using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> tires = new List<Tire[]>();
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            string input;
            while ((input = Console.ReadLine()) != "No more tires")
            {
                List<string> tiresInfo = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

                Tire[] currentTireSet = new Tire[4];
                for (int i = 0; i < 4; i++)
                {
                    Tire currentTire = new Tire(int.Parse(tiresInfo[0]), double.Parse(tiresInfo[1]));
                    currentTireSet[i] = currentTire;
                    tiresInfo.RemoveAt(0);
                    tiresInfo.RemoveAt(0);
                }

                tires.Add(currentTireSet);
            }

            while ((input = Console.ReadLine()) != "Engines done")
            {
                string[] engineInfo = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Engine currentEngine = new Engine(int.Parse(engineInfo[0]), double.Parse(engineInfo[1]));
                engines.Add(currentEngine);
            }

            while ((input  = Console.ReadLine()) != "Show special")
            {
                string[] carsInfo = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Engine engine = engines[int.Parse(carsInfo[5])];
                Tire[] tireSet = tires[int.Parse(carsInfo[6])];
                Car currentCar = new Car(carsInfo[0],
                    carsInfo[1],
                    int.Parse(carsInfo[2]),
                    double.Parse(carsInfo[3]),
                    double.Parse(carsInfo[4]),
                    engine,
                    tireSet);
                cars.Add(currentCar);
            }

            cars = cars.Where(c => c.Year >= 2017 &&
            c.Engine.HorsePower > 330 &&
            c.Tires.Sum(t => t.Pressure) >= 9 &&
            c.Tires.Sum(t => t.Pressure) <= 10)
                .ToList();

            foreach (var car in cars)
            {
                car.Drive(20);
                Console.WriteLine(car.WhoAmI());
            }
        }
    }
}
