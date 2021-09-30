using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PredicateParty_
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] people = Console.ReadLine().Split();
            string input;
            while ((input = Console.ReadLine()) != "Party!")
            {
                var split = input.Split();
                var action = split[0];
                var criteriaName = split[1];
                var argument = split[2];

                Func<string[], Predicate<string>, string[]> func = null;
                if (action == "Remove")
                {
                    func = (name, crit) => name.Where(i => !crit(i)).ToArray();
                }
                else if (action == "Double")
                {
                    func = (names, crit) =>
                    {
                        List<string> doubled = new List<string>();
                        foreach (var name in names)
                        {
                            if (crit(name))
                            {
                                doubled.Add(name);
                            }

                            doubled.Add(name);
                        }

                        return doubled.ToArray();
                    };
                }

                Predicate<string> criteria = null;
                if (criteriaName == "StartsWith")
                {
                    criteria = name => name.StartsWith(argument);
                }
                else if (criteriaName == "EndsWith")
                {
                    criteria = name => name.EndsWith(argument);
                }
                else if (criteriaName == "Length")
                {
                    criteria = name => name.Length == int.Parse(argument);
                }

                people = func(people, criteria);
            }

            if (people.Any())
            {
                Console.WriteLine($"{string.Join(", ", people)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}
