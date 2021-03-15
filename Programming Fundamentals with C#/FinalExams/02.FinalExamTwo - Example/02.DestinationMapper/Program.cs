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
            string text = Console.ReadLine();
            string pattern = @"([=\/])([A-Z][A-Za-z]{2,})\1";
            List<string> destinations = new List<string>();

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(text);

            foreach (Match item in matches)
            {
                destinations.Add(item.Groups[2].Value);
            }

            string allSymbols = string.Join("", destinations);
            int points = allSymbols.Length;
            Console.WriteLine($"Destinations: { string.Join(", ", destinations)}");
            Console.WriteLine($"Travel Points: {points}");
        }
    }
}
