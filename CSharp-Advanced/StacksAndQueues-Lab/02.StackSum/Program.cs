using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> numbers = new Stack<int>(inputNumbers);

            string command = Console.ReadLine().ToUpper();

            while (!command.Contains("END"))
            {
                string[] action = command.Split(" ");

                if (command.Contains("ADD"))
                {
                    numbers.Push(int.Parse(action[1]));
                    numbers.Push(int.Parse(action[2]));
                }

                if (command.Contains("REMOVE"))
                {
                    int count = int.Parse(action[1]);
                    if (numbers.Count >= count)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            numbers.Pop();
                        }
                    }
                }

                command = Console.ReadLine().ToUpper();
            }

            Console.WriteLine($"Sum: {numbers.Sum()}");
        }
    }
}
