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
            int messages = int.Parse(Console.ReadLine());
            string patternForLetters = @"[star]";
            string patternForDecryptedMessage = @"@([A-Z][a-z]+)[^@,\-!:>]*:(\d+)[^@,\-!:>]*!([A|D])![^@,\-!:>]*->(\d+)";
            Dictionary<string, List<string>> planets = new Dictionary<string, List<string>>();
            planets.Add("Attacked", new List<string>());
            planets.Add("Destroyed", new List<string>());

            for (int i = 0; i < messages; i++)
            {
                string text = Console.ReadLine();
                MatchCollection allNeededLetters = Regex.Matches(text, patternForLetters, RegexOptions.IgnoreCase);
                string letters = string.Join("", allNeededLetters);
                string decryptedText = Decryption(text, letters);
                Match message = Regex.Match(decryptedText, patternForDecryptedMessage);

                if (message.Success)
                {
                    switch (message.Groups[3].Value)
                    {
                        case "A":
                            planets["Attacked"].Add(message.Groups[1].Value);
                            break;
                        case "D":
                            planets["Destroyed"].Add(message.Groups[1].Value);
                            break;
                    }
                }
            }
            Console.WriteLine($"Attacked planets: {planets["Attacked"].Count}");
            foreach (var item in planets["Attacked"].OrderBy(x => x))
            {
                Console.WriteLine($"-> {item}");
            }
            Console.WriteLine($"Destroyed planets: {planets["Destroyed"].Count}");
            foreach (var item in planets["Destroyed"].OrderBy(x => x))
            {
                Console.WriteLine($"-> {item}");
            }
        }

        static string Decryption(string text, string letters)
        {
            char[] array = new char[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                int number = text[i] - letters.Length;
                array[i] = (char)number;
            }

            return string.Join("", array);
        }
    }




}
