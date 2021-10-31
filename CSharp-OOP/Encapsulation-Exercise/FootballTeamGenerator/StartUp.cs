using System;
using System.Collections.Generic;

namespace FootballTeamGenerator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var teamsByName = new Dictionary<string, Team>();

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] commandInfo = command.Split(';', StringSplitOptions.RemoveEmptyEntries);
                string action = commandInfo[0];

                try
                {
                    if (action == "Add")
                    {
                        var teamName = commandInfo[1];
                        if (!teamsByName.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            command = Console.ReadLine();
                            continue;
                        }

                        var playerName = commandInfo[2];
                        var endurance = int.Parse(commandInfo[3]);
                        var sprint = int.Parse(commandInfo[4]);
                        var dribble = int.Parse(commandInfo[5]);
                        var passing = int.Parse(commandInfo[6]);
                        var shooting = int.Parse(commandInfo[7]);

                        var team = teamsByName[teamName];

                        var player = new Player(playerName, endurance, sprint, dribble, passing, shooting);

                        team.AddPlayer(player);
                    }
                    else if (action == "Remove")
                    {
                        var teamName = commandInfo[1];
                        var playerName = commandInfo[2];

                        var team = teamsByName[teamName];
                        team.RemovePlayer(playerName);
                    }
                    else if (action == "Rating")
                    {
                        var teamName = commandInfo[1];
                        if (!teamsByName.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            command = Console.ReadLine();
                            continue;
                        }

                        var team = teamsByName[teamName];
                        Console.WriteLine($"{teamName} - {team.AverageRating}");
                    }
                    else if (action == "Team")
                    {
                        var teamName = commandInfo[1];
                        var team = new Team(teamName);

                        teamsByName.Add(teamName, team);
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                command = Console.ReadLine();
            }
        }
    }
}
