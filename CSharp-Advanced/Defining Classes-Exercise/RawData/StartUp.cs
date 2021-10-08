using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string model = input[0];
                Engine engine = new Engine(int.Parse(input[1]), int.Parse(input[2]));
                Cargo cargo = new Cargo(int.Parse(input[3]), input[4]);
                Tire[] currentTireSet = new Tire[4];

                int counter = 0;
                for (int j = 0; j < 8; j += 2)
                {
                    Tire currentTire = new Tire(double.Parse(input[5 + j]), int.Parse(input[6 + j]));
                    currentTireSet[counter] = currentTire;
                    counter++;
                }
                Car currentCar = new Car(model, engine, cargo, currentTireSet);
                cars.Add(currentCar);
            }

            string command = Console.ReadLine();
            if (command == "fragile")
            {
                Console.WriteLine(string.Join(Environment.NewLine, cars.FindAll(c => c.Cargo.Type == "fragile" && c.Tires.Any(t => t.Pressure < 1))));
            }
            else if (command == "flammable")
            {
                Console.WriteLine(string.Join(Environment.NewLine, cars.FindAll(c => c.Cargo.Type == "flammable" && c.Engine.Power > 250)));
            }
        }
    }
}
