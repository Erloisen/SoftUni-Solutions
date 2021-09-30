using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FilterByAge
{
    class Person
    {
        public string Name;

        public int Age; 
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var data = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                var person = new Person();
                person.Name = data[0];
                person.Age = int.Parse(data[1]);
                people.Add(person);
            }

            string condition = Console.ReadLine();
            int ageToCompareWith = int.Parse(Console.ReadLine());

            Func<Person, bool> filter = p => true;
            if (condition == "younger")
            {
                filter = p => p.Age < ageToCompareWith;
            }
            else if (condition == "older")
            {
                filter = p => p.Age >= ageToCompareWith;
            }

            var filteredPeople = people.Where(filter);

            string format = Console.ReadLine();
            Func<Person, string> printFunc = p => p.Name + " - " + p.Age;
            if (format == "name")
            {
                printFunc = n => n.Name;
            }
            else if (format == "age")
            {
                printFunc = n => n.Age.ToString();
            }

            Console.WriteLine(string.Join("\n", filteredPeople.Select(printFunc)));
        }
    }
}
