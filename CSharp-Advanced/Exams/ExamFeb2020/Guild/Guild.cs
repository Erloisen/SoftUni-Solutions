using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private readonly List<Player> roster;

        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            roster = new List<Player>();
        }

        public List<Player> Roster { get; set; }

        public string Name { get; private set; }

        public int Capacity { get; private set; }

        public int Count => roster.Count;

        public void AddPlayer(Player player)
        {
            if (Capacity > roster.Count)
            {
                roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            var currentPlayer = roster.FirstOrDefault(p => p.Name == name);
            if (currentPlayer != null)
            {
                return roster.Remove(currentPlayer);
            }

            return false;
        }

        public void PromotePlayer(string name)
        {
            var currentPlayer = roster.FirstOrDefault(p => p.Name == name);
            if (currentPlayer.Rank != "Member")
            {
                currentPlayer.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            var currentPlayer = roster.FirstOrDefault(p => p.Name == name);
            if (currentPlayer.Rank != "Trial")
            {
                currentPlayer.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string currentClass)
        {
            Player[] tempList = roster.Where(p => p.Class == currentClass).ToArray();
            roster.RemoveAll(p => p.Class == currentClass);

            return tempList;
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {this.Name}");
            foreach (var player in roster)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
