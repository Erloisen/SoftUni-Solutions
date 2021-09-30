using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.PartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split().ToList();
            var dictionary = new Dictionary<string, Predicate<string>>();
            string command = Console.ReadLine();

            while (command != "Print")
            {
                string[] commandArgs = command.Split(';');
                string action = commandArgs[0];
                string predicateAction = commandArgs[1];
                string value = commandArgs[2];

                string key = predicateAction + "_" + value;
                if (action == "Add filter")
                {
                    Predicate<string> predicate = GetPredicat(predicateAction, value);
                    dictionary.Add(key, predicate);
                }
                else
                {
                    dictionary.Remove(key);
                }

                command = Console.ReadLine();
            }

            foreach (var (key, predicate) in dictionary)
            {
                names.RemoveAll(predicate);
            }

            Console.WriteLine(string.Join(" ", names));
        }
        private static Predicate<string> GetPredicat(string commandInfo, string param)
        {
            if (commandInfo == "Starts with")
            {
                return x => x.StartsWith(param);
            }
            else if (commandInfo == "Ends with")
            {
                return x => x.EndsWith(param);
            }
            else if (commandInfo == "Contains")
            {
                return x => x.Contains(param);
            }

            int length = int.Parse(param);

            return x => x.Length == length;
        }
    }
}
