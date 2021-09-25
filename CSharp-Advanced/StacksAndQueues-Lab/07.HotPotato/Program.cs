using System;
using System.Collections.Generic;

namespace _07.HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int n = int.Parse(Console.ReadLine());

            Queue<string> children = new Queue<string>(input);

            int counter = 0;

            while (children.Count > 1)
            {
                counter++;

                if (counter != n)
                {
                    children.Enqueue(children.Dequeue());
                }
                else
                {
                    Console.WriteLine($"Removed {children.Dequeue()}");
                    counter = 0;
                }
            }

            Console.WriteLine($"Last is {children.Dequeue()}");
        }
    }
}
