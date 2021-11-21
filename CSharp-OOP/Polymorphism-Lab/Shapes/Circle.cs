using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get => radius;
            private set => radius = value;
        }

        public override double CalculateArea()
        {
            return Math.PI * Math.Pow(radius, 2);
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * radius;
        }

        public override string Draw()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.Draw() + this.GetType().Name);
            /*
            double rIn = radius - 0.4;
            double rOut = radius + 0.4;
            for (double y = radius; y >= -radius; y--)
            {
                for (double x = -radius; x < rOut; x += 0.5)
                {
                    double value = x * x + y * y;
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
            */
            return sb.ToString().TrimEnd();
        }
    }
}
