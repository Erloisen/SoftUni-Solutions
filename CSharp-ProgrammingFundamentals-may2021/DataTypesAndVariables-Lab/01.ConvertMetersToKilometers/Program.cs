using System;

namespace _01.ConvertMetersToKilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            int metres = int.Parse(Console.ReadLine());

            decimal kilometres = (decimal)metres / 1000;
            //double kilometres = metres*1.0 / 1000;
            //double kilometres = metres / 1000.0f;

            Console.WriteLine($"{kilometres:f2}");
        }
    }
}
