using System;

namespace _10.LowerOrUpper
{
    class Program
    {
        static void Main(string[] args)
        {
            char character = char.Parse(Console.ReadLine());

            bool result = Char.IsUpper(character);

            if (result)
            {
                Console.WriteLine("upper-case");
            }
            else
            {
                Console.WriteLine("lower-case");
            }

        }
    }
}