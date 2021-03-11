using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace RegEx1
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"((?:0[1-9])|(?:[1-2][0-9])|(?:3[0-1]))([\/\.\-])([A-Z][a-z]{2})\2(\d{4})\b";

            string numbers = Console.ReadLine();

            MatchCollection matches = Regex.Matches(numbers, pattern);

            foreach (Match item in matches)
            {
                Console.WriteLine($"Day: {item.Groups[1]}, Month: {item.Groups[3]}, Year: {item.Groups[4]}");
            }

        }
    }
}
