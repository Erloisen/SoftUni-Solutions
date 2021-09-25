using System;

namespace _10.SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());
            
            int sum = 0;
            int days = 0;

            while (startingYield >= 100)
            {
                int spice = startingYield;
                spice -= 26;
                sum += spice;
                startingYield -= 10;
                days++;
            }

            if (days > 0)
            {
                sum -= 26;
            }

            Console.WriteLine(days);
            Console.WriteLine(sum);
        }
    }
}
