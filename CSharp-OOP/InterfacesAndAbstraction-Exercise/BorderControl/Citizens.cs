using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizens : IIdentify, IBirthable
    {
        public Citizens(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }

        public Citizens(string name, int age, string id, string birthdate)
            :this(name, age, id)
        {
            this.Birthdate = birthdate;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Id { get; set; }

        public string Birthdate { get; set; }
    }
}
