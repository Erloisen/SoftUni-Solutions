using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var lines = int.Parse(Console.ReadLine());
            var persons = new List<Person>();
            Team team = new Team("SoftUni");
            for (int i = 0; i < lines; i++)
            {
                try
                {
                    string[] inputInfo = Console.ReadLine().Split();
                    var person = new Person(inputInfo[0], inputInfo[1], int.Parse(inputInfo[2]), decimal.Parse(inputInfo[3]));
                    persons.Add(person);
                }
                catch (Exception m)
                {

                    Console.WriteLine(m);
                }
            }

            foreach (Person currentPerson in persons)
            {
                team.AddPlayer(currentPerson);
            }

            Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
            Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");
        }
    }
}
