using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace _01.DayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, string> contests = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> users = new Dictionary<string, Dictionary<string, int>>();
            while (input != "end of contests")
            {
                string[] array = input.Split(':', StringSplitOptions.RemoveEmptyEntries);
                contests.Add(array[0], array[1]);

                input = Console.ReadLine();
            }

            string anotherInput = Console.ReadLine();
            while (anotherInput != "end of submissions")
            {
                string[] array = anotherInput.Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string contest = array[0];
                string password = array[1];
                string name = array[2];
                int points = int.Parse(array[3]);

                if (contests.ContainsKey(contest) && contests[contest] == password)
                {
                    if (!users.ContainsKey(name))
                    {
                        users.Add(name, new Dictionary<string, int>());
                    }

                    if (!users[name].ContainsKey(contest))
                    {
                        users[name].Add(contest, points);
                    }

                    if (users[name][contest] < points)
                    {
                        users[name][contest] = points;
                    }
                }
                anotherInput = Console.ReadLine();
            }
            string bestStudent = "";
            int sum = 0;
            foreach (var item in users.OrderByDescending(x => x.Value.Values.Sum()))
            {
                bestStudent = item.Key;
                sum = item.Value.Values.Sum();
                break;
            }
            Console.WriteLine($"Best candidate is {bestStudent} with total {sum} points.");
            Console.WriteLine("Ranking:");
            foreach (var item in users.OrderBy(x => x.Key))
            {
                Console.WriteLine(item.Key);
                foreach (var contest in item.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }

    }
}
