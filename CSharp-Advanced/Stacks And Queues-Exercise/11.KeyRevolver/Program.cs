using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int priceOfEachBullet = int.Parse(Console.ReadLine());
            int sizeOfTheGunBarrel = int.Parse(Console.ReadLine());
            Stack<int> bullets = new Stack<int>(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());
            Queue<int> locks = new Queue<int>(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());
            int valueOfTheIntelligence = int.Parse(Console.ReadLine());

            int reloading = sizeOfTheGunBarrel;
            int bulletsCount = 0;

            while (bullets.Count > 0 && locks.Count > 0)
            {
                reloading--;
                bulletsCount++;
                bool isBang = bullets.Pop() <= locks.Peek();
                Console.WriteLine(isBang ? "Bang!" : "Ping!");
                
                if (isBang)
                {
                    locks.Dequeue();
                }

                if (reloading == 0 && bullets.Count > 0)
                {
                    reloading = sizeOfTheGunBarrel;
                    Console.WriteLine("Reloading!");
                }
            }

            Console.WriteLine(locks.Count == 0 ?
                $"{bullets.Count} bullets left. Earned ${valueOfTheIntelligence -= (bulletsCount * priceOfEachBullet)}" :
                $"Couldn't get through. Locks left: {locks.Count}");
        }
    }
}
