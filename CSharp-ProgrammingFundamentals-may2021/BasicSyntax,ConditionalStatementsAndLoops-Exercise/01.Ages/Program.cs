using System;

namespace _01.Ages
{
    class Program
    {
        static void Main(string[] args)
        {
            int ages = int.Parse(Console.ReadLine());

            if (ages <= 2)
            {
                Console.WriteLine("baby");
            }
            else if (ages >= 3 && ages <= 13)
            {
                Console.WriteLine("child");
            }
            else if (ages >= 14 && ages <= 19)
            {
                Console.WriteLine("teenager");
            }
            else if (ages >= 20 && ages <= 65)
            {
                Console.WriteLine("adult");
            }
            else if (ages >= 66)
            {
                Console.WriteLine("elder");
            }
        }
    }
}
