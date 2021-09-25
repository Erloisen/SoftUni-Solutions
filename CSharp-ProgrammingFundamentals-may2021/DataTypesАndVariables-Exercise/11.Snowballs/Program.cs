using System;
using System.Numerics;

namespace _11.Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int currentSnow = 0;
            BigInteger currentTime = 0;
            int currentQuality = 0;
            BigInteger currentValue = 0;

            for (int i = 0; i < n; i++)
            {
                int snow = int.Parse(Console.ReadLine());
                BigInteger time = BigInteger.Parse(Console.ReadLine());
                int quality = int.Parse(Console.ReadLine());

                BigInteger value = BigInteger.Pow((snow / time), quality);
                
                if (currentValue <= value)
                {
                    currentValue = value;
                    currentSnow = snow;
                    currentTime = time;
                    currentQuality = quality;
                }
            }

            Console.WriteLine($"{currentSnow} : {currentTime} = {currentValue} ({currentQuality})");
        }
    }
}
