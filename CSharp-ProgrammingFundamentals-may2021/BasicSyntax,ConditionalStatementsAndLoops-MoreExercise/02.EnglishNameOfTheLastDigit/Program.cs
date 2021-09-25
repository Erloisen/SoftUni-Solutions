using System;

namespace _02.EnglishNameOfTheLastDigit
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int lastDigit = number % 10;
            
            string name = string.Empty;

            if (lastDigit == 0)
            {
                name = "zero";
            }
            else if (lastDigit == 1)
            {
                name = "one";
            }
            else if (lastDigit == 2)
            {
                name = "two";
            }
            else if (lastDigit == 3)
            {
                name = "three";
            }
            else if (lastDigit == 4)
            {
                name = "four";
            }
            else if (lastDigit == 5)
            {
                name = "five";
            }
            else if (lastDigit == 6)
            {
                name = "six";
            }
            else if (lastDigit == 7)
            {
                name = "seven";
            }
            else if (lastDigit == 8)
            {
                name = "eight";
            }
            else if (lastDigit == 9)
            {
                name = "nine";
            }

            Console.WriteLine(name);
        }
    }
}
