using System;
using System.Linq;

namespace _09.ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int, int, bool> isDivisible = (i, j) => i % j == 0;

            for (int i = 1; i <= n; i++)
            {
                bool divisible = true;
                foreach (var item in dividers)
                {
                    if (!isDivisible(i, item))
                    {
                        divisible = false;
                        break;
                    }
                }

                if (divisible)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
