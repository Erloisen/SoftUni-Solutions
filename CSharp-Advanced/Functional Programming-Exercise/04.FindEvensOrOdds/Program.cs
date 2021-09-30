using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] bound = Console.ReadLine().Split().Select(int.Parse).ToArray();
            List<int> listNumbers = new List<int>();
            for (int i = bound[0]; i <= bound[1]; i++)
            {
                listNumbers.Add(i);
            }

            Predicate<int> predicate = null;
            switch (Console.ReadLine())
            {
                case "even":
                    predicate = i => i % 2 == 0;
                    break;
                case "odd":
                    predicate = i => i % 2 != 0;
                    break;
            }

            Console.WriteLine(string.Join(" ", listNumbers.FindAll(predicate)));
        }
    }
}
