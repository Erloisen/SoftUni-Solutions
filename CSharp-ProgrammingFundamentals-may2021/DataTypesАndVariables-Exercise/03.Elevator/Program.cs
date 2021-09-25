using System;

namespace _03.Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int elevatePersons = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());

            double courses = Math.Ceiling((double)elevatePersons / capacity);

            Console.WriteLine(courses);
        }
    }
}
