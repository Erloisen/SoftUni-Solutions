using System;

namespace _01.SquareRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            try
            {
                ValidateNumber(input);
                double squareRootNumber = Math.Sqrt(int.Parse(input));
                Console.WriteLine(squareRootNumber);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException argex)
            {
                Console.WriteLine(argex.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye");
            }
        }

        private static void ValidateNumber(string input)
        {
            int number;
            if (!int.TryParse(input, out number))
            {
                throw new FormatException("Invalid number");
            }

            if (number < 0)
            {
                throw new ArgumentException("Invalid number");
            }
        }
    }
}
