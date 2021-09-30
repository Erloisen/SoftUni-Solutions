using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ").Reverse().ToArray();

            Stack<string> calcolation = new Stack<string>(input);

            while (calcolation.Count > 1)
            {
                int firstNum = int.Parse(calcolation.Pop());
                string action = calcolation.Pop();
                int secondNum = int.Parse(calcolation.Pop());

                if (action == "+")
                {
                    calcolation.Push((firstNum + secondNum).ToString());
                }
                else if (action == "-")
                {
                    calcolation.Push((firstNum - secondNum).ToString());
                }
            }

            Console.WriteLine(calcolation.Pop());
        }
    }
}
