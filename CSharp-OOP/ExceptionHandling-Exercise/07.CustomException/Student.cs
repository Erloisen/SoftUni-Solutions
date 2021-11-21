using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07.CustomException
{
    public class Student
    {
        private string name;

        public Student(string name, string email)
        {
            this.Name = name;
            this.Email = email;
        }

        public string Name 
        {
            get => name;
            private set
            {
                if (!value.All(char.IsLetter))
                {
                    throw new InvalidPersonNameException("The name should contains only letters.");
                }
                name = value;
            }
        }

        public string Email { get; private set; }
    }
}
