using _05.BorderControl.Models;
using _06.BirthdayCelebrations.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _06.BirthdayCelebrations.Core
{
    public class Engine
    {
        private List<IBirthdate> birthdates;

        public Engine()
        {
            birthdates = new List<IBirthdate>();
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] cmdArgs = input.Split();
                string type = cmdArgs[0];
                switch (type)
                {
                    case "Citizen":
                        IBirthdate citizen = new Citizen(cmdArgs[1], int.Parse(cmdArgs[2]), cmdArgs[3], cmdArgs[4]);
                        birthdates.Add(citizen);
                        break;
                    case "Pet":
                        IBirthdate pet = new Pet(cmdArgs[1], cmdArgs[2]);
                        birthdates.Add(pet);
                        break;

                }
                input = Console.ReadLine();
            }
            string year = Console.ReadLine();
            for (int i = 0; i < birthdates.Count; i++)
            {
                string[] currentBirthdate = birthdates[i].Birthdate.Split('/');
                string currentYear = currentBirthdate[2];
                if (currentYear == year)
                {
                    Console.WriteLine(birthdates[i].Birthdate);
                }
            }
        }

    }
}
