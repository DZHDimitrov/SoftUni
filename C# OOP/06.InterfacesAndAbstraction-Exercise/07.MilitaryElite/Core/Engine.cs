using _08.MilitaryElite_.Contracts;
using _08.MilitaryElite_.Core.Contracts;
using _08.MilitaryElite_.Exceptions;
using _08.MilitaryElite_.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.MilitaryElite_.Core
{
    public class Engine : IEngine
    {

        private ICollection<ISoldier> soldiers;

        public Engine()
        {
            soldiers = new List<ISoldier>();
        }

        public void Run()
        {
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] cmdArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string typeSoldier = cmdArgs[0];
                int id = int.Parse(cmdArgs[1]);
                string firstName = cmdArgs[2];
                string lastName = cmdArgs[3];

                ISoldier soldier = null;

                if (typeSoldier == "Private")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);
                    soldier = new Private(id, firstName, lastName, salary);
                }
                else if (typeSoldier == "LieutenantGeneral")
                {
                    soldier = AddGeneral(cmdArgs, id, firstName, lastName);

                }
                else if (typeSoldier == "Engineer")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);
                    string corps = cmdArgs[5];

                    try
                    {
                        IEngineer engineer = CreateEngineer(cmdArgs, id, firstName, lastName, salary, corps);

                        soldier = engineer;
                    }
                    catch (InvalidCorpsException ice)
                    {
                        continue;
                    }
                }
                else if (typeSoldier == "Commando")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);
                    string corps = cmdArgs[5];

                    try
                    {
                        ICommando commando = GetCommando(cmdArgs, id, firstName, lastName, salary, corps);

                        soldier = commando;
                    }
                    catch (InvalidCorpsException ice)
                    {
                        continue;
                    }
                }
                else if (typeSoldier == "Spy")
                {
                    int codeNumber = int.Parse(cmdArgs[4]);
                    soldier = new Spy(id, firstName, lastName, codeNumber);
                }
                if (soldier != null)
                {
                    soldiers.Add(soldier);
                }
                input = Console.ReadLine();
            }

            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }

        private static ICommando GetCommando(string[] cmdArgs, int id, string firstName, string lastName, decimal salary, string corps)
        {
            ICommando commando = new Commando(id, firstName, lastName, salary, corps);

            string[] missions = cmdArgs.Skip(6).ToArray();

            for (int i = 0; i < missions.Length; i += 2)
            {
                try
                {
                    string codeName = missions[i];
                    string state = missions[i + 1];
                    IMission mission = new Mission(codeName, state);
                    commando.AddMission(mission);
                }
                catch (InvalidMissionException)
                {
                    continue;
                }
            }

            return commando;
        }

        private static IEngineer CreateEngineer(string[] cmdArgs, int id, string firstName, string lastName, decimal salary, string corps)
        {
            IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);
            string[] repairs = cmdArgs.Skip(6).ToArray();

            for (int i = 0; i < repairs.Length; i += 2)
            {
                string partName = repairs[i];
                int hoursWorked = int.Parse(repairs[i + 1]);
                IRepair repair = new Repair(partName, hoursWorked);

                engineer.AddRepair(repair);
            }

            return engineer;
        }

        private ISoldier AddGeneral(string[] cmdArgs, int id, string firstName, string lastName)
        {
            ISoldier soldier;
            decimal salary = decimal.Parse(cmdArgs[4]);
            ILieutenantGeneral general = new LieutenantGeneral(id, firstName, lastName, salary);

            foreach (var ids in cmdArgs.Skip(5))
            {
                ISoldier privateToAdd = soldiers.First(s => s.Id == int.Parse(ids));

                general.AddPrivate(privateToAdd);
            }
            soldier = general;
            return soldier;
        }
    }
}
