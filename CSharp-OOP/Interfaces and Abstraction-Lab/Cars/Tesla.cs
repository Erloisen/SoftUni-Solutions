using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Tesla : Car, IElectricCar
    {
        private int battery;

        public Tesla(string model, string color, int battery)
            : base(model, color)
        {
            this.Battery = battery;
        }

        public int Battery { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Color} {this.GetType().Name} {this.Model} with {this.Battery} Batteries");
            sb.AppendLine(Start());
            sb.AppendLine(Stop());

            return sb.ToString().TrimEnd();
        }
    }
}
