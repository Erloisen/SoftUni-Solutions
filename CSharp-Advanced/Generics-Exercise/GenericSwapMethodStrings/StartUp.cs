using System;
using System.Linq;

namespace GenericSwapMethodStrings
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Box<int> box = new Box<int>();

            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());
                box.Values.Add(input);
            }

            int[] indexToSwap = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int a = indexToSwap[0];
            int b = indexToSwap[1];
            box.Swap(a, b);
            Console.WriteLine(box.ToString());
        }
    }
}
