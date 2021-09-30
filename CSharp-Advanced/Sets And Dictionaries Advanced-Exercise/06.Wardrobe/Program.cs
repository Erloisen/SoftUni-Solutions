using System;
using System.Collections.Generic;

namespace _06.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            var wardrobe = new Dictionary<string, Dictionary<string, int>>();
            int lines = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < lines; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = input[0];
                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                string[] clothes = input[1].Split(',');
                for (int j = 0; j < clothes.Length; j++)
                {
                    if (!wardrobe[color].ContainsKey(clothes[j]))
                    {
                        wardrobe[color].Add(clothes[j], 1);
                    }
                    else
                    {
                        wardrobe[color][clothes[j]] += 1; 
                    }
                }
            }

            string[] pieceOfClothing = Console.ReadLine().Split(' ');
            string colorToFound = pieceOfClothing[0];
            string clothesToFound = pieceOfClothing[1];

            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");
                foreach (var clothes in color.Value)
                {
                    if (color.Key == colorToFound && clothes.Key == clothesToFound)
                    {
                        Console.WriteLine($"* {clothes.Key} - {clothes.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {clothes.Key} - {clothes.Value}");
                    }
                }
            }
        }
    }
}
