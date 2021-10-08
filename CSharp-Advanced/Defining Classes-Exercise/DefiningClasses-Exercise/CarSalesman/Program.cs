using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    public class Program
    {
        static void Main(string[] args)
        {
            int nEngines = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            for (int i = 0; i < nEngines; i++)
            {
                string[] engineInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string engineModel = engineInfo[0];
                int power = int.Parse(engineInfo[1]);
                int? displacement = null;
                string efficiency = null;

                if (engineInfo.Length == 3)
                {
                    if (int.TryParse(engineInfo[2], out int parsedDisplacemant))
                    {
                        displacement = parsedDisplacemant;
                    }
                    else
                    {
                        efficiency = engineInfo[2];
                    }
                }

                if (engineInfo.Length == 4)
                {
                    displacement = int.Parse(engineInfo[2]);
                    efficiency = engineInfo[3];
                }

                Engine currentEngine = new Engine(engineModel, power, displacement, efficiency);
                engines.Add(currentEngine);
            }

            int mCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < mCars; i++)
            {
                string[] carInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string carModel = carInfo[0];
                string engineType = carInfo[1];
                int? weight = null;
                string color = null;
                Car currentCar = new Car();
                currentCar.Model = carModel;

                foreach (var engine in engines)
                {
                    if (engine.Model == engineType)
                    {
                        currentCar.Engine = engine;
                    }
                }

                if (carInfo.Length == 3)
                {
                    if (int.TryParse(carInfo[2], out int parsedWeight))
                    {
                        weight = parsedWeight;
                    }
                    else
                    {
                        color = carInfo[2];
                    }
                }

                if (carInfo.Length == 4)
                {
                    weight = int.Parse(carInfo[2]);
                    color = carInfo[3];
                }

                currentCar.Weight = weight;
                currentCar.Color = color;
                cars.Add(currentCar);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
