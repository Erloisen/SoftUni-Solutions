using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    internal class Team
    {
        private string name;
        private Dictionary<string, Player> playersByName;
        public Team(string name)
        {
            this.Name = name;
            this.playersByName = new Dictionary<string, Player>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                Validator.ThrowIfNameIsNullOrEmpthy(value);

                this.name = value;
            }
        }
        public double AverageRating
        {
            get
            {
                if (this.playersByName.Count == 0)
                {
                    return 0;
                }

                return Math.Round(this.playersByName.Values.Average(p => p.AverageSkillPoint));
            }
        }

        public void AddPlayer(Player player)
        {
            
            if (!playersByName.ContainsKey(player.Name))
            {
                this.playersByName.Add(player.Name, player);
            }
        }

        public void RemovePlayer(string player)
        {
            if (!playersByName.ContainsKey(player))
            {
                throw new ArgumentException($"Player {player} is not in {this.Name} team.");
            }

            this.playersByName.Remove(player);
        }

    }
}
