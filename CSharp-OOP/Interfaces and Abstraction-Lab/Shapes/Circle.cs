using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : IDrawable
    {
        private int radius;

        public Circle(int radius)
        {
            this.Radius = radius;
        }

        public int Radius { get; private set; }
        public string Draw()
        {
            double rIn = this.Radius - 0.4;
            double rOut = this.Radius + 0.4;
            StringBuilder sb = new StringBuilder();

            for (double i = this.Radius; i >= -this.Radius; --i)
            {
                for (double j = -this.Radius; j < rOut; j += 0.5)
                {
                    double value = i * i + j * j;
                    if (value >= rIn * rIn && value <= rOut * rOut)
                    {
                        sb.Append("*");
                    }
                    else
                    {
                        sb.Append(" ");
                    }
                }
                sb.AppendLine();
            }

            return sb.ToString().TrimEnd();
        }
    }
}
