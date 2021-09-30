using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            var vipGuests = new HashSet<string>();
            var regularGuests = new HashSet<string>();
            bool partyStart = false;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "PARTY")
                {
                    partyStart = true;
                }

                if (input == "END")
                {
                    break;
                }

                if (Char.IsDigit(input[0]) && !partyStart)
                {
                    vipGuests.Add(input);
                }
                else if (Char.IsLetter(input[0]) && !partyStart)
                {
                    regularGuests.Add(input);
                }

                if (partyStart && input != "PARTY")
                {
                    vipGuests.Remove(input);
                    regularGuests.Remove(input);
                }
            }

            Console.WriteLine(vipGuests.Count + regularGuests.Count);
            if (vipGuests.Count > 0)
            {
                Console.WriteLine(string.Join("\n", vipGuests));
            }
            if (regularGuests.Count > 0)
            {
                Console.WriteLine(string.Join("\n", regularGuests));
            }
        }
    }
}
