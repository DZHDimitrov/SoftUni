using System;
using System.Collections.Generic;

namespace _02.AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            string input = Console.ReadLine();

            int index = 1;
            string lastItem = null;
            while (input != "stop")
            {

                if (index % 2 != 0)
                {
                    string resource = input;
                    if (!dictionary.ContainsKey(resource))
                    {
                        dictionary.Add(resource, 0);
                    }
                    lastItem = resource;
                }
                if (index % 2 == 0)
                {
                    dictionary[lastItem] += int.Parse(input);
                }
                index++;
                input = Console.ReadLine();
            }
            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
