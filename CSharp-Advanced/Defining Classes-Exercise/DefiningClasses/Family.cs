using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        public Family()
        {
            this.People = new List<Person>();
        }
        public List<Person> People { get; set; }
        public void AddMember(Person member)
        {
            People.Add(member);
        }
        public Person GetOldestMember()
        {
            Person oldestMember = People.OrderByDescending(x => x.Age).FirstOrDefault();
            return oldestMember;
        }
    }
}
