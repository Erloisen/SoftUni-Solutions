using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> sequence = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                int[] queries = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int command = queries[0];

                if (command == 1)
                {
                    sequence.Push(queries[1]);
                }
                else if (command == 2 && sequence.Count > 0)
                {
                    sequence.Pop();
                }
                else if (command == 3 && sequence.Count > 0)
                {
                    Console.WriteLine(sequence.Max());
                }
                else if (command == 4 && sequence.Count > 0)
                {
                    Console.WriteLine(sequence.Min());
                }
            }

            Console.WriteLine(string.Join(", ", sequence));
        }
    }
}
