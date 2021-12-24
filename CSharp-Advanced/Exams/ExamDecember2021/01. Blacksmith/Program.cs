using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blacksmith
{
    class Program
    {
        static void Main(string[] args)
        {
            const int gladius = 70;
            const int shamshir = 80;
            const int katana = 90;
            const int sabre = 110;
            const int broadsword = 150;

            int[] inputSteel = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] inputCarbon = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Queue<int> steel = new Queue<int>(inputSteel);
            Stack<int> carbon = new Stack<int>(inputCarbon);
            SortedDictionary<string, int> swords = new SortedDictionary<string, int>
            {
                { "Gladius", 0 },
                { "Shamshir", 0 },
                { "Katana", 0 },
                { "Sabre", 0 },
                { "Broadsword", 0 },
            };
            
            while (steel.Count > 0 && carbon.Count > 0)
            {
                int currentSteel = steel.Dequeue();
                int currentCarbon = carbon.Pop();

                if (currentCarbon + currentSteel == gladius)
                {
                    swords["Gladius"]++;
                }
                else if (currentCarbon + currentSteel == shamshir)
                {
                    swords["Shamshir"]++;
                }
                else if (currentCarbon + currentSteel == katana)
                {
                    swords["Katana"]++;
                }
                else if (currentCarbon + currentSteel == sabre)
                {
                    swords["Sabre"]++;
                }
                else if (currentCarbon + currentSteel == broadsword)
                {
                    swords["Broadsword"]++;
                }
                else
                {
                    currentCarbon += 5;
                    carbon.Push(currentCarbon);
                }
            }

            int totalNumberOfSwords = swords.Values.Sum();

            StringBuilder sb = new StringBuilder();

            if (totalNumberOfSwords > 0)
            {
                sb.AppendLine($"You have forged {totalNumberOfSwords} swords.");
            }
            else
            {
                sb.AppendLine("You did not have enough resources to forge a sword.");
            }

            if (steel.Count > 0)
            {
                sb.AppendLine($"Steel left: {string.Join(", ", steel.ToArray())}");
            }
            else
            {
                sb.AppendLine("Steel left: none");
            }

            if (carbon.Count > 0)
            {
                sb.AppendLine($"Carbon left: {string.Join(", ", carbon.ToArray())}");
            }
            else
            {
                sb.AppendLine("Carbon left: none");
            }

            foreach (var sword in swords)
            {
                if (sword.Value > 0)
                {
                    sb.AppendLine($"{sword.Key}: {sword.Value}");
                }
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
