using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstSet = new HashSet<int>();
            var secondSet = new HashSet<int>();
            int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int firstSetLenght = input[0];
            int secondSetLenght = input[1];
            int iLength = firstSetLenght + secondSetLenght;
            for (int i = 0; i < iLength; i++)
            {
                int numbers = int.Parse(Console.ReadLine());
                if (firstSetLenght > 0)
                {
                    firstSetLenght--;
                    firstSet.Add(numbers);
                }
                else
                {
                    secondSet.Add(numbers);
                }
            }

            firstSet.IntersectWith(secondSet);
            Console.WriteLine(string.Join(' ', firstSet));
        }
    }
}
