using System;
using System.Linq;

namespace FunctionalProgramming
{
    class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            Person[] people = new Person[number];
            for (int i = 0; i < people.Length; i++)
            {
                string[] array = Console.ReadLine().Split(", ");
                people[i] = new Person { Name = array[0], Age = int.Parse(array[1]) };
            }

            string condition = Console.ReadLine();
            int ageFilter = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<Person, bool> conditionDelegate = GetCondition(condition, ageFilter);
            Action<Person> filterDelegate = Printer(format);

            foreach (var item in people)
            {
                if (conditionDelegate(item))
                {
                    filterDelegate(item);
                }
            }
        }


        static Action<Person> Printer(string format)
        {
            switch (format)
            {
                case "name age":
                    return x =>
                    {
                        Console.WriteLine($"{x.Name} - {x.Age}");
                    };
                case "name":
                    return x =>
                    {
                        Console.WriteLine(x.Name);
                    };
                case "age":
                    return x =>
                    {
                        Console.WriteLine(x.Age);
                    };
                default:
                    return null;
            }
        }
        static Func<Person, bool> GetCondition(string condition, int age)
        {
            switch (condition)
            {
                case "older": return x => x.Age >= age;
                case "younger": return x => x.Age < age;

                default:
                    return null;
            }
        }
    }
}
