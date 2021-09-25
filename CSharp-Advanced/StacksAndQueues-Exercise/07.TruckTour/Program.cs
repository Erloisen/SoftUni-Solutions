using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPumps = int.Parse(Console.ReadLine());

            Queue<string> tourCircle = new Queue<string>();

            for (int i = 0; i < numberOfPumps; i++)
            {
                string petrolPumps = Console.ReadLine();
                petrolPumps += $" {i}";
                tourCircle.Enqueue(petrolPumps);
            }

            int totalFuel = 0;

            for (int i = 0; i < numberOfPumps; i++)
            {
                string currentInfo = tourCircle.Dequeue();
                int[] info = currentInfo.Split(" ").Select(int.Parse).ToArray();

                int fuel = info[0];
                int distance = info[1];

                totalFuel += fuel;

                if (totalFuel >= distance)
                {
                    totalFuel -= distance;
                }
                else
                {
                    totalFuel = 0;
                    i = -1;
                }

                tourCircle.Enqueue(currentInfo);
            }

            string[] index = tourCircle.Dequeue().Split(" ").ToArray();
            Console.WriteLine(index[2]);
        }
    }
}
