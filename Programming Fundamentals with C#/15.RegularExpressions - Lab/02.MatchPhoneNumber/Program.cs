using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace RegEx1
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\+359([\ |\-])2\1(\d{3})\1(\d{4})\b";

            string numbers = Console.ReadLine();

            MatchCollection matches = Regex.Matches(numbers, pattern);

            List<string> numbersList = new List<string>();
            foreach (Match item in matches)
            {
                numbersList.Add(item.Value);
            }
            Console.WriteLine(string.Join(", ", numbersList));
        }
    }
}
