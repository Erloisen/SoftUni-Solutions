using System;

namespace _04.SumOfChars
{
    class Program
    {
        static void Main(string[] args)
        {
            int nChars = int.Parse(Console.ReadLine());

            int sum = 0;

            for (int i = 0; i < nChars; i++)
            {
                char ch = char.Parse(Console.ReadLine());
                sum += (int)ch;
            }

            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}
