using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CSharpAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            int infoIndex = int.Parse(Console.ReadLine());
            string line = Console.ReadLine();
            Dictionary<string, Dictionary<string, string>> names = new Dictionary<string, Dictionary<string, string>>();
            while (line != "end transmissions")
            {
                var pairs = line.Split('=');

                var allKeyValuePairs = pairs[1].Split(';');
                if (!names.ContainsKey(pairs[0]))
                {
                    names.Add(pairs[0].Trim(), new Dictionary<string, string>());
                }

                for (int i = 0; i < allKeyValuePairs.Length; i++)
                {
                    var currentKeyValue = allKeyValuePairs[i].Split(':');
                    if (!names[pairs[0]].ContainsKey(currentKeyValue[0].Trim()))
                    {
                        names[pairs[0]].Add(currentKeyValue[0].Trim(), currentKeyValue[1].Trim());
                    }
                    else
                    {
                        names[pairs[0]][currentKeyValue[0]] = currentKeyValue[1].Trim();
                    }
                }
                line = Console.ReadLine();
            }
            string[] killLine = Console.ReadLine().Split();
            string requiredName = killLine[1];
            int longestInfoIndex = 0;
            string keyOfLongestIndex = "";
            foreach (var name in names.Where(x => x.Key == requiredName))
            {
                var current = 0;
                foreach (var inner in name.Value)
                {
                    var test1 = inner.Key;
                    var test2 = inner.Value;
                    current += inner.Key.Length;
                    current += inner.Value.Length;
                }
                if (current > longestInfoIndex)
                {
                    longestInfoIndex = current;
                    keyOfLongestIndex = name.Key;
                }
            }

            foreach (var name in names.Where(x => x.Key == keyOfLongestIndex))
            {
                Console.WriteLine($"Info on {name.Key}:");
                foreach (var inner in name.Value.OrderBy(x => x.Key))
                {
                    Console.WriteLine($"---{inner.Key}: {inner.Value}");
                }
            }
            Console.WriteLine($"Info index: {longestInfoIndex}");
            var text = longestInfoIndex >= infoIndex ? "Proceed" : $"Need {infoIndex - longestInfoIndex} more info.";
            Console.WriteLine(text);
        }
    }
}