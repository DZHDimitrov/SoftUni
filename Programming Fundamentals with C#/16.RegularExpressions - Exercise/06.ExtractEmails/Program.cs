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
            string pattern = @"\s[a-z0-9]+[\.\-_]?[a-z0-9]+?@[A-Za-z]+\-?[a-z]*(?:\.[a-z]+){1,}\b";

            string text = Console.ReadLine();

            Regex regex = new Regex(pattern);

            MatchCollection emails = regex.Matches(text);

            foreach (Match item in emails)
            {
                Console.WriteLine(item.Value);
            }
        }

    }

}
