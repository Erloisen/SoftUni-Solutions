using System;
using System.Collections.Generic;

namespace _06.ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var cars = new HashSet<string>();
            while (input != "END")
            {
                var parking = input.Split(", ");
                var goIn = parking[0];
                var carNumber = parking[1];
                if (goIn == "IN")
                {
                    cars.Add(carNumber);
                }
                else
                {
                    cars.Remove(carNumber);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(cars.Count > 0 ? string.Join("\n", cars) : "Parking Lot is Empty");
        }
    }
}
