using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TheV_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            var register = new Dictionary<string, Dictionary<string, SortedSet<string>>>();
            var input = string.Empty;

            while ((input = Console.ReadLine()) != "Statistics")
            {
                var action = input.Split(' ');
                var vloggername = action[0];
                var command = action[1];

                if (command == "joined")
                {
                    if (!register.ContainsKey(vloggername))
                    {
                        register.Add(vloggername, new Dictionary<string, SortedSet<string>>());
                        register[vloggername].Add("followers", new SortedSet<string>());
                        register[vloggername].Add("following", new SortedSet<string>());
                    }
                }
                else if (command == "followed")
                {
                    string member = action[2];
                    if (register.ContainsKey(vloggername) &&
                        register.ContainsKey(member) &&
                        vloggername != member)
                    {
                        register[vloggername]["following"].Add(member);
                        register[member]["followers"].Add(vloggername);
                    }
                }
            }

            Console.WriteLine($"The V-Logger has a total of {register.Count} vloggers in its logs.");

            int number = 1;

            foreach (var vlogger in register.OrderByDescending(x => x.Value["followers"].Count).ThenBy(x => x.Value["following"].Count))
            {
                Console.WriteLine($"{number}. {vlogger.Key} : {vlogger.Value["followers"].Count} followers, {vlogger.Value["following"].Count} following");
                if (number == 1)
                {
                    foreach (var follower in vlogger.Value["followers"])
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }

                number++;
            }

        }
    }
}
