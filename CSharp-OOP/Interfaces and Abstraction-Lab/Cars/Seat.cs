using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Seat : Car
    {
        public Seat(string model, string color)
            : base(model, color)
        {
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Color} {this.GetType().Name} {this.Model}");
            sb.AppendLine(Start());
            sb.AppendLine(Stop());

            return sb.ToString().TrimEnd();
        }
    }
}
