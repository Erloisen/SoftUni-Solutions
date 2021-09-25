using System;

namespace Explanation
{
    class Program
    {
        static void Main(string[] args)
        {
            int clicks = int.Parse(Console.ReadLine());

            string message = string.Empty;

            for (int i = 0; i < clicks; i++)
            {
                string digits = Console.ReadLine();
                int digitsLength = digits.Length;
                int digit = digits[0] - '0'; //find the main digit exm. 444 -> 4
                //int digitNum = int.Parse(digits);
                //int digit = digitNum % 10;
                int offset = (digit - 2) * 3;

                if (digit == 0)
                {
                    message += (char)(digit + 32);
                    continue;
                }

                if (digit == 8 || digit == 9)
                {
                    offset++;
                }

                int letterIndex = offset + digitsLength - 1;
                message += (char)(letterIndex + 97);
            }

            Console.WriteLine(message);
        }
    }
}
