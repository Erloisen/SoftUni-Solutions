using System;

namespace _08.BeerKegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double kegVolume = 0.0;
            string biggestModel = string.Empty;
            double biggestVolume = 0;

            for (int i = 0; i < n; i++)
            {
                string kegModel = Console.ReadLine();
                double kegRadius = double.Parse(Console.ReadLine());
                int kegHeight = int.Parse(Console.ReadLine());

                kegVolume = Math.PI * Math.Pow(kegRadius, 2) * kegHeight;

                if (kegVolume >= biggestVolume)
                {
                    biggestModel = kegModel;
                    biggestVolume = kegVolume;
                }
            }
            Console.WriteLine(biggestModel);
        }
    }
}
