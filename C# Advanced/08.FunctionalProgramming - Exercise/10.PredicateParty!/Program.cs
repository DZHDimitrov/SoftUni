using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PredicateParty_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            Func<string, string, string, List<string>, List<string>> partyGuests = (a, b, c, guests) =>
            {
                if (a == "Remove")
                {
                    return b == "StartsWith" ? guests.Where(x => !x.StartsWith(c)).ToList() :
                    b == "EndsWith" ? guests.Where(x => !x.EndsWith(c)).ToList() :
                    b == "Length" ? guests.Where(x => x.Length != int.Parse(c)).ToList() : null;
                }
                else if (a == "Double")
                {
                    List<string> people = b == "StartsWith" ? guests.Where(x => x.StartsWith(c)).ToList() :
                    b == "EndsWith" ? guests.Where(x => x.EndsWith(c)).ToList() :
                    b == "Length" ? guests.Where(x => x.Length == int.Parse(c)).ToList() :
                    null;

                    foreach (var person in people)
                    {
                        var index = guests.IndexOf(person);
                        guests.Insert(index + 1, person);
                    }
                    return guests;
                }
                return null;
            };
            string line = Console.ReadLine();

            while (line != "Party!")
            {
                string[] cmdArgs = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = cmdArgs[0];
                string criteriaOne = cmdArgs[1];
                string criteriaTwo = cmdArgs[2];
                guests = partyGuests(command, criteriaOne, criteriaTwo, guests);

                line = Console.ReadLine();
            }
            if (guests.Count > 0)
            {
                Console.WriteLine(string.Join(", ", guests) + " " + "are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}
