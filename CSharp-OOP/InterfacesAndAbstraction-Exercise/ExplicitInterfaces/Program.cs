using System;

namespace ExplicitInterfaces
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] personInfo = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = personInfo[0];
                string country = personInfo[1];
                int age = int.Parse(personInfo[2]);
                Citizen citizen = new Citizen(name, country, age);
                IPerson person = citizen;
                IResident residentPerson = citizen;

                person.GetName();
                residentPerson.GetName();
            }
        }
    }
}
