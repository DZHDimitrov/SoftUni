using System;
using System.Collections.Generic;
using System.Linq;

namespace ComparingObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<Person> peopleSet = new HashSet<Person>();

            SortedSet<Person> peopleSorted = new SortedSet<Person>();

            int people = int.Parse(Console.ReadLine());

            for (int i = 0; i < people; i++)
            {
                string[] data = Console.ReadLine().Split();

                Person person = new Person(data[0], int.Parse(data[1]));
                var hashcode = person.GetHashCode();

                if (!peopleSet.Any(x=>x == person))
                {
                    peopleSet.Add(person);
                }
                if (!peopleSorted.Any(x=>x == person))
                {
                    peopleSorted.Add(person);
                }
            }

            Console.WriteLine(peopleSet.Count);
            Console.WriteLine(peopleSorted.Count);
        }
    }
}
