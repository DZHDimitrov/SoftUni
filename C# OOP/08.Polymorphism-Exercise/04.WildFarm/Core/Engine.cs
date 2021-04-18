using _04.WildFarm.Contracts;
using _04.WildFarm.Core;
using _04.WildFarm.Models;
using System;
using System.Collections.Generic;

namespace _04.WildFarm
{
    public class Engine : IEngine
    {
        private ICollection<IAnimal> animals;
        public Engine()
        {
            animals = new List<IAnimal>();
        }
        public void Run()
        {
            string input = Console.ReadLine();
            int line = 0;
            Animal animal = null;
            Food food = null;
            while (input != "End")
            {
                string[] cmdArgs = input.Split();
                if (line % 2 == 0)
                {
                    animal = CreateAnimal(cmdArgs);
                    animals.Add(animal);
                }
                else if (line % 2 != 0)
                {
                    food = CreateFood(cmdArgs);

                    Console.WriteLine(animal.ProduceSound());

                    try
                    {
                        animal.Feed(food);
                    }
                    catch (InvalidOperationException ioe)
                    {
                        Console.WriteLine(ioe.Message);
                    }

                }
                line++;
                input = Console.ReadLine();
            }
            foreach (Animal anml in animals)
            {
                Console.WriteLine(anml);
            }

        }
        private Food CreateFood(string[] cmdArgs)
        {
            FoodFactory foodFactory = new FoodFactory();
            string type = cmdArgs[0];
            int quantity = int.Parse(cmdArgs[1]);
            return foodFactory.CreateFood(type,quantity);
        }
        private Animal CreateAnimal(string[] cmdArgs)
        {
            AnimalFactory animalFactory = new AnimalFactory();
            return animalFactory.CreateAnimal(cmdArgs);
        }
    }
}
