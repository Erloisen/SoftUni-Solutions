using System;
using System.Collections.Generic;

namespace _03.ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            var products = new SortedDictionary<string, Dictionary<string, double>>();
            while (true)
            {
                var line = Console.ReadLine();
                if (line == "Revision")
                {
                    break;
                }

                var parts = line.Split(", ");
                var supermarket = parts[0];
                var productName = parts[1];
                var price = double.Parse(parts[2]);

                if (!products.ContainsKey(supermarket))
                {
                    products.Add(supermarket, new Dictionary<string, double>());
                }

                if (!products[supermarket].ContainsKey(productName))
                {
                    products[supermarket].Add(productName, price);
                }
                else
                {
                    products[supermarket][productName] = price;
                }
            }

            foreach (var supermarket in products)
            {
                Console.WriteLine($"{supermarket.Key}->");
                foreach (var product in supermarket.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
