using System;
using System.Linq;

namespace _03.CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> min = arrayNumbers =>
            {
                int minNumber = int.MaxValue;
                foreach (var number in arrayNumbers)
                {
                    if (minNumber > number)
                    {
                        minNumber = number;
                    }
                }

                return minNumber;
            };

            Console.WriteLine(min(Console.ReadLine().Split().Select(int.Parse).ToArray()));
        }
    }
}
