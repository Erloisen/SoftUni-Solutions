using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebration
{
    class Program
    {
        static void Main(string[] args)
        {
            var guests = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToList());
            var plates = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToList());

            int wastedFood = 0;
            while (guests.Count > 0 && plates.Count > 0)
            {
                var currentGuest = guests.Dequeue();
                while (currentGuest > 0)
                {
                    currentGuest -= plates.Pop();
                    if (currentGuest < 0)
                    {
                        wastedFood += Math.Abs(currentGuest);
                    }
                }
            }

            Console.WriteLine(guests.Count > 0 ?
                $"Guests: {string.Join(" ", guests.ToList())}" :
                $"Plates: {string.Join(" ", plates.ToList())}");
            Console.WriteLine($"Wasted grams of food: {wastedFood}"); 
        }
    }
}
