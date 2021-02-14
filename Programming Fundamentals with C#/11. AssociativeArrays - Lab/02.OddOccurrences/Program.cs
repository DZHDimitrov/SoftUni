using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            string[] line = Console.ReadLine().Split();

            for (int i = 0; i < line.Length; i++)
            {
                string word = line[i].ToLower();
                if (!dictionary.ContainsKey(word))
                {
                    dictionary.Add(word, 0);
                }
                dictionary[word]++;
            }
            foreach (var item in dictionary.Where(x => x.Value % 2 != 0))
            {
                Console.Write(item.Key + " ");
            }
        }
    }
}
