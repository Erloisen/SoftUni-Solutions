using System;
using System.Linq;

namespace _07.PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Predicate<string> lessLenght = i => i.Length <= n;
            Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .FindAll(lessLenght)
                .ForEach(Console.WriteLine);
        }
    }
}
