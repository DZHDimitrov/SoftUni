using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] arr = input.Split();
                string command = arr[0];

                if (command == "Delete")
                {
                    list.RemoveAll(x => x == int.Parse(arr[1]));
                }
                else if (command == "Insert")
                {
                    list.Insert(int.Parse(arr[2]), int.Parse(arr[1]));
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", list));

        }

    }
}
