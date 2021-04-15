using _05.BorderControl.Contracts;
using _05.BorderControl.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05.BorderControl.Core
{
    public class Engine
    {
        private List<IID> IDS;
        public Engine()
        {
            IDS = new List<IID>();
        }

        public void Run()
        {
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] cmdArgs = input.Split();
                if (cmdArgs.Length == 3)
                {
                    string name = cmdArgs[0];
                    int age = int.Parse(cmdArgs[1]);
                    string id = cmdArgs[2];
                    Citizen citizen = new Citizen(name, age, id);
                    IDS.Add(citizen);
                }
                else
                {
                    string model = cmdArgs[0];
                    string id = cmdArgs[1];
                    Robot robot = new Robot(model, id);
                    IDS.Add(robot);
                }
                input = Console.ReadLine();
            }
            string digits = Console.ReadLine();

            for (int i = 0; i < IDS.Count; i++)
            {
                string currentId = IDS[i].ID;
                string subNumber = currentId.Substring(currentId.Length - digits.Length);
                if (subNumber == digits)
                {
                    Console.WriteLine(currentId);
                }
            }
        }
    }
}
