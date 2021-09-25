using System;

namespace _10.PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            int powerN = int.Parse(Console.ReadLine());
            int distanceM = int.Parse(Console.ReadLine());
            int exhaustionFactorY = int.Parse(Console.ReadLine());

            int targetCount = 0;
            int halfOfN = powerN / 2;

            while (powerN >= distanceM)
            {
                targetCount++;
                powerN -= distanceM;

                if (powerN == halfOfN && exhaustionFactorY > 0)
                {
                    powerN /= exhaustionFactorY;
                }
            }

            Console.WriteLine(powerN);
            Console.WriteLine(targetCount);
        }
    }
}
