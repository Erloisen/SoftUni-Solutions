using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        protected Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        

        public abstract string ProduceSound();

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}");
            sb.AppendLine($"{Name} {Age} {Gender}");
            sb.AppendLine($"{ProduceSound()}");
            return sb.ToString().TrimEnd();
        }
    }
}
