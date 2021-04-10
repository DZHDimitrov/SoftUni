using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Animal> allAnimals = new List<Animal>();

            while (input != "Beast!")
            {
                string animalType = input;
                string[] data = Console.ReadLine().Split();
                string name = data[0];
                int age = int.Parse(data[1]);
                string gender = null;
                if (data.Length > 2)
                {
                    gender = data[2];
                }

                if ((animalType == "Tomcat" || animalType == "Kitten") && gender != null)
                {
                    input = Console.ReadLine();
                    continue;
                }
                try
                {
                    switch (animalType)
                    {
                        case "Cat":
                            Cat cat = new Cat(name, age, gender);
                            allAnimals.Add(cat);
                            break;
                        case "Dog":
                            Dog dog = new Dog(name, age, gender);
                            allAnimals.Add(dog);
                            break;
                        case "Frog":
                            Frog frog = new Frog(name, age, gender);
                            allAnimals.Add(frog);
                            break;
                        case "Kitten":
                            Kitten kitten = new Kitten(name, age);
                            allAnimals.Add(kitten);
                            break;
                        case "Tomcat":
                            Tomcat tomcat = new Tomcat(name, age);
                            allAnimals.Add(tomcat);
                            break;
                    }
                }
                catch (Exception n)
                {
                    Console.WriteLine(n.Message);
                }
                input = Console.ReadLine();
            }

            foreach (var item in allAnimals)
            {
                Console.WriteLine(item);
            }
        }
    }
}
