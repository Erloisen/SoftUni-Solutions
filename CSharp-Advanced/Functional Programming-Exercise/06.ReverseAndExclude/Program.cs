using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());

            Predicate<int> isDivisible = i => i % n == 0;
            Func<int[], Predicate<int>, int[]> removeIfTrue = (ints, predicat) => ints.Where(i => !predicat(i)).ToArray();
            Func<int[], int[]> reverse = i => i.Reverse().ToArray();

            input = removeIfTrue(input, isDivisible);
            input = reverse(input);
            Console.WriteLine(string.Join(" ", input));
        }
    }
}
