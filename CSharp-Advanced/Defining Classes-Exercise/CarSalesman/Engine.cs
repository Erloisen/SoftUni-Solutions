using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Engine
    {
        public Engine(string model, int power, int? displacement, string efficiency)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = displacement;
            this.Efficiency = efficiency;
        }
        public string Model { get; set; }
        public int Power { get; set; }
        public int? Displacement { get; set; }
        public string Efficiency { get; set; }

        public override string ToString() =>
                   $" {Model}: \r\n" +
                   $"    Power: {Power}\r\n" +
                   $"    Displacement: {(Displacement == null ? "n/a" : Displacement.ToString())}\r\n" +
                   $"    Efficiency: {Efficiency ?? "n/a"}";
    }
}
