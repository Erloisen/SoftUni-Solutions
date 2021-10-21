using System;
using System.Collections.Generic;
using System.Linq;

namespace Masterchef
{
    class Program
    {
        static void Main(string[] args)
        {
            var ingredientsInBasket = new Queue<int>(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());
            var freshnessLevel = new Stack<int>(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());

            Dictionary<string, int> dishes = new Dictionary<string, int>
            {
                {"Dipping sauce", 0 },
                {"Green salad", 0 },
                {"Chocolate cake", 0 },
                {"Lobster", 0 },
            };

            while (ingredientsInBasket.Count > 0 && freshnessLevel.Count > 0)
            {
                var ingredient = ingredientsInBasket.Dequeue();
                var freshness = freshnessLevel.Pop();

                if (ingredient == 0)
                {
                    freshnessLevel.Push(freshness);
                    continue;
                }

                var letsCook = ingredient * freshness;

                if (letsCook == 150)
                {
                    dishes["Dipping sauce"] += 1;
                }
                else if (letsCook == 250)
                {
                    dishes["Green salad"] += 1;
                }
                else if (letsCook == 300)
                {
                    dishes["Chocolate cake"] += 1;
                }
                else if (letsCook == 400)
                {
                    dishes["Lobster"] += 1;
                }
                else
                {
                    ingredientsInBasket.Enqueue(ingredient + 5);
                }
            }

            Console.WriteLine(dishes.Any(d => d.Value < 1) ?
                    "You were voted off. Better luck next year." :
                    "Applause! The judges are fascinated by your dishes!");

            if (ingredientsInBasket.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {ingredientsInBasket.Sum()}");
            }

            foreach (var dish in dishes.OrderByDescending(d => d.Value).ThenBy(d => d.Key).Where(d => d.Value > 0))
            {
                Console.WriteLine($" # {dish.Key} --> {dish.Value}");
            }
        }
    }
}
