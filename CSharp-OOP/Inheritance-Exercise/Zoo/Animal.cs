﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    public class Animal
    {
        private Animal name;

        public Animal(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
