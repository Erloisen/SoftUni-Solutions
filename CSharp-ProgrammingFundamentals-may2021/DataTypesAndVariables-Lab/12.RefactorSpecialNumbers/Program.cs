using System;

namespace _12._RefactorSpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                int currentDigit = i % 10;
                int previousDigit = (i / 10) % 10;

                Console.WriteLine($"{i} -> {(currentDigit + previousDigit == 5) || (currentDigit + previousDigit == 7) || (currentDigit + previousDigit == 11)}");
            }

        }
    }
}