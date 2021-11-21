using System;
using System.Linq;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] truckInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] busInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Car car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), int.Parse(carInfo[3]));
            Truck truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), int.Parse(truckInfo[3]));
            Bus bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), int.Parse(busInfo[3]));

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] inputInfo = Console.ReadLine().Split();
                string option = inputInfo[0];
                string vehicle = inputInfo[1];
                double value = double.Parse(inputInfo[2]);

                switch (option)
                {
                    case "Drive":
                        if (vehicle == nameof(Car))
                        {
                            car.Driven(value);
                        }
                        else if (vehicle == nameof(Truck))
                        {
                            truck.Driven(value);
                        }
                        else if (vehicle == nameof(Bus))
                        {
                            bus.Driven(value);
                        }
                        break;
                    case "DriveEmpty":
                        bus.Driven(value, "empty");
                        break;
                    case "Refuel":
                        if (vehicle == nameof(Car))
                        {
                            car.Refueled(value);
                        }
                        else if (vehicle == nameof(Truck))
                        {
                            truck.Refueled(value);
                        }
                        else if (vehicle == nameof(Bus))
                        {
                            bus.Refueled(value);
                        }
                        break;
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");                                               
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");

            /*
            string[] carInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);        ||
            string[] truckInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);      ||
            Vehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]));                      ||
            Vehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));              ||
                                                                                                            ||
            int n = int.Parse(Console.ReadLine());                                                          ||
                                                                                                            ||
            for (int i = 0; i < n; i++)                                                                     ||
            {                                                                                               ||
                string[] inputInfo = Console.ReadLine().Split();                                            ||
                string option = inputInfo[0];                                                               ||
                string vehicle = inputInfo[1];                                                              ||
                                                                                                            ||
                switch (option)                                                                             ||
                {                                                                                           ||
                    case "Drive":                                                                           ||
                        double distance = double.Parse(inputInfo[2]);                                       ||
                        if (vehicle == "Car")                                                               ||
                        {                                                                                   ||
                            car.Driven(distance);                                                           ||
                        }                                                                                   ||
                        else                                                                                ||01.Vehicles
                        {                                                                                   ||
                            truck.Driven(distance);                                                         ||
                        }                                                                                   ||
                        break;                                                                              ||
                    case "Refuel":                                                                          ||
                        double liters = double.Parse(inputInfo[2]);                                         ||
                        if (vehicle == "Car")                                                               ||
                        {                                                                                   ||
                            car.Refueled(liters);                                                           ||
                        }                                                                                   ||
                        else                                                                                ||
                        {                                                                                   ||
                            truck.Refueled(liters);                                                         ||
                        }                                                                                   ||
                        break;                                                                              ||
                }                                                                                           ||
            }                                                                                               ||
                                                                                                            ||
            Console.WriteLine($"Car: {car.FuelQuantity:f2}");                                               ||
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");                                           ||
            */
        }
    }
}
