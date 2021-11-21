using System;
using System.Collections.Generic;
using System.Text;

namespace _06.ValidPerson
{
    public class Person
    {
        private const int MinAge = 0;
        private const int MaxAge = 120;
        private string firstName;
        private string lastName;
        private int age;

        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public string FirstName
        {
            get => this.firstName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(value, "The first name can not be null or empty.");
                }
                this.firstName = value;
            }
        }

        public string LastName
        {
            get => this.lastName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(value, "The last name can not be null or empty.");
                }
                this.lastName = value;
            }
        }

        public int Age
        {
            get => this.age;
            private set
            {
                if (value < MinAge || value > MaxAge)
                {
                    throw new ArgumentOutOfRangeException(value.ToString(), $"The age should be in the range [{MinAge} - {MaxAge}].");
                }
                this.age = value;
            }
        }
    }
}
