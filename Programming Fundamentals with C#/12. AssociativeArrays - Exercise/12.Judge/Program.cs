using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.Judge
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, List<Person>> contests = new Dictionary<string, List<Person>>();
            string input = Console.ReadLine();

            while (input != "no more time")
            {
                string[] cmdArgs = input.Split(" -> ",StringSplitOptions.RemoveEmptyEntries);

                string userName = cmdArgs[0];
                string contest = cmdArgs[1];
                int points = int.Parse(cmdArgs[2]);
                Person person = new Person(userName, points);
                if (!contests.ContainsKey(contest))
                {
                    contests.Add(contest, new List<Person>() { person});
                }
                else if (contests.ContainsKey(contest))
                {
                    if (contests[contest].Any(x=>x.Name==userName) && person.Points > contests[contest].FirstOrDefault(x=>x.Name==userName).Points)
                    {
                        contests[contest].FirstOrDefault(x => x.Name == userName).Points = person.Points;
                        
                    }
                    else if (!contests[contest].Any(x=>x.Name==userName))
                    {
                        contests[contest].Add(person);
                    }
                }

                
                
                input = Console.ReadLine();
            }
            int position = 1;
            foreach (var contest in contests)
            {
                Console.WriteLine($"{contest.Key}: {contest.Value.Count} participants");
                foreach (var person in contest.Value.OrderByDescending(x=>x.Points).ThenBy(x=>x.Name))
                {
                    Console.WriteLine($"{position}. {person.Name} <::> {person.Points}");
                    position++;
                }
                position = 1;
            }
            
            Console.WriteLine("Individual standings:");
            Dictionary<string, int> individualStandings = CreateIndividualStandings(contests);


            foreach (var person in individualStandings.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{position}. {person.Key} -> {person.Value}");
                position++;
            }
        }
        private static Dictionary<string,int> CreateIndividualStandings(Dictionary<string,List<Person>> contests)
        {
            Dictionary<string, int> individualStandingsReturn = new Dictionary<string, int>();

            foreach (var item in contests)
            {
                foreach (var list in item.Value)
                {
                    if (!individualStandingsReturn.ContainsKey(list.Name))
                    {
                        individualStandingsReturn.Add(list.Name, 0);
                    }
                    individualStandingsReturn[list.Name] += list.Points;
                }
            }
            return individualStandingsReturn;
        }
    }
    public class Person
    {
        public Person(string name, int points)
        {
            Name = name;
            Points = points;
        }
        public string Name { get; set; }
        public int Points { get; set; }
    }
}
