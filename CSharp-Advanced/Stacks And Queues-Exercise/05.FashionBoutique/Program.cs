using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothesInBox = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int capasityOfRack = int.Parse(Console.ReadLine());

            Stack<int> purpose = new Stack<int>(clothesInBox);

            int sum = 0;
            int racks = 1;

            while (purpose.Count > 0)
            {
                if ((sum + purpose.Peek()) <= capasityOfRack)
                {
                    sum += purpose.Pop();
                }
                else
                {
                    sum = 0;
                    sum += purpose.Pop();
                    racks++;
                }
            }

            Console.WriteLine(racks);
        }
    }
}
