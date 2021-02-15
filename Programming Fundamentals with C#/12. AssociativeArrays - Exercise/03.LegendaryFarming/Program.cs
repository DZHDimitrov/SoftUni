using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> items = new Dictionary<string, int>();
            items.Add("fragments", 0);
            items.Add("motes", 0);
            items.Add("shards", 0);
            bool isFound = false;
            while (true)
            {
                string[] data = Console.ReadLine().Split();

                for (int i = 0; i < data.Length; i+=2)
                {
                    int quantity = int.Parse(data[i]);
                    string item = data[i+1].ToLower();

                    if (!items.ContainsKey(item))
                    {
                        items.Add(item, 0);
                    }
                    items[item] += quantity;

                    if (item == "shards" && items[item] >= 250)
                    {
                        Console.WriteLine("Shadowmourne obtained!");
                        isFound = true;
                        items[item] -= 250;
                        break;
                    }
                    else if (item == "fragments" && items[item] >= 250)
                    {
                        Console.WriteLine("Valanyr obtained!");
                        isFound = true;
                        items[item] -= 250;
                        break;
                    }
                    else if (item == "motes" && items[item] >= 250)
                    {
                        Console.WriteLine("Dragonwrath obtained!");
                        isFound = true;
                        items[item] -= 250;
                        break;
                    } 
                }
                if (isFound)
                {
                    break;
                }
            }
            Dictionary<string, int> imporantOnes = new Dictionary<string, int>();
            foreach (var item in items)
            {
                if (item.Key == "shards" || item.Key == "fragments" || item.Key == "motes")
                {
                    imporantOnes.Add(item.Key,item.Value);
                }
            }
            Dictionary<string, int> unimportantOnes = new Dictionary<string, int>();
            foreach (var item in items)
            {
                if (item.Key != "shards" && item.Key != "fragments" && item.Key != "motes")
                {
                    unimportantOnes.Add(item.Key, item.Value);
                }
            }

            foreach (var item in imporantOnes.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            foreach (var item in unimportantOnes.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
        
    }
}
