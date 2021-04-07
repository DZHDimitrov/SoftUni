using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Person> people = new List<Person>();

            while (input != "END")
            {
                string[] data = input.Split();
                string name = data[0];
                int age = int.Parse(data[1]);
                string town = data[2];
                Person person = new Person(name, age, town);
                people.Add(person);

                input = Console.ReadLine();
            }

            int equal = 0;
            int notEqual = 0;
            int indexOfPerson = int.Parse(Console.ReadLine());

            for (int i = 0; i < people.Count; i++)
            {
                if (people[i] == people[indexOfPerson - 1])
                {
                    Person currentPerson = people[indexOfPerson - 1];

                    for (int j = 0; j < people.Count; j++)
                    {
                        if (people[j].CompareTo(currentPerson) == 0)
                        {
                            equal++;
                        }
                        else
                        {
                            notEqual++;
                        }
                    }
                }
            }
            if (notEqual == people.Count-1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equal}{notEqual}{people.Count}");
            }
        }
    }
}
