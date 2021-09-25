using System;
using System.Linq;

namespace _04.ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string wordReversed = string.Join("", input.Reverse());

            //string wordReversed = string.Empty;

            //for (int i = input.Length - 1; i >= 0; i--)
            //{
            //    wordReversed += input[i];
            //}

            Console.WriteLine(wordReversed);
        }
    }
}
