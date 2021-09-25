using System;

namespace _09.CharToString
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstOne = char.Parse(Console.ReadLine());
            char secondOne = char.Parse(Console.ReadLine());
            char thirdOne = char.Parse(Console.ReadLine());

            Console.WriteLine($"{firstOne}{secondOne}{thirdOne}");
        }
    }
}