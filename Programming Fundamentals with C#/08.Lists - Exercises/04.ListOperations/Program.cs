using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] data = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = data[0];

                switch (command)
                {
                    case "Add":
                        list.Add(int.Parse(data[1]));
                        break;
                    case "Insert":
                        int index = int.Parse(data[2]);
                        if (index < 0 || index > list.Count - 1)
                        {
                            Console.WriteLine("Invalid index");
                            input = Console.ReadLine();
                            continue;
                        }
                        list.Insert(int.Parse(data[2]), int.Parse(data[1]));
                        break;
                    case "Remove":
                        int curIndex = int.Parse(data[1]);
                        if (curIndex < 0 || curIndex > list.Count - 1)
                        {
                            Console.WriteLine("Invalid index");
                            input = Console.ReadLine();
                            continue;
                        }
                        list.RemoveAt(curIndex);
                        break;
                    case "Shift":
                        if (data[1] == "left")
                        {
                            for (int i = 0; i < int.Parse(data[2]); i++)
                            {
                                int item = list[0];
                                list.RemoveAt(0);
                                list.Add(item);
                            }
                        }
                        else if (data[1] == "right")
                        {
                            for (int i = 0; i < int.Parse(data[2]); i++)
                            {
                                int item = list[list.Count - 1];
                                list.RemoveAt(list.Count - 1);
                                list.Insert(0, item);
                            }
                        }
                        break;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", list));

        }

    }
}
