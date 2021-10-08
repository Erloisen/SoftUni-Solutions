using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Car
    {
        public Car()
        {

        }
        public Car(string model, Engine engine, int? weight, string color)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = weight;
            this.Color = color;
        }
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int? Weight { get; set; }
        public string Color { get; set; }

        public override string ToString() =>
            $"{Model}:\r\n" +
            $" {Engine}\r\n" +
            $"  Weight: {(Weight == null ? "n/a" : Weight.ToString())}\r\n" +
            $"  Color: {Color ?? "n/a"}";

    }
}
