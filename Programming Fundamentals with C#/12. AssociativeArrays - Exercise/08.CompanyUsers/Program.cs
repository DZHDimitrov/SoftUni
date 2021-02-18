using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<string>> companies = new Dictionary<string, HashSet<string>>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] cmdArgs = input.Split(" -> ");
                string companyName = cmdArgs[0];
                string id = cmdArgs[1];
                if (!companies.ContainsKey(companyName))
                {
                    companies.Add(companyName, new HashSet<string>());
                }
                companies[companyName].Add(id);

                input = Console.ReadLine();
            }

            foreach (var company in companies.OrderBy(x=>x.Key))
            {
                Console.WriteLine(company.Key);
                foreach (var id in company.Value)
                {
                    Console.WriteLine($"-- {id}");
                }
            }
        }
    }
}
