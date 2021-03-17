using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RegEx1
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string pattern = @"([\|#])([A-Za-z\s]+)\1((?:(?:[0-2][1-9])|(?:3[0-2])|(?:[1-2]0))\/(?:(?:0[1-9])|(?:1[0-2]))\/[\d+]{2})\1(\d+)\1";

            Regex regex = new Regex(pattern);

            double sumAllFood = 0.00;
            double daysPossible = 0;

            MatchCollection matches = regex.Matches(text);

            foreach (Match item in matches)
            {
                sumAllFood += double.Parse(item.Groups[4].Value.ToString());
            }
            daysPossible = Math.Floor(sumAllFood / 2000);

            Console.WriteLine($"You have food to last you for: {daysPossible} days!");

            foreach (Match item in matches)
            {
                Console.WriteLine($"Item: {item.Groups[2]}, Best before: {item.Groups[3]}, Nutrition: {item.Groups[4]}");
            }
        }
    }
}
