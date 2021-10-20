using System;
using System.Collections.Generic;
using System.Linq;

namespace WarmWinter
{
    class Program
    {
        static void Main(string[] args)
        {
            var hats = new Stack<int>(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());
            var scarfs = new Queue<int>(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());

            var set = new List<int>();
            while (hats.Count > 0 && scarfs.Count > 0)
            {
                var newSet = 0;
                if (hats.Peek() > scarfs.Peek())
                {
                    newSet = hats.Pop() + scarfs.Dequeue();
                    set.Add(newSet);
                }
                else if (scarfs.Peek() > hats.Peek())
                {
                    hats.Pop();
                }
                else
                {
                    scarfs.Dequeue();
                    hats.Push(hats.Pop() + 1);
                }
            }

            Console.WriteLine($"The most expensive set is: {set.OrderByDescending(s => s).First()}");
            Console.WriteLine(string.Join(" ", set));
        }
    }
}
