using System;
using System.Collections.Generic;

namespace _04.CitiesByContinentAndCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            var cities = new Dictionary<string, Dictionary<string, List<string>>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var lineParts = Console.ReadLine().Split(' ');
                var continents = lineParts[0];
                var country = lineParts[1];
                var city = lineParts[2];
                if (!cities.ContainsKey(continents))
                {
                    cities.Add(continents, new Dictionary<string, List<string>>());
                }

                if (!cities[continents].ContainsKey(country))
                {
                    cities[continents][country] = new List<string>();
                }

                cities[continents][country].Add(city);
            }

            foreach (var continent in cities)
            {
                Console.WriteLine($"{continent.Key}:");
                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"  {country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}
