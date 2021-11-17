using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public abstract class Car : ICar
    {
        private string model;
        private string color;
        protected Car(string model, string color)
        {
            this.Model = model;
            this.Color = color;
        }

        public string Model { get; private set; }

        public string Color { get; private set; }

        public string Start()
        {
            return $"Engine start";
        }

        public string Stop()
        {
            return $"Breaaak!";
        }
    }
}
