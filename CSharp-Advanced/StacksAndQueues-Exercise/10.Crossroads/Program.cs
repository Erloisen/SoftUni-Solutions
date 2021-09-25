using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int durationOfTheGreenLight = int.Parse(Console.ReadLine());
            int durationOfTheFreeWindow = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();

            Queue<string> queueTrafic = new Queue<string>();
            int countPassedCars = 0;

            while (command != "END")
            {
                if (command != "green")
                {
                    queueTrafic.Enqueue(command);
                }
                else
                {
                    int timeToPassed = durationOfTheGreenLight;

                    while (queueTrafic.Count > 0 && timeToPassed > 0)
                    {
                        string cars = queueTrafic.Dequeue();

                        if (cars.Length <= timeToPassed + durationOfTheFreeWindow)
                        {
                            timeToPassed -= cars.Length;
                            countPassedCars++;
                        }
                        else if (cars.Length > timeToPassed + durationOfTheFreeWindow)
                        {
                            Console.WriteLine($"A crash happened!{Environment.NewLine}{cars} was hit at {cars[timeToPassed + durationOfTheFreeWindow]}.");
                            return;
                        }
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Everyone is safe.{Environment.NewLine}{countPassedCars} total cars passed the crossroads.");
        }
    }
}
