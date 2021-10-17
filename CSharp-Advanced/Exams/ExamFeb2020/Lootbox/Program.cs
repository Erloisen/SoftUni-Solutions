using System;
using System.Collections.Generic;
using System.Linq;

namespace Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstLootBox = new Queue<int>(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());
            var secondLootBox = new Stack<int>(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());

            int claimedItems = 0;

            while (firstLootBox.Count > 0 && secondLootBox.Count > 0)
            {
                var sumItems = firstLootBox.Peek() + secondLootBox.Peek();

                if (sumItems % 2 == 0)
                {
                    claimedItems += sumItems;
                    firstLootBox.Dequeue();
                    secondLootBox.Pop();
                }
                else
                {
                    firstLootBox.Enqueue(secondLootBox.Pop());
                }
            }

            if (firstLootBox.Count == 0 && secondLootBox.Count > 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else if (firstLootBox.Count > 0 && secondLootBox.Count == 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (claimedItems >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItems}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItems}");
            }
        }
    }
}
