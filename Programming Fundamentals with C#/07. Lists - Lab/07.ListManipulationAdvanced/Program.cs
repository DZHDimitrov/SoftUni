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
            bool areChanges = false;
            while (input != "end")
            {
                string[] data = input.Split();
                string command = data[0];
                switch (command)
                {
                    case "Add":
                        integers.Add(int.Parse(data[1]));
                        areChanges = true;
                        break;
                    case "Remove":
                        integers.Remove(int.Parse(data[1]));
                        areChanges = true;
                        break;
                    case "RemoveAt":
                        integers.RemoveAt(int.Parse(data[1]));
                        areChanges = true;
                        break;
                    case "Insert":
                        integers.Insert(int.Parse(data[2]), int.Parse(data[1]));
                        areChanges = true;
                        break;
                    case "Contains":
                        if (integers.Contains(int.Parse(data[1])))
                        {
                            Console.WriteLine("Yes");
                        }
                        else
                        {
                            Console.WriteLine("No such number");
                        }
                        break;
                    case "PrintEven":
                        var evenList = integers.Where(x => x % 2 == 0);
                        Console.WriteLine(string.Join(" ", evenList));
                        break;
                    case "PrintOdd":
                        var oddList = integers.Where(x => x % 2 != 0);
                        Console.WriteLine(string.Join(" ", oddList));
                        break;
                    case "GetSum":
                        Console.WriteLine(integers.Sum());
                        break;
                    case "Filter":
                        string sign = data[1];
                        int intFilter = int.Parse(data[2]);
                        if (sign == "<")
                        {
                            Console.WriteLine(string.Join(" ", integers.Where(x => x < intFilter)));
                        }
                        else if (sign == ">")
                        {
                            Console.WriteLine(string.Join(" ", integers.Where(x => x > intFilter)));
                        }
                        else if (sign == ">=")
                        {
                            Console.WriteLine(string.Join(" ", integers.Where(x => x >= intFilter)));
                        }
                        else if (sign == "<=")
                        {
                            Console.WriteLine(string.Join(" ", integers.Where(x => x <= intFilter)));
                        }
                        break;
                }
                input = Console.ReadLine();
            }

            if (areChanges)
            {
                Console.WriteLine(string.Join(" ", integers));
            }
        }
    }
}
