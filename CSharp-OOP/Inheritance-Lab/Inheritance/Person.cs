using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    class Person
    {
        public Person(string name)
        {
            this.Name = name;
        }
        public string Name { get; set; }

        public int Age { get; set; }

        public void Sleep()
        {
            Console.WriteLine($"I'm a/an {this.GetType().Name} and I'm sleeping.");
        }
    }
}
