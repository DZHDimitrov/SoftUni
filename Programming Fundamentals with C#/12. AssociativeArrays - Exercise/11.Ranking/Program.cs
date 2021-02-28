using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, string> contests = new Dictionary<string, string>();
            Dictionary<string, User> usersAndContsPoints = new Dictionary<string, User>();
            while (input != "end of contests")
            {
                string[] array = input.Split(":");
                string contest = array[0];
                string password = array[1];

                contests.Add(contest, password);

                input = Console.ReadLine();
            }

            string secondInput = Console.ReadLine();
            while (secondInput != "end of submissions")
            {
                string[] array = secondInput.Split("=>");

                string contest = array[0];
                string password = array[1];
                string user = array[2];
                int points = int.Parse(array[3]);

                bool isValidContest = contests.ContainsKey(contest);

                if (isValidContest)
                {
                    bool isValidPassword = contests[contest].Contains(password);
                    if (isValidPassword)
                    {
                        User currentUser = new User();
                        currentUser.ContestsAndP.Add(contest, points);
                        if (usersAndContsPoints.ContainsKey(user) &&
                            usersAndContsPoints[user].ContestsAndP.ContainsKey(contest) &&
                            usersAndContsPoints[user].ContestsAndP[contest] < points)
                        {
                            usersAndContsPoints[user].ContestsAndP[contest] = points;
                        }

                        else if (usersAndContsPoints.ContainsKey(user) &&
                            !usersAndContsPoints[user].ContestsAndP.ContainsKey(contest))

                        {
                            usersAndContsPoints[user].ContestsAndP.Add(contest, points);
                        }

                        else if (!usersAndContsPoints.ContainsKey(user))
                        {
                            usersAndContsPoints.Add(user, currentUser);
                        }
                    }

                }

                secondInput = Console.ReadLine();
            }

            string bestUser = "";
            int mostPoints = 0;

            foreach (var item in usersAndContsPoints)
            {
                if (item.Value.ContestsAndP.Values.Sum() > mostPoints)
                {
                    bestUser = item.Key;
                    mostPoints = item.Value.ContestsAndP.Values.Sum();
                }
            }

            Console.WriteLine($"Best candidate is {bestUser} with total {mostPoints} points.");
            Console.WriteLine("Ranking: ");

            foreach (var item in usersAndContsPoints.OrderBy(x => x.Key))
            {
                Console.WriteLine(item.Key);
                foreach (var contestAndPoints in usersAndContsPoints[item.Key].ContestsAndP.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contestAndPoints.Key} -> {contestAndPoints.Value}");
                }
            }
        }
    }
    class User
    {
        public Dictionary<string, int> ContestsAndP { get; set; }
        public User()
        {
            ContestsAndP = new Dictionary<string, int>();
        }
    }
}
    }
}
