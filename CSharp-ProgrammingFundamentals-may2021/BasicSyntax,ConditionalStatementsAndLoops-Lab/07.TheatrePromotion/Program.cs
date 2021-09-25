﻿using System;

namespace _07.TheatrePromotion
{
    class Program
    {
        static void Main(string[] args)
        {
            string day = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            int price = 0;

            if (age < 0 || age > 122)
            {
                Console.WriteLine("Error!");
                return;
            }
            if (day == "Weekday")
            {
                if (age <= 18 || age > 64)
                {
                    price = 12;
                }
                if (age > 18 && age <= 64)
                {
                    price = 18;
                }
            }
            if (day == "Weekend")
            {
                if (age <= 18 || age > 64)
                {
                    price = 15;
                }
                if (age > 18 && age <= 64)
                {
                    price = 20;
                }
            }
            if (day == "Holiday")
            {
                if (age <= 18)
                {
                    price = 5;
                }
                if (age > 64)
                {
                    price = 10;
                }
                if (age > 18 && age <= 64)
                {
                    price = 12;
                }
            }
            Console.WriteLine($"{price}$");
        }
    }
}
