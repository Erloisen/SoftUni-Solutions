using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;
        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        { 
            get => this.length;
            private set
            {
                ValidattionOfSide(value, nameof(this.Length));

                length = value;
            }
        }

        public double Width
        { 
            get => this.width;
            private set
            {
                ValidattionOfSide(value, nameof(this.Width));

                width = value;
            }
        }
        public double Height
        {
            get => this.height;
            private set
            {
                ValidattionOfSide(value, nameof(this.Height));

                height = value;
            }
        }

        private static void ValidattionOfSide(double value, string side)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{side} cannot be zero or negative.");
            }
        }

        public double SurfaceAreaCalculation()
        { 
            var surfaceArea = (2 * length * width) + (2 * length * height) + (2 * width * height);
            return surfaceArea;
        }

        public double LateralSurfaceAreaCalculation()
        {
            var lateralSurfaceArea = (2 * length * height) + (2 * width * height);
            return lateralSurfaceArea;
        }

        public double VolumeCalculation()
        {
            var volume = length * width * height;
            return volume;
        }
    }
}
