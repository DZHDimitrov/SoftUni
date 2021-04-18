using _04.WildFarm.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Core
{
    public class AnimalFactory
    {
        public AnimalFactory()
        {

        }

        public Animal CreateAnimal(string[] cmdArgs)
        {
            Animal animal = null;
            string type = cmdArgs[0];
            string name = cmdArgs[1];
            double weight = double.Parse(cmdArgs[2]);

            if (type == "Cat" || type == "Tiger")
            {
                string livingRegion = cmdArgs[3];
                string breed = cmdArgs[4];
                if (type == "Cat")
                {
                    animal = new Cat(name, weight, livingRegion, breed);
                }
                else if (type == "Tiger")
                {
                    animal = new Tiger(name, weight, livingRegion, breed);
                }
            }
            else if (type == "Owl" || type == "Hen")
            {
                double wingsize = double.Parse(cmdArgs[3]);
                if (type == "Owl")
                {
                    animal = new Owl(name, weight, wingsize);
                }
                else if (type == "Hen")
                {
                    animal = new Hen(name, weight, wingsize);
                }
            }
            else if (type == "Mouse" || type == "Dog")
            {
                string livingRegion = cmdArgs[3];
                if (type == "Mouse")
                {
                    animal = new Mouse(name, weight, livingRegion);
                }
                else if (type == "Dog")
                {
                    animal = new Dog(name, weight, livingRegion);
                }
            }
            return animal;

        }
    }
}
