using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            Parking parking = new Parking();
            for (int i = 0; i < lines; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split();
                string command = cmdArgs[0];
                string name = cmdArgs[1];
                try
                {
                    switch (command)
                    {
                        case "register":
                            string number = cmdArgs[2];
                            Person person = new Person(name, number);
                            parking.Register(person);
                            break;
                        case "unregister":
                            parking.Unregister(name);
                            break;
                    }
                }
                catch (Exception ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
            foreach (var item in parking.People)
            {
                Console.WriteLine(item);
            }
        }
    }
    class Person
    {
        public Person(string name, string number)
        {
            Name = name;
            Number = number;
        }
        public string Name { get; set; }
        public string Number { get; set; }

        public override string ToString()
        {
            return $"{Name} => {Number}";
        }
    }
    class Parking
    {
        public Parking()
        {
            People = new List<Person>();
        }
        public List<Person> People { get; set; }

        public void Register(Person person)
        {
            if (People.Any(x => x.Name == person.Name))
            {
                Person lastRegister = People.FirstOrDefault(x => x.Name == person.Name);
                throw new ArgumentException($"ERROR: already registered with plate number {lastRegister.Number}");
            }
            else
            {
                People.Add(person);
                Console.WriteLine($"{person.Name} registered {person.Number} successfully");
            }
        }
        public void Unregister(string name)
        {
            if (!People.Any(x => x.Name == name))
            {
                throw new ArgumentException($"ERROR: user {name} not found");
            }
            else
            {
                Person person = People.FirstOrDefault(x => x.Name == name);
                People.Remove(person);
                Console.WriteLine($"{person.Name} unregistered successfully");
            }
        }
    }
}
