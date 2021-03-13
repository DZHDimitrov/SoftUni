using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace RegEx1
{
    class Demon
    {
        public string Name { get; set; }
        public int Health { get; set; }

        public double Attack { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Health} health, {Attack:F2} damage";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string patternName = @"[0-9\+\-\*\/\.]";
            string patternDamage = @"[+-]?\d+\.?\d*";

            string[] demons = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            List<Demon> allDemons = new List<Demon>();

            for (int i = 0; i < demons.Length; i++)
            {
                string healthLetters = Regex.Replace(demons[i], patternName, "");
                Demon demon = new Demon();
                demon.Name = demons[i];
                foreach (var item in healthLetters)
                {
                    demon.Health += item;
                }
                Regex regex = new Regex(patternDamage);
                demon.Attack = DamageCalculation(demons[i], regex);
                allDemons.Add(demon);
            }
            foreach (Demon demon in allDemons.OrderBy(x => x.Name))
            {
                Console.WriteLine(demon);
            }

        }
        public static double DamageCalculation(string name, Regex takedigits)
        {
            double sum = 0.00;

            MatchCollection values = takedigits.Matches(name);
            foreach (Match item in values)
            {
                sum += double.Parse(item.ToString());
            }

            if (name.Contains('*'))
            {
                foreach (var item in name)
                {
                    if (item == '*')
                    {
                        sum *= 2;
                    }
                }
            }

            if (name.Contains('/'))
            {
                foreach (var item in name)
                {
                    if (item == '/')
                    {
                        sum /= 2;
                    }
                }
            }

            return sum;
        }
    }
}
