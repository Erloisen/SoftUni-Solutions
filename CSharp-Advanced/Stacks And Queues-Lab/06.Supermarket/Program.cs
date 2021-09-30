using System;
using System.Collections.Generic;

namespace _06.Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Queue<string> customers = new Queue<string>();

            while (input != "End")
            {
                if (input == "Paid")
                {
                    while (customers.Count > 0)
                    {
                        Console.WriteLine(customers.Dequeue());
                    }
                }
                else
                {
                    customers.Enqueue(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{customers.Count} people remaining.");
        }
    }
}
