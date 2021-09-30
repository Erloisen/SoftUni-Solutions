using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] collection = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            string command;

            while ((command = Console.ReadLine()) != "end")
            {
                Func<int, int> func = null;
                if (command == "add")
                {
                    func = i => i += 1;
                }
                else if (command == "multiply")
                {
                    func = i => i *= 2;
                }
                else if (command == "subtract")
                {
                    func = i => i -= 1;
                }

                if (command == "print")
                {
                    Console.WriteLine(string.Join(" ", collection));
                }
                else
                {
                    collection = collection.Select(func).ToArray();
                }
            }
        }
    }
}
