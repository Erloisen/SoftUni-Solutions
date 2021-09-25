using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> cupsCapacity = new Queue<int>(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());
            Stack<int> filledBottles = new Stack<int>(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());
            int wastedLittersOfWater = 0;

            while (cupsCapacity.Count > 0 && filledBottles.Count > 0)
            {
                if (filledBottles.Peek() >= cupsCapacity.Peek())
                {
                    wastedLittersOfWater += filledBottles.Pop() - cupsCapacity.Dequeue();
                }
                else
                {
                    int currentCupCapacity = cupsCapacity.Dequeue();
                    while (currentCupCapacity > 0)
                    {
                        currentCupCapacity -= filledBottles.Pop();
                    }

                    wastedLittersOfWater -= currentCupCapacity;
                }
            }

            Console.WriteLine(cupsCapacity.Count > 0 ?
                $"Cups: {string.Join(' ', cupsCapacity)}" :
                $"Bottles: {string.Join(' ', filledBottles)}");
            Console.WriteLine($"Wasted litters of water: {wastedLittersOfWater}");
        }
    }
}
