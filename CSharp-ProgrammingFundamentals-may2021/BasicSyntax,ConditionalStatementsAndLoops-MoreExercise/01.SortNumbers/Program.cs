using System;

namespace _01.SortNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            int big = 0;
            int mid = 0;
            int small = 0;

            if (num1 >= num2  && num1 >= num3)
            {
                big = num1;
            }
            else if ((num1 >= num2 && num1 < num3) || (num1 < num2 && num1 >= num3 ))
            {
                mid = num1;
            }
            else if (num1 < num2 && num1 < num3)
            {
                small = num1;
            }

            if (num2 >= num1 && num2 >= num3)
            {
                big = num2;
            }
            else if (num2 >= num1 && num2 < num3 || (num2 < num1 && num2 >= num3))
            {
                mid = num2;
            }
            else if (num2 < num1 && num2 < num3)
            {
                small = num2;
            }

            if (num3 >= num1 && num3 >= num2)
            {
                big = num3;
            }
            else if ((num3 >= num1 && num3 < num2) || (num3 < num1 && num3 >= num2))
            {
                mid = num3;
            }
            else if (num3 < num1 && num3 < num2)
            {
                small = num3;
            }

            if (num1 == num2 && num1 > num3)
            {
                big = num1;
                mid = num2;
                small = num3;
            }

            if (num1 == num2 && num1 < num3)
            {
                big = num3;
                mid = num1;
                small = num2;
            }

            if (num2 == num3 && num2 > num1)
            {
                big = num2;
                mid = num3;
                small = num1;
            }

            if (num2 == num3 && num2 < num1)
            {
                big = num1;
                mid = num2;
                small = num3;
            }

            if (num1 == num3 && num1 > num2)
            {
                big = num1;
                mid = num3;
                small = num2;
            }

            if (num1 == num3 && num1 < num2)
            {
                big = num2;
                mid = num1;
                small = num3;
            }

            if (num1 == num2 && num2 == num3 && num1 == num3)
            {
                big = num1;
                mid = num2;
                small = num3;
            }
            Console.WriteLine(big);
            Console.WriteLine(mid);
            Console.WriteLine(small);
        }
    }
}
