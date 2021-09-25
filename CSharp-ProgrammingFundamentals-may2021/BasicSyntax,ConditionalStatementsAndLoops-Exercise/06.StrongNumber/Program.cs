using System;

namespace _06.StrongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int lastNum = number;
            int sumFact = 0;

            while (lastNum > 0)
            {
                int digit = lastNum % 10;
                int fact = 1;

                for (int j = 1; j <= digit; j++)
                {
                    fact *= j;
                }
                sumFact += fact;
                
                lastNum /= 10;
            }

            if (sumFact == number)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
