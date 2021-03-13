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
            string namePattern = @"[A-Za-z]+";
            string distancePattern = @"\d+";
            string[] array = Console.ReadLine().Split(", ");
            Dictionary<string, int> participants = new Dictionary<string, int>();

            string input = Console.ReadLine();

            while (input != "end of race")
            {
                MatchCollection letters = Regex.Matches(input, namePattern);
                MatchCollection digits = Regex.Matches(input, distancePattern);
                string name = string.Join("", letters);
                string distanceText = string.Join("", digits);

                int sum = 0;

                foreach (var item in distanceText)
                {
                    sum += int.Parse(item.ToString());
                }

                if (array.Contains(name) && participants.ContainsKey(name))
                {
                    participants[name] += sum;
                }
                else if (array.Contains(name) && !participants.ContainsKey(name))
                {
                    participants.Add(name, sum);
                }

                input = Console.ReadLine();
            }
            int index = 1;
            foreach (var item in participants.OrderByDescending(x => x.Value))
            {
                string letters = index == 1 ? "st" : index == 2 ? "nd" : "rd";

                Console.WriteLine($"{index}{letters} place: {item.Key}");
                index++;
                if (index == 4)
                {
                    break;
                }
            }
        }
    }

}
