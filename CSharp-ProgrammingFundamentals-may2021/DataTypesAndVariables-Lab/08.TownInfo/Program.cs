using System;

namespace _08.TownInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameTown = Console.ReadLine();
            int population = int.Parse(Console.ReadLine());
            int area = int.Parse(Console.ReadLine());

            Console.WriteLine($"Town {nameTown} has population of {population} and area {area} square km.");
        }
    }
}