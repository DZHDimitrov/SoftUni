using System;
using System.Collections.Generic;
using System.Linq;

namespace FunctionalProgramming
{

    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split().ToList();
            List<string> filters = new List<string>();

            string input = Console.ReadLine();

            while (input != "Print")
            {
                string[] data = input.Split(';');
                input = input.Substring(data[0].Length + 1);
                string command = data[0];
                string filter = data[1];
                string format = data[2];

                if (command == "Add filter")
                {
                    filters.Add(input);
                }
                else if (command == "Remove filter")
                {
                    filters.Remove(input);
                }
                input = Console.ReadLine();
            }
            for (int i = 0; i < filters.Count; i++)
            {
                string[] arr = filters[i].Split(';');
                if (arr[0] == "Starts with")
                {
                    names = names.Where(x => !x.StartsWith(arr[1])).ToList();
                }
                else if (arr[0] == "Ends with")
                {
                    names = names.Where(x => !x.EndsWith(arr[1])).ToList();
                }
                else if (arr[0] == "Length")
                {
                    names = names.Where(x => x.Length != int.Parse(arr[1])).ToList();
                }
                else if (arr[0] == "Contains")
                {
                    names = names.Where(x => !x.Contains(arr[1])).ToList();
                }
            }
            Console.WriteLine(string.Join(" ", names));
        }

    }
}
