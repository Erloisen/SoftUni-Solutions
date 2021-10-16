using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> data;

        public Bakery(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;

            this.data = new List<Employee>();
        }
        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count { get { return data.Count; } }

        public void Add(Employee employee)
        {
            if (Capacity > data.Count)
            {
                data.Add(employee);
            }
        }

        public bool Remove(string name)
        {
            var employee = data.FirstOrDefault(e => e.Name == name);
            if (employee != null)
            {
                data.Remove(employee);
                return true;
            }

            return false;
        }

        public Employee GetOldestEmployee()
        {
            return data.OrderByDescending(e => e.Age).FirstOrDefault();
        }

        public Employee GetEmployee(string name)
        { 
            Employee currentEmployee = data.FirstOrDefault(e => e.Name == name);
            return currentEmployee;
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Employees working at Bakery {Name}:");
            foreach (var employee in data)
            {
                sb.AppendLine(employee.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
