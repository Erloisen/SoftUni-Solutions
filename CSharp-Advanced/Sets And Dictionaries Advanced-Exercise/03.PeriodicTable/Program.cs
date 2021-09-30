using System;
using System.Collections.Generic;

namespace _03.PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputLines = int.Parse(Console.ReadLine());
            var elements = new SortedSet<string>();
            for (int i = 0; i < inputLines; i++)
            {
                string[] chemicalCompounds = Console.ReadLine().Split();
                for (int j = 0; j < chemicalCompounds.Length; j++)
                {
                    elements.Add(chemicalCompounds[j]);
                }
            }

            Console.WriteLine(string.Join(" ", elements));
        }
    }
}
