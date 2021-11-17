using MilitaryElite.Enums;
using MilitaryElite.Implementations;
using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;

namespace MilitaryElite
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, ISoldiers> soldiers = new Dictionary<int, ISoldiers>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] inputInfo = input.Split();
                string typeSolder = inputInfo[0];
                int id = int.Parse(inputInfo[1]);
                string firstName = inputInfo[2];
                string lastName = inputInfo[3];

                if (typeSolder == "Private")
                {
                    decimal salary = decimal.Parse(inputInfo[4]);
                    IPrivate privateSoldier = new Private(id, firstName, lastName, salary);
                    soldiers.Add(id, privateSoldier);
                }
                else if (typeSolder == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(inputInfo[4]);
                    ILieutenantGeneral leutenantGeneral = new LeutenantGeneral(id, firstName, lastName, salary);

                    for (int i = 5; i < inputInfo.Length; i++)
                    {
                        int inputId = int.Parse(inputInfo[i]);
                        IPrivate @private = soldiers[inputId] as IPrivate;

                        leutenantGeneral.Privates.Add(@private);
                    }

                    soldiers.Add(id, leutenantGeneral);
                }
                else if (typeSolder == "Engineer")
                {
                    decimal salary = decimal.Parse(inputInfo[4]);
                    string corpAsString = inputInfo[5];

                    bool isValidEnum = Enum.TryParse<Corps>(corpAsString, out Corps reuslt);
                    if (!isValidEnum)
                    {
                        input = Console.ReadLine();
                        continue;
                    }

                    IEngineer engineer = new Engineer(id, firstName, lastName, salary, reuslt);

                    for (int i = 6; i < inputInfo.Length; i += 2)
                    {
                        string partName = inputInfo[i];
                        int hours = int.Parse(inputInfo[i + 1]);

                        IRepairs repair = new Repair(partName, hours);

                        engineer.Repairs.Add(repair);
                    }

                    soldiers.Add(id, engineer);
                }
                else if (typeSolder == "Commando")
                {
                    decimal salary = decimal.Parse(inputInfo[4]);
                    string corpAsString = inputInfo[5];

                    bool isValidEnum = Enum.TryParse<Corps>(corpAsString, out Corps reuslt);
                    if (!isValidEnum)
                    {
                        input = Console.ReadLine();
                        continue;
                    }

                    ICommando commando = new Commando(id, firstName, lastName, salary, reuslt);

                    for (int i = 6; i < inputInfo.Length; i += 2)
                    {
                        string missionCodeName = inputInfo[i];
                        string missionStateAsString = inputInfo[i + 1];

                        bool isValideMission = Enum.TryParse<State>(missionStateAsString, out State status);
                        if (!isValideMission)
                        {
                            continue;
                        }

                        IMissions missions = new Mission(missionCodeName, status);
                        commando.Missions.Add(missions);
                    }

                    soldiers.Add(id, commando);
                }
                else if (typeSolder == "Spy")
                {
                    int codeNumber = int.Parse(inputInfo[4]);

                    ISpy spySoldier = new Spy(id, firstName, lastName, codeNumber);
                    soldiers.Add(id, spySoldier);
                }

                input = Console.ReadLine();
            }

            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier.Value.ToString());
            }
        }
    }
}
