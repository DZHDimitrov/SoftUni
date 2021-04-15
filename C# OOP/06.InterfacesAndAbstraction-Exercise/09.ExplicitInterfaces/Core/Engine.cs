using _10.ExplicitInterfaces.Contracts;
using _10.ExplicitInterfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _10.ExplicitInterfaces.Core
{
    public class Engine
    {
        public Engine()
        {

        }

        public void Run()
        {
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] cmdArgs = input.Split(' ');
                IPerson citizen = new Citizen(cmdArgs[0], cmdArgs[1], int.Parse(cmdArgs[2]));
                IResident citizen1 = new Citizen(cmdArgs[0], cmdArgs[1], int.Parse(cmdArgs[2]));
                Console.WriteLine(citizen.GetName());
                Console.WriteLine(citizen1.GetName());
                input = Console.ReadLine();
            }
        }
    }
}
