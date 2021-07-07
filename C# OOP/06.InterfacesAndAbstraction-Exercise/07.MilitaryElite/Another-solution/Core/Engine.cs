using MilitaryElite.Common.Enums;
using MilitaryElite.Interfaces;
using MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Core
{
    public class Engine : IEngine
    {
        private ICollection<ISoldier> soldiers;

        public Engine()
        {
            this.soldiers = new List<ISoldier>();
        }

        public void Run()
        {
            string line = Console.ReadLine();

            while (line != "End")
            {
                string[] cmdArgs = line.Split(' ');
                string currentSoldier = cmdArgs[0];
                ISoldier soldier = default;

                if (currentSoldier == "Private")
                {
                    int id = int.Parse(cmdArgs[1]);
                    string firstName = cmdArgs[2];
                    string lastName = cmdArgs[3];
                    decimal salary = decimal.Parse(cmdArgs[4]);

                    soldier = new Private(id, firstName, lastName, salary);
                    this.soldiers.Add(soldier);
                }
                else if (currentSoldier == "LieutenantGeneral")
                {
                    int id = int.Parse(cmdArgs[1]);
                    string firstName = cmdArgs[2];
                    string lastName = cmdArgs[3];
                    decimal salary = decimal.Parse(cmdArgs[4]);

                    int[] privateIds = cmdArgs.Skip(5).Select(int.Parse).ToArray();

                    List<IPrivate> privates = new List<IPrivate>();

                    foreach (var soldierId in privateIds)
                    {
                        var curPrivate = this.soldiers.FirstOrDefault(x => x.Id == soldierId);
                        privates.Add((IPrivate)curPrivate);
                    }

                    soldier = new LieutenantGeneral(id, firstName, lastName, salary, privates);
                    this.soldiers.Add(soldier);
                }
                else if (currentSoldier == "Engineer")
                {
                    int id = int.Parse(cmdArgs[1]);
                    string firstName = cmdArgs[2];
                    string lastName = cmdArgs[3];
                    decimal salary = decimal.Parse(cmdArgs[4]);
                    string corps = cmdArgs[5];

                    string[] repairsStrings = cmdArgs.Skip(6).ToArray();

                    List<IRepair> repairs = new List<IRepair>();

                    for (int i = 0; i < repairsStrings.Length; i += 2)
                    {
                        string repairPart = repairsStrings[i];
                        int repairHours = int.Parse(repairsStrings[i + 1]);
                        IRepair repair = new Repair(repairPart, repairHours);
                        repairs.Add(repair);
                    }
                    try
                    {
                        soldier = new Engineer(id, firstName, lastName, salary, corps, repairs);
                        this.soldiers.Add(soldier);
                    }
                    catch (ArgumentException ae)
                    {
                        line = Console.ReadLine();
                        continue;
                    }
                }
                else if (currentSoldier == "Commando")
                {
                    int id = int.Parse(cmdArgs[1]);
                    string firstName = cmdArgs[2];
                    string lastName = cmdArgs[3];
                    decimal salary = decimal.Parse(cmdArgs[4]);
                    string corps = cmdArgs[5];

                    string[] missionsAsString = cmdArgs.Skip(6).ToArray();

                    List<IMission> missions = new List<IMission>();

                    for (int i = 0; i < missionsAsString.Length; i += 2)
                    {
                        string missionCodeName = missionsAsString[i];
                        string missionState = missionsAsString[i + 1];
                        try
                        {
                            IMission mission = new Mission(missionCodeName, missionState);
                            missions.Add(mission);
                        }
                        catch (ArgumentException ae)
                        {
                            continue;
                        }
                    }
                    try
                    {
                        soldier = new Commando(id, firstName, lastName, salary, corps, missions);
                        this.soldiers.Add(soldier);
                    }
                    catch (ArgumentException ae)
                    {
                        line = Console.ReadLine();
                        continue;
                    }
                }
                else if (currentSoldier == "Spy")
                {
                    int id = int.Parse(cmdArgs[1]);
                    string firstName = cmdArgs[2];
                    string lastName = cmdArgs[3];
                    int codeNumber = int.Parse(cmdArgs[4]);

                    soldier = new Spy(id, firstName, lastName, codeNumber);
                    this.soldiers.Add(soldier);
                }
                line = Console.ReadLine();
            }
            foreach (var soldier in this.soldiers)
            {
                Console.WriteLine(soldier.ToString());
            }

        }
        private static bool ValidateCorps(string corps)
        {
            if (!Enum.TryParse<Corps>(corps, out _))
            {
                return false;
            }
            return true;
        }
    }
}
