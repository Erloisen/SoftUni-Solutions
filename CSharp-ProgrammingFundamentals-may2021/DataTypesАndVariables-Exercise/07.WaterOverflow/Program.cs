using System;

namespace _07.WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                int litersToFill = int.Parse(Console.ReadLine());

                if (sum + litersToFill > 255)
                {
                    Console.WriteLine("Insufficient capacity!");
                    continue;
                }

                sum += litersToFill;
            }
            Console.WriteLine(sum);
        }
    }
}
