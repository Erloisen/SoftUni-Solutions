using System;
using System.Collections.Generic;

namespace _08.TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();

            string inputCar = string.Empty;
            int counter = 0;

            while ((inputCar = Console.ReadLine()) != "end")
            {
                if (inputCar != "green")
                {
                    cars.Enqueue(inputCar);
                }
                else
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (cars.Count == 0)
                        {
                            break;
                        }
                        
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                        counter++;
                    }
                }
            }

            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}
