using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] effects = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] caisings = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var bombEffects = new Queue<int>(effects);
            var bombCasings = new Stack<int>(caisings);
            var bombPouch = new SortedDictionary<string, int>()
            {
                { "Datura Bombs", 0 },
                { "Cherry Bombs", 0 },
                { "Smoke Decoy Bombs", 0 },
            };

            int bombType = 0;

            while (bombEffects.Count > 0 && bombCasings.Count > 0)
            {
                bombType = bombCasings.Peek() + bombEffects.Peek();
                bool isBombCreated = false;
                if (bombType == 40)
                {
                    bombPouch["Datura Bombs"] += 1;
                    isBombCreated = true;
                }
                else if (bombType == 60)
                {
                    bombPouch["Cherry Bombs"] += 1;
                    isBombCreated = true;
                }
                else if (bombType == 120)
                {
                    bombPouch["Smoke Decoy Bombs"] += 1;
                    isBombCreated = true;
                }
                
                if (isBombCreated)
                {
                    bombEffects.Dequeue();
                    bombCasings.Pop();
                }
                else
                {
                    int currentCasings = bombCasings.Pop();
                    currentCasings -= 5;
                    bombCasings.Push(currentCasings);
                }

                if (bombPouch.All(b => b.Value >= 3))
                {
                    Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
                    break;
                }
            }

            if (bombPouch.Any(b => b.Value < 3))
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (bombEffects.Count > 0)
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", bombEffects.ToArray())}");
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }

            if (bombCasings.Count > 0)
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasings.ToArray())}");
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            foreach (var bomb in bombPouch)
            {
                Console.WriteLine($"{bomb.Key}: {bomb.Value}");
            }
        }
    }
}
