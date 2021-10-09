using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;
        public Parking(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            this.data = new List<Car>();
        }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return data.Count; } }
        public void Add(Car car)
        {
            if (Capacity > data.Count)
            {
                data.Add(car);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            Car carToRemove = data.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);
            if (carToRemove != null)
            {
                data.Remove(carToRemove);
                return true;
            }

            return false;
        }
        public Car GetLatestCar()
        {
            return data.OrderByDescending(c => c.Year).FirstOrDefault();
        }
        public Car GetCar(string manufacturer, string model)
        {
            Car car = data.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);
            return car;
        }
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {Type}:");
            foreach (var car in data)
            {
                sb.AppendLine(car.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
