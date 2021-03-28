using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace _01.DayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, HashSet<string>> vloggers = new Dictionary<string, HashSet<string>>();
            Dictionary<string, HashSet<string>> following = new Dictionary<string, HashSet<string>>();

            while (input != "Statistics")
            {
                string[] array = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = array[0];
                string command = array[1];

                if (command == "joined" && !vloggers.ContainsKey(name))
                {
                    vloggers.Add(name, new HashSet<string>());
                    following.Add(array[0], new HashSet<string>());
                }

                else if (command == "followed")
                {
                    if (vloggers.ContainsKey(array[0]) && vloggers.ContainsKey(array[2]) && array[0] != array[2])
                    {
                        vloggers[array[2]].Add(array[0]);
                        following[array[0]].Add(array[2]);
                    }

                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");
            int index = 1;
            foreach (var item in vloggers.OrderByDescending(x => x.Value.Count).ThenBy(x => following[x.Key].Count))
            {
                foreach (var itm in following)
                {
                    if (itm.Key == item.Key)
                    {
                        Console.WriteLine($"{index}. {item.Key} : {item.Value.Count} followers, {itm.Value.Count} following");
                    }
                }

                if (index == 1)
                {
                    foreach (var itm in item.Value.OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {itm}");
                    }
                }
                index++;
            }

        }

    }
}
