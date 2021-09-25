using System;

namespace _02.FromLeftToTheRight
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string number = string.Empty;
                string leftString = string.Empty;

                for (char j = '0'; j < input.Length; j++)
                {
                    if (input[j] != ' ')
                    {
                        number += input[j];
                    }
                    else
                    {
                        leftString = number;
                        number = string.Empty;
                    }
                }

                long leftNumber = long.Parse(leftString);
                long rightNumber = long.Parse(number);
                long sum = 0;
                
                if (leftNumber > rightNumber)
                {
                    for (long k = Math.Abs(leftNumber); k > 0; k /= 10)
                    {
                        sum += k % 10;
                    }
                }
                else
                {
                    for (long l = Math.Abs(rightNumber); l > 0; l /= 10)
                    {
                        sum += l % 10;
                    }
                }

                Console.WriteLine(sum);
            }
        }
    }
}
