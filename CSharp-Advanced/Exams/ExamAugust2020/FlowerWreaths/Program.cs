using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            const int goalFlowerWreaths = 5;
            const int oneWreath = 15;

            var lilies = new Stack<int>(Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToList());
            var roses = new Queue<int>(Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToList());

            int countOfWreaths = 0;
            int storedFlowers = 0;

            while (lilies.Count > 0 && roses.Count > 0)
            {
                int lili = lilies.Pop();
                int rose = roses.Dequeue();
                
                if (oneWreath < (lili + rose))
                {
                    while ((lili + rose) > oneWreath)
                    {
                        lili -= 2;
                    }
                }

                if (oneWreath == (lili + rose))
                {
                    countOfWreaths++;
                    continue;
                }

                if (oneWreath > (lili + rose))
                {
                    storedFlowers += lili + rose;
                }
            }

            if (storedFlowers > oneWreath)
            {
                countOfWreaths += storedFlowers / oneWreath;
            }

            if (countOfWreaths >= goalFlowerWreaths)
            {
                Console.WriteLine($"You made it, you are going to the competition with {countOfWreaths} wreaths!");
            }
            else
            {
                int neededWreaths = goalFlowerWreaths - countOfWreaths;
                Console.WriteLine($"You didn't make it, you need {neededWreaths} wreaths more!");
            }
        }
    }
}
