using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ThePianist
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([#@])([A-Za-z]{3,})\1\1([A-Za-z]{3,})\1";
            Regex regex = new Regex(pattern);

            string text = Console.ReadLine();

            MatchCollection matches = regex.Matches(text);
            List<string> validMatches = new List<string>();
            if (matches.Count > 0)
            {
                Console.WriteLine($"{matches.Count} word pairs found!");
                foreach (Match item in matches)
                {
                    string leftWord = item.Groups[2].Value;
                    string rightWordReversed = ReversedWord(item.Groups[3].Value);
                    if (leftWord == rightWordReversed)
                    {
                        string valid = $"{leftWord} <=> {item.Groups[3].Value}";
                        validMatches.Add(valid);
                    }
                }
            }
            else
            {
                Console.WriteLine("No word pairs found!");
            }

            if (validMatches.Count > 0)
            {
                Console.WriteLine("The mirror words are:");

                Console.WriteLine(string.Join(", ", validMatches));
            }
            else
            {
                Console.WriteLine("No mirror words!");
            }
        }
        static string ReversedWord(string text)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = text.Length - 1; i >= 0; i--)
            {
                sb.Append(text[i]);
            }
            string reversed = sb.ToString();

            return reversed;
        }

    }
}
