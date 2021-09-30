using System;
using System.Collections.Generic;

namespace _05.RecordUniqueNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var names = new HashSet<string>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                names.Add(input);
            }

            Console.WriteLine(string.Join('\n', names));
        }
    }
}
