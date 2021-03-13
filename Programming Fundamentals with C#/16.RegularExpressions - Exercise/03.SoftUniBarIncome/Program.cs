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
            string pattern = @"%([A-Z][a-z]+)%[^|%$.]*<(\w+)>[^|%$.]*\|(\d+)\|[^|%$.]*?(\d+\.?\d*)\$";

            Regex regex = new Regex(pattern);
            double income = 0.00;
            string input = Console.ReadLine();

            while (input != "end of shift")
            {
                Match match = regex.Match(input);

                if (match.Success)
                {
                    Person person = new Person(match.Groups[1].Value, match.Groups[2].Value, double.Parse(match.Groups[4].Value) * int.Parse(match.Groups[3].Value));

                    income += int.Parse(match.Groups[3].Value) * double.Parse(match.Groups[4].Value);

                    Console.WriteLine(person);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Total income: {income:F2}");
        }
    }
    class Person
    {
        public string Name { get; set; }
        public string Product { get; set; }

        public double PriceForAll { get; set; }

        public Person(string name, string product, double price)
        {
            Name = name;
            Product = product;
            PriceForAll = price;
        }

        public override string ToString()
        {
            return $"{Name}: {Product} - {PriceForAll:F2}";
        }
    }

}
