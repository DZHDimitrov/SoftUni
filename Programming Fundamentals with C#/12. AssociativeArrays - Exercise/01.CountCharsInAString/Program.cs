using System;
using System.Collections.Generic;

namespace _01.CountCharsInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<Char, int> dictionary = new Dictionary<char, int>();
            string[] text = Console.ReadLine().Split();

            for (int i = 0; i < text.Length; i++)
            {
                string currentword = text[i];
                for (int j = 0; j < currentword.Length; j++)
                {
                    if (!dictionary.ContainsKey(currentword[j]))
                    {
                        dictionary.Add(currentword[j], 0);
                    }
                    dictionary[currentword[j]]++;
                }
            }
            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
