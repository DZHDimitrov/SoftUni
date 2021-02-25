using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Invetory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine().Split(", ").ToList();

            string input = Console.ReadLine();

            while (input != "Craft!")
            {
                string[] cmdArgs = input.Split(" - ");
                string command = cmdArgs[0];
                string item;
                string newItem;
                if (command == "Collect")
                {
                    item = cmdArgs[1];
                    if (!items.Contains(item))
                    {
                        items.Add(item);
                    }
                }
                else if (command == "Drop")
                {
                    item = cmdArgs[1];
                    if (items.Contains(item))
                    {
                        items.Remove(item);
                    }
                }
                else if (command == "Combine Items")
                {
                    item = cmdArgs[1];
                    string[] currentItem = item.Split(':');
                    item = currentItem[0];
                    newItem = currentItem[1];
                    if (items.Contains(item))
                    {
                        int indexOldItem = items.IndexOf(item);
                        if (indexOldItem == items.Count - 1)
                        {
                            items.Add(newItem);
                        }
                        else
                        {
                            items.Insert(indexOldItem + 1, newItem);
                        }
                    }
                }
                else if (command == "Renew")
                {
                    item = cmdArgs[1];
                    if (items.Contains(item))
                    {
                        items.Remove(item);
                        items.Add(item);
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(", ", items));
        }
    }
}
