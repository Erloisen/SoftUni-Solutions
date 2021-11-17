using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : IDrawable
    {
        private int width;
        private int height;
        public Rectangle(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public int Width { get; private set; }

        public int Height { get; private set; }

        public string Draw()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(DrawLine(this.Width, "*", "*"));
            for (int i = 0; i < this.Height - 1; ++i)
            {
                sb.AppendLine(DrawLine(this.Width, "*", " "));
            }
            sb.AppendLine(DrawLine(this.Width, "*", "*"));

            return sb.ToString().TrimEnd();
        }

        private string DrawLine(int width, string end, string mid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(end);
            for (int i = 0; i < width - 1; ++i)
            {
                sb.Append(mid);
            }

            sb.AppendLine(end);

            return sb.ToString().TrimEnd();
        }
    }
}
