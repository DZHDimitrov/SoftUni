using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            Family family = new Family();
            for (int i = 0; i < lines; i++)
            {
                string[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Person person = new Person(data[0],int.Parse(data[1]));
                family.AddMember(person);
            }
            var oldest = family.GetOldestMember(family.FamilyList);
            Console.WriteLine($"{oldest.Name} {oldest.Age}");


        }
    }
}
