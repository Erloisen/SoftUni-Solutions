using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            Queue<int> numbers = new Queue<int>();

            for (int i = 0; i < inputNumbers.Length; i++)
            {
                if (inputNumbers[i] % 2 == 0)
                {
                    numbers.Enqueue(inputNumbers[i]);
                }
            }

            while (numbers.Count > 0)
            {
                Console.Write(numbers.Dequeue());

                if (numbers.Count >= 1)
                {
                    Console.Write(", ");
                }
            }
        }
    }
}
