using System;
using System.Linq;

namespace _02.KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();
            Action<string[]> knightsOfHonor = message => Console.WriteLine(string.Join("\n", message.Select(x => $"Sir {x}")));
            knightsOfHonor(names);
        }
    }
}
