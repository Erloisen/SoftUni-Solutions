using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int sElementPop = commands[1];
            int xContainsStuck = commands[2];

            int[] n = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> numbers = new Stack<int>(n);

            
            for (int i = 0; i < sElementPop; i++)
            {
                numbers.Pop();
            }

            if (numbers.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if(numbers.Contains(xContainsStuck))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(numbers.Min());
            }
        }
    }
}
