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
            int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            HashSet<int> set = new HashSet<int>();
            HashSet<int> setTwo = new HashSet<int>();
            HashSet<int> duplicates = new HashSet<int>();

            for (int i = 0; i < numbers[0]; i++)
            {
                set.Add(int.Parse(Console.ReadLine()));
            }
            for (int i = 0; i < numbers[1]; i++)
            {
                setTwo.Add(int.Parse(Console.ReadLine()));
            }

            foreach (var item in set)
            {
                if (setTwo.Contains(item))
                {
                    Console.Write(item + " ");
                }
            }
        }
    }
}
