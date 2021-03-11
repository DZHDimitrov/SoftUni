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
            string pattern = @"\b[A-Z][a-z]+\ [A-Z][a-z]+\b";
            string names = Console.ReadLine();

            MatchCollection matches = Regex.Matches(names, pattern);


            foreach (Match item in matches)
            {
                Console.Write(item.Value + " ");

            }
        }
    }
}
