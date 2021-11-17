using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IBirthable> list = new List<IBirthable>();
            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] commandInfo = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (commandInfo[0] == "Robot")
                {
                    command = Console.ReadLine();
                    continue;
                }

                IBirthable toAdd = null;
                if (commandInfo[0] == "Citizen")
                {
                    toAdd = new Citizens(commandInfo[1], int.Parse(commandInfo[2]), commandInfo[3], commandInfo[4]);
                }
                else if (commandInfo[0] == "Pet")
                {
                    toAdd = new Pet(commandInfo[1], commandInfo[2]);
                }

                list.Add(toAdd);
                command = Console.ReadLine();
            }

            string birthdayYear = Console.ReadLine();

            foreach (var identified in list.FindAll(b => b.Birthdate.EndsWith(birthdayYear)))
            {
                Console.WriteLine(identified.Birthdate);
            }

            Console.WriteLine();
        }
    }
}
