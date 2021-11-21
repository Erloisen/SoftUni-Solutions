using System;
using System.Collections.Generic;

namespace _06.ValidPerson
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> personsData = new List<string>
            {
                "Petar Petrov 35",           // regular person
                " Petrov 36",                // person without First Name
                "Petar  37",                 // person without Last Name
                "Samantha Williams -38",     // person with negative age
                "Samantha Williams 121",     // person with too big age
            };

            foreach (var newPerson in personsData)
            {
                try
                {
                    string firstName = newPerson.Split()[0];
                    string lastName = newPerson.Split()[1];
                    int age = int.Parse(newPerson.Split()[2]);
                    Person person = new Person(firstName, lastName, age);
                    Console.WriteLine($"{person.FirstName} {person.LastName} {person.Age}");
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine($"Exception thrown: {ex.Message}");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"Exception thrown: {ex.Message}");
                }
            }
        }
    }
}
