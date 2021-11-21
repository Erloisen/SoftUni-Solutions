using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }

        public double Height
        {
            get => height;
            private set => height = value;
        }

        public double Width
        {
            get => width;
            private set => width = value;
        }

        public override double CalculateArea()
        {
            return this.height * this.width;
        }

        public override double CalculatePerimeter()
        {
            return (this.height + this.width) * 2;
        }

        public override string Draw()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.Draw() + this.GetType().Name);
            /*
            sb.AppendLine(DrawLine(width, "*", "*"));
            for (double i = 1; i < height - 1; i++)
            {
                sb.AppendLine(DrawLine(width, "*", " "));
            }
            sb.AppendLine(DrawLine(width, "*", "*"));
            */
            return sb.ToString().TrimEnd();
        }

        private string DrawLine(double width, string end, string mid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(end);
            for (double i = 1; i < width - 1; i++)
            {
                sb.Append(mid);
            }
            sb.AppendLine(end);
            return sb.ToString().TrimEnd();
        }
    }
}
