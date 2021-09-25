using System;

namespace _03.FloatingEquality
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());

            double eps = 0.000001;

            double result = Math.Abs(a - b);
            
            if (result < eps)
            {
                Console.WriteLine(true);
            }
            else Console.WriteLine(false);
        }
    }
}
