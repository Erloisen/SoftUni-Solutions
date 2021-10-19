using System;
using System.Collections.Generic;
using System.Linq;

namespace TheFightForGondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfWaves = int.Parse(Console.ReadLine());
            Queue<int> plates = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToList());
            Stack<int> waveOfOrcs = null;
            int currentPlate = 0;

            for (int i = 1; i <= numberOfWaves; i++)
            {
                if (plates.Count > 0)
                {
                    waveOfOrcs = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
                }
                else
                {
                    break;
                }

                if (i % 3 == 0)
                {
                    plates.Enqueue(int.Parse(Console.ReadLine()));
                }

                while (plates.Count > 0 && waveOfOrcs.Count > 0)
                {
                    if (currentPlate == 0)
                    {
                        currentPlate = plates.Dequeue();
                    }
                    
                    int currentOrc = waveOfOrcs.Pop();

                    if (currentPlate >= currentOrc)
                    {
                        currentPlate -= currentOrc;
                    }
                    else if (currentPlate < currentOrc)
                    {
                        currentOrc -= currentPlate;
                        currentPlate = 0;
                        waveOfOrcs.Push(currentOrc);
                    }

                    if (plates.Count == 0 && currentPlate > 0)
                    {
                        plates.Enqueue(currentPlate);
                        currentPlate = 0;
                    }
                }  
            }

            if (plates.Count > 0)
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine(currentPlate > 0 ? 
                        $"Plates left: {currentPlate}, {string.Join(", ", plates)}" :
                        $"Plates left: {string.Join(", ", plates)}");
            }
            else
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", waveOfOrcs)}");
            }
        }
    }
}
