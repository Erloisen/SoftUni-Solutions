using System;
using System.Collections.Generic;

namespace _07.CustomException
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> personsData = new List<string>
            {
                "Jack Daniels 35",             // regular person
                " Smirnoff 36",                // person without First Name
                "Jeger  37",                   // person without Last Name
                "Samantha Williams -38",       // person with negative age
                "Santa Clasu 121",             // person with too big age
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

            try
            {
                Student sudent = new Student("P3t3r", "thisIsYour@mail.my");
            }
            catch (InvalidPersonNameException ex)
            {
                Console.WriteLine($"Exception thrown: {ex.Message}");
            }
        }
    }
}
