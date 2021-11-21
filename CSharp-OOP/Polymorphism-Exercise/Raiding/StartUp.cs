using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<BaseHero>> group = new Dictionary<string, List<BaseHero>>();

            int n = int.Parse(Console.ReadLine());

            while (true)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                BaseHero currentHero = null;

                switch (heroType)
                {
                    case nameof(Druid):
                        currentHero = new Druid(heroName);
                        break;
                    case nameof(Paladin):
                        currentHero = new Paladin(heroName);
                        break;
                    case nameof(Rogue):
                        currentHero = new Rogue(heroName);
                        break;
                    case nameof(Warrior):
                        currentHero = new Warrior(heroName);
                        break;
                    default:
                        Console.WriteLine("Invalid hero!");
                        continue;
                }

                if (!group.ContainsKey(heroType))
                {
                    group.Add(heroType, new List<BaseHero>());
                }

                group[heroType].Add(currentHero);

                if (group.Values.Count == n)
                {
                    break;
                }
            }

            int bossPower = int.Parse(Console.ReadLine());

            foreach (var heroes in group)
            {
                foreach (var hero in heroes.Value)
                {
                    Console.WriteLine(hero.CastAbility());
                }
            }

            int groupPower = group.Values.Sum(h => h.Sum(p => p.Power));

            if (groupPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
