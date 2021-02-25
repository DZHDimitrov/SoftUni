using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ShoppingList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> groceries = Console.ReadLine().Split('!', StringSplitOptions.RemoveEmptyEntries).ToList();

            string input = Console.ReadLine();

            while (input != "Go Shopping!")
            {
                string[] cmdArgs = input.Split();
                string command = cmdArgs[0];
                string item = cmdArgs[1];

                switch (command)
                {
                    case "Urgent":
                        if (!groceries.Contains(item))
                        {
                            groceries.Insert(0, item);
                        }
                        break;
                    case "Unnecessary":
                        if (groceries.Contains(item))
                        {
                            groceries.Remove(item);
                        }
                        break;
                    case "Correct":
                        if (groceries.Contains(item))
                        {
                            string newItem = cmdArgs[2];
                            int index = groceries.IndexOf(item);
                            groceries[index] = newItem;
                        }
                        break;
                    case "Rearrange":
                        if (groceries.Contains(item))
                        {
                            groceries.Remove(item);
                            groceries.Add(item);
                        }
                        break;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(", ", groceries));
        }
    }
}
