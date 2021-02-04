using System;
using System.Collections.Generic;
using System.Linq;

namespace List_Manipulation_Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> integers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] data = input.Split();
                string command = data[0];
                switch (command)
                {
                    case "Add":
                        integers.Add(int.Parse(data[1]));
                        break;
                    case "Remove":
                        integers.Remove(int.Parse(data[1]));
                        break;
                    case "RemoveAt":
                        integers.RemoveAt(int.Parse(data[1]));
                        break;
                    case "Insert":
                        integers.Insert(int.Parse(data[2]), int.Parse(data[1]));
                        break;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", integers));
        }
    }
}
