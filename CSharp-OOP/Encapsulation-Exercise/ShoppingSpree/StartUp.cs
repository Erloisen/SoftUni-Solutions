using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var persons = new Dictionary<string, Person>();
            var products = new Dictionary<string, Product>();

            try
            {
                persons = GettingPersonInfo();
                products = GettingProductInfo();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }   

            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] commandInfo = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string personName = commandInfo[0];
                string productName = commandInfo[1];

                var person = persons[personName];
                var product = products[productName];

                try
                {
                    person.BuyProduct(product);
                    Console.WriteLine($"{personName} bought {productName}");
                }
                catch (InvalidOperationException ex)
                {

                    Console.WriteLine(ex.Message);
                }
                
                command = Console.ReadLine();
            }

            foreach (var person in persons.Values)
            {
                Console.WriteLine(person);
            }
        }

        private static Dictionary<string, Person> GettingPersonInfo()
        {
            var result = new Dictionary<string, Person>();
            string[] inputLine = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            foreach (var person in inputLine)
            {
                string[] inputInfo = person.Split('=', StringSplitOptions.RemoveEmptyEntries);
                string name = inputInfo[0];
                double money = double.Parse(inputInfo[1]);

                result[name] = new Person(name, money);

            }

            return result;
        }

        private static Dictionary<string, Product> GettingProductInfo()
        {
            var result = new Dictionary<string, Product>();
            string[] inputLine = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            foreach (var product in inputLine)
            {
                string[] inputInfo = product.Split('=', StringSplitOptions.RemoveEmptyEntries);
                string name = inputInfo[0];
                double money = double.Parse(inputInfo[1]);

                result[name] = new Product(name, money);
            }

            return result;
        }
    }
}
