using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> forceSides = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "Lumpawaroo")
            {
                string[] cmdArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string forceSide;
                string forceUser;
                string modifyArray;

                if (cmdArgs.Contains("|"))
                {
                    modifyArray = string.Join(" ", cmdArgs);
                    cmdArgs = modifyArray.Split("|", StringSplitOptions.RemoveEmptyEntries);
                    forceSide = cmdArgs[0].TrimEnd(' ');
                    forceUser = cmdArgs[1].TrimStart(' ');
                    if (!forceSides.ContainsKey(forceSide))
                    {
                        forceSides.Add(forceSide, new List<string>());
                    }

                    if (!forceSides[forceSide].Contains(forceUser) && !forceSides.Values.Any(x => x.Contains(forceUser)))
                    {
                        forceSides[forceSide].Add(forceUser);
                    }
                }
                else if (cmdArgs.Contains("->"))
                {
                    modifyArray = string.Join(" ", cmdArgs);
                    cmdArgs = modifyArray.Split("->", StringSplitOptions.RemoveEmptyEntries);
                    forceUser = cmdArgs[0].TrimEnd(' ');
                    forceSide = cmdArgs[1].TrimStart(' ');

                    if (!forceSides.Any(x => x.Value.Contains(forceUser)))
                    {
                        if (!forceSides.ContainsKey(forceSide))
                        {

                            forceSides.Add(forceSide, new List<String>());
                        }

                        forceSides[forceSide].Add(forceUser);
                        Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                    }
                    else
                    {
                        foreach (var s in forceSides)
                        {
                            if (s.Value.Contains(forceUser))
                            {
                                s.Value.Remove(forceUser);
                            }
                        }

                        if (forceSides.ContainsKey(forceSide) == false)
                        {
                            forceSides.Add(forceSide, new List<string>());
                        }
                        forceSides[forceSide].Add(forceUser);
                        Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                    }
                }
                input = Console.ReadLine();
            }
            foreach (var item in forceSides.Where(x => x.Value.Count > 0).OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {

                Console.WriteLine($"Side: {item.Key}, Members: {item.Value.Count}");
                foreach (var forceUser in item.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"! {forceUser}");
                }

            }
        }          
    }
}