using System;
using System.Text.RegularExpressions;

namespace CSharpAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(@#+)([A-Z][A-Za-z0-9]{4,}[A-Z]@#+)";
            int messages = int.Parse(Console.ReadLine());

            for (int i = 0; i < messages; i++)
            {
                string text = Console.ReadLine();

                Regex regex = new Regex(pattern);

                Match match = regex.Match(text);

                if (match.Success)
                {
                    string word = match.Groups[2].Value;
                    bool areDigits = false;
                    string group = "";
                    for (int j = 0; j < word.Length; j++)
                    {
                        if (Char.IsDigit(word[j]))
                        {
                            group += word[j];
                            areDigits = true;
                        }
                    }
                    if (areDigits)
                    {
                        Console.WriteLine($"Product group: {group}");
                    }
                    else
                    {
                        group = "00";
                        Console.WriteLine($"Product group: {group}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}