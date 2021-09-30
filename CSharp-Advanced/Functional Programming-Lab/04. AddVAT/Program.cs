using System;
using System.Linq;

namespace _04._AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            var pricesWithAddVAT = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(x => x * 1.20);
            Console.WriteLine(string.Join("\n", pricesWithAddVAT.Select(x => $"{x:f2}")));
        }
    }
}
