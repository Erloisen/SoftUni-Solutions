using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Family family = new Family();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] memberInfo = Console.ReadLine().Split(' ');
                Person member = new Person(memberInfo[0], int.Parse(memberInfo[1]));
                family.AddMember(member);
            }

            foreach (var member in family.People.OrderBy(p => p.Name).Where(p => p.Age > 30))
            {
                Console.WriteLine($"{member.Name} - {member.Age}");
            }
        }
    }
}
