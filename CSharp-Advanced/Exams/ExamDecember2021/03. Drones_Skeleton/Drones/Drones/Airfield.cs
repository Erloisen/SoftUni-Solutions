using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        private readonly List<Drone> drones;
        public Airfield(string name, int capacity, double landingStrip)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.LandingStrip = landingStrip;

            this.drones = new List<Drone>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }
        public IReadOnlyCollection<Drone> Drones => drones.AsReadOnly();

        public int Count { get => this.drones.Count; }

        public string AddDrone(Drone drone)
        {
            if (string.IsNullOrEmpty(drone.Name))
            {
                return "Invalid drone.";
            }

            if (string.IsNullOrEmpty(drone.Brand))
            {
                return "Invalid drone.";
            }

            if (drone.Range < 5 || drone.Range > 15)
            {
                return "Invalid drone.";
            }

            if (this.Capacity <= this.Count)
            {
                return "Airfield is full.";
            }

            this.drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";
        }

        public bool RemoveDrone(string name)
        {
            var currentDrone = this.drones.FirstOrDefault(d => d.Name == name);
            if (currentDrone != null)
            {
                this.drones.Remove(currentDrone);
                return true;
            }

            return false;
        }

        public int RemoveDroneByBrand(string brand)
        {
            return this.drones.RemoveAll(d => d.Brand == brand);
        }

        public Drone FlyDrone(string name)
        {
            var currentDrone = this.drones.FirstOrDefault(d => d.Name == name);
            if (currentDrone == null)
            {
                return null;
            }

            currentDrone.Available = false;
            return currentDrone;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            var allDrones = this.drones.Where(d => d.Range >= range).ToList();
            foreach (var drone in allDrones)
            {
                FlyDrone(drone.Name);
            }

            return allDrones;
        }

        public string Report()
        {
            var allDrones = this.Drones.Where(d => d.Available == true).ToList();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Drones available at {this.Name}:");
            foreach (var dron in allDrones)
            {
                sb.AppendLine(dron.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
