using System;

namespace Restaurant
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Beverage cola = new Beverage("Coca-Cola", 1, 500);
            Console.WriteLine($"Type of drink:{cola.Name}, Price:{cola.Price}, Milliliters:{cola.Milliliters}");
            Cake myCake = new Cake("BlackShugar");
            Console.WriteLine(myCake.Price);
        }
    }
}