using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Array.Sort(array, new MyComparator());
            Console.WriteLine(string.Join(" ", array));
        }

        class MyComparator : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                int compare = Math.Abs(x % 2).CompareTo(Math.Abs(y % 2));
                if (compare == 0)
                {
                    compare = x.CompareTo(y);
                }

                return compare;
            }
        }
    }
}
