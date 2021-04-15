using _05.BorderControl.Models;
using _07.FoodStorage.Contracts;
using _07.FoodStorage.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.BirthdayCelebrations.Core
{
    public class Engine
    {
        private List<IPerson> allPeople;
        public Engine()
        {
            allPeople = new List<IPerson>();
        }

        public void Run()
        {
            int people = int.Parse(Console.ReadLine());
            for (int i = 0; i < people; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split();
                if (cmdArgs.Length == 4)
                {
                    Citizen citizen = new Citizen(cmdArgs[0], int.Parse(cmdArgs[1]), cmdArgs[2], cmdArgs[3]);
                    allPeople.Add(citizen);
                }
                else if (cmdArgs.Length == 3)
                {
                    Rebel rebel = new Rebel(cmdArgs[0], int.Parse(cmdArgs[1]), cmdArgs[2]);
                    allPeople.Add(rebel);
                }
            }
            string input = Console.ReadLine();
            while (input != "End")
            {
                string name = input;
                foreach (var item in allPeople)
                {
                    if (item.Name == name)
                    {
                        item.BuyFood();
                    }
                }
                input = Console.ReadLine();
            }
            int sum = 0;
            foreach (var item in allPeople)
            {
                sum += item.Food;
            }
            Console.WriteLine(sum);
            
        }

    }
}
