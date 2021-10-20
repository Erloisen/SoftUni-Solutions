using System;
using System.Collections.Generic;
using System.Text;

namespace SkiRental
{
    class Ski
    {
        public Ski(string manufacturer, string model, int year)
        {
            Manufacturer = manufacturer;
            Model = model;
            Year = year;
        }

        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{Manufacturer} - {Model} - {Year}");
            return sb.ToString().TrimEnd();
        }
    }
}
