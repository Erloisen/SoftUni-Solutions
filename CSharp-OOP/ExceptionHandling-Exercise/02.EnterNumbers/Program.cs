using System;

namespace _02.EnterNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            for (int i = 0; i < 10; i++)
            {
                try
                {
                    int number = ReadNumber(start, end);
                }
                catch (ArgumentNullException)
                {
                    i--;
                }
                catch (FormatException)
                {
                    i--;
                }
                catch(ArgumentOutOfRangeException)
                {
                    i--;
                }
            }
        }

        private static int ReadNumber(int start, int end)
        {
            string numberInput = Console.ReadLine();

            ValidateNumber(numberInput, start, end);

            return int.Parse(numberInput);
        }

        private static void ValidateNumber(string numberInput, int start, int end)
        {
            if (string.IsNullOrWhiteSpace(numberInput))
            {
                throw new ArgumentNullException();
            }

            int number;

            if (!int.TryParse(numberInput, out number))
            {
                throw new FormatException();
            }

            if (number < start || number > end)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}
