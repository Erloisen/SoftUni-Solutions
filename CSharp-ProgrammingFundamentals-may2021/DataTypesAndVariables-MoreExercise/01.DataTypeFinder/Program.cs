using System;

namespace _01.DataTypeFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            while (input != "END")
            {
                bool isNumber = double.TryParse(input, out double number);

                if (isNumber)
                {
                    if (number % 1 == 0)
                    {
                        Console.WriteLine($"{number} is integer type");
                    }
                    else
                    {
                        Console.WriteLine($"{number} is floating point type");
                    }
                }
                else
                {
                    if (input.Length <= 1)
                    {
                        Console.WriteLine($"{input} is character type");
                    }
                    else if (input.ToLower() == "true" || input.ToLower() == "false")
                    {
                        Console.WriteLine($"{input} is boolean type");
                    }
                    else 
                    {
                        Console.WriteLine($"{input} is string type");
                    }
                }
                input = Console.ReadLine();
            } 
        }
    }
}
