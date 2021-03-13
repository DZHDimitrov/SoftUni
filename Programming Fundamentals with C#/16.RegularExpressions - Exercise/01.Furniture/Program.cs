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
            string pattern = @">>([A-Za-z]+)<<(\d+\.?\d*)!(\d+)";
            string input = Console.ReadLine();
            List<string> furnitures = new List<string>();

            double totalMoney = 0.00;

            while (input != "Purchase")
            {
                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    string furniture = match.Groups[1].Value;
                    double price = double.Parse(match.Groups[2].Value);
                    int quantity = int.Parse(match.Groups[3].Value);
                    totalMoney += price * quantity;

                    furnitures.Add(furniture);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine("Bought furniture:");
            if (furnitures.Count > 0)
            {
                foreach (var item in furnitures)
                {
                    Console.WriteLine(item);
                }
            }
            Console.WriteLine($"Total money spend: {totalMoney:f2}");

        }
    }
}
