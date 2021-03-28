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
            int lines = int.Parse(Console.ReadLine());
            HashSet<string> elements = new HashSet<string>();
            for (int i = 0; i < lines; i++)
            {
                string[] array = Console.ReadLine().Split(' ');
                for (int j = 0; j < array.Length; j++)
                {
                    elements.Add(array[j]);
                }
            }
            foreach (var item in elements.OrderBy(x => x))
            {
                Console.Write(item + " ");
            }
        }
    }
}
