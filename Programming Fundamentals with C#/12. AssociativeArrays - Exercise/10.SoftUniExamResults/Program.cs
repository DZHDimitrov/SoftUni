using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> students = new Dictionary<string, int>();
            Dictionary<string, int> languageSub = new Dictionary<string, int>();

            string input = Console.ReadLine();

            while (input != "exam finished")
            {
                string[] cmdArg = input.Split('-');
                string name = cmdArg[0];
                if (cmdArg.Contains("banned"))
                {
                    students.Remove(name);
                    input = Console.ReadLine();
                    continue;
                }
                string language = cmdArg[1];
                int points = int.Parse(cmdArg[2]);

                if (!students.ContainsKey(name))
                {
                    students.Add(name, points);
                }
                else if (students.ContainsKey(name) && students[name] < points)
                {
                    students[name] = points;
                }
                if (!languageSub.ContainsKey(language))
                {
                    languageSub.Add(language,0);
                }
                languageSub[language]++;

                input = Console.ReadLine();
            }
            Console.WriteLine("Results:");
            foreach (var student in students.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{student.Key} | {student.Value}");
            }
            Console.WriteLine("Submissions:");
            foreach (var submission in languageSub.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{submission.Key} - {submission.Value}");
            }
        }
    }
}
