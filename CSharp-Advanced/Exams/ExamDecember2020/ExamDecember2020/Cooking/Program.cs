using System;
using System.Collections.Generic;
using System.Linq;

namespace Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            const int bread = 25;
            const int cake = 50;
            const int pastry = 75;
            const int fruitPie = 100;

            var liquids = new Queue<int>(Console.ReadLine().Split(' ').Select(int.Parse).ToList());
            var ingredients = new Stack<int>(Console.ReadLine().Split(' ').Select(int.Parse).ToList());

            var foods = new SortedDictionary<string, int>()
            {
                { "Bread", 0 },
                { "Cake", 0 },
                { "Pastry", 0 },
                { "Fruit Pie", 0 },
            };

            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                var liquid = liquids.Dequeue();
                var ingredient = ingredients.Peek();
                var product = liquid + ingredient;

                if (product == bread)
                {
                    foods["Bread"] += 1;
                    ingredients.Pop();
                }
                else if (product == cake)
                {
                    foods["Cake"] += 1;
                    ingredients.Pop();
                }
                else if (product == pastry)
                {
                    foods["Pastry"] += 1;
                    ingredients.Pop();
                }
                else if (product == fruitPie)
                {
                    foods["Fruit Pie"] += 1;
                    ingredients.Pop();
                }
                else
                {
                    ingredient = ingredients.Pop() + 3;
                    ingredients.Push(ingredient);
                }
            }

            if (foods.Any(f => f.Value == 0))
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }
            else
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }

            if (liquids.Count > 0)
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if (ingredients.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
            }
            else
            {
                Console.WriteLine("Ingredients left: none");
            }

            foreach (var food in foods)
            {
                Console.WriteLine($"{food.Key}: {food.Value}");
            }
        }
    }
}
