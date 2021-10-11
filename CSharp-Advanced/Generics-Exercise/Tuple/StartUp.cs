using System;
using System.Linq;

namespace Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] personInputInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] personBeerInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] numbersInputInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string fullName = personInputInfo[0] + " " + personInputInfo[1];
            string address = personInputInfo[2];

            string name = personBeerInfo[0];
            int litersOfBeer = int.Parse(personBeerInfo[1]);

            int integerNumber = int.Parse(numbersInputInfo[0]);
            double doubleNumber = double.Parse(numbersInputInfo[1]);

            var personInfo = new MyTuple<string, string>(fullName, address);
            var personBeer = new MyTuple<string, int>(name, litersOfBeer);
            var numbersInfo = new MyTuple<int, double>(integerNumber, doubleNumber);

            Console.WriteLine(personInfo);
            Console.WriteLine(personBeer);
            Console.WriteLine(numbersInfo);
        }
    }
}
