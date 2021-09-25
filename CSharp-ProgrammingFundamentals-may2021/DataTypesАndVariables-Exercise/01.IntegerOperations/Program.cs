using System;

namespace _01.IntegerOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());
            int num4 = int.Parse(Console.ReadLine());

            //int sum = num1 + num2;
            //double divideSum = sum / num3;
            //double multipleDivide = divideSum * num4;
            double result = ((num1 + num2) / num3) * num4;
            Console.WriteLine(result);
        }
    }
}
