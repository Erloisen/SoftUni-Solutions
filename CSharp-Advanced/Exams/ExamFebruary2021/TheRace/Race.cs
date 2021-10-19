using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private List<Racer> data;

        public Race(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;

            data = new List<Racer>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count { get { return data.Count; } }

        public void Add(Racer Racer)
        {
            if (Capacity > data.Count)
            {
                data.Add(Racer);
            }
        }

        public bool Remove(string name)
        {
            var racerToRemove = data.FirstOrDefault((r => r.Name == name));
            if (data.Any((r => r.Name == name)))
            {
                data.Remove(racerToRemove);
                return true;
            }

            return false;
        }

        public Racer GetOldestRacer()
        {
            return data.OrderByDescending(r => r.Age).FirstOrDefault();
        }

        public Racer GetRacer(string name)
        {
            return data.FirstOrDefault(r => r.Name == name);
        }

        public Racer GetFastestRacer()
        {
            return data.OrderByDescending(r => r.Car.Speed).FirstOrDefault();
        }

        public string Report() 
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Racers participating at {Name}:");
            foreach (var racer in data)
            {
                sb.AppendLine(racer.ToString().TrimEnd());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
