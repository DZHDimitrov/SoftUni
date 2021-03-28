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
            int lines = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> clothes = new Dictionary<string, Dictionary<string, int>>();
            for (int i = 0; i < lines; i++)
            {
                string[] array = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = array[0];

                if (!clothes.ContainsKey(color))
                {
                    clothes.Add(color, new Dictionary<string, int>());
                }
                string[] dressArray = array[1].Split(',');

                for (int j = 0; j < dressArray.Length; j++)
                {
                    string currentDress = dressArray[j];
                    if (!clothes[color].ContainsKey(currentDress))
                    {
                        clothes[color].Add(currentDress, 0);
                    }
                    clothes[color][currentDress]++;
                }
            }

            string[] dressToBeFound = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in clothes)
            {
                Console.WriteLine($"{item.Key} clothes:");
                foreach (var dress in item.Value)
                {
                    if (item.Key == dressToBeFound[0] && dress.Key == dressToBeFound[1])
                    {
                        Console.WriteLine($"* {dress.Key} - {dress.Value} (found!)");
                        continue;
                    }
                    Console.WriteLine($"* {dress.Key} - {dress.Value}");
                }
            }
        }
    }
}
