using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ObjectsAndClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Family family = new Family();
            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();
                string name = data[0];
                int age = int.Parse(data[1]);

                Person person = new Person();
                person.Name = name;
                person.Age = age;

                family.AddingMembers(person);
            }
            Person oldest = family.OldestPerson(family.People);

            Console.WriteLine($"{oldest.Name} {oldest.Age}");

        }
    }

    class Family
    {
        public List<Person> People { get; set; }

        public Family()
        {
            People = new List<Person>();
        }

        public void AddingMembers(Person person)
        {
            People.Add(person);
        }
        public Person OldestPerson(List<Person> people)
        {
            Person oldest = people.OrderByDescending(x => x.Age).First();

            return oldest;
        }
    }
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

}

