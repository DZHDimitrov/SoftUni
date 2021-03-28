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
            string text = Console.ReadLine();

            Dictionary<char, int> allChars = new Dictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                if (!allChars.ContainsKey(text[i]))
                {
                    allChars.Add(text[i], 0);
                }
                allChars[text[i]]++;
            }
            foreach (var item in allChars.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
