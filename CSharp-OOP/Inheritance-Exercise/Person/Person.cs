using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {
        private Person name;
        private Person age;
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(String.Format($"Name: {this.Name}, Age: {this.Age}"));
            return sb.ToString().TrimEnd();
        }
    }
}
