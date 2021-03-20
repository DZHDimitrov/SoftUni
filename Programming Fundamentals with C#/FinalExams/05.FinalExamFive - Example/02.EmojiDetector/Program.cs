using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string pattern = @"((?:[*]{2})|(?:[\:]{2}))([A-Z][a-z]{2,})\1";
            string patternForNumbers = @"(\d+)";

            Regex regex = new Regex(patternForNumbers);
            MatchCollection textForNumbers = regex.Matches(text);

            ulong coolTreshold = FindCoolTreshold(textForNumbers);

            regex = new Regex(pattern);
            MatchCollection regexCollection = regex.Matches(text);

            int emojiCharSum = 0;

            List<string> matches = new List<string>();
            List<string> coolEmojies = new List<string>();

            foreach (Match match in regexCollection)
            {
                string emoji = match.Groups[2].Value;
                emojiCharSum += AsciiSumOfEmojies(emoji);
                string fullText = match.Groups[1].Value + match.Groups[2].Value + match.Groups[1].Value;
                matches.Add(fullText);
                if ((ulong)emojiCharSum > coolTreshold)
                {
                    coolEmojies.Add(fullText.Trim());
                }
                emojiCharSum = 0;
            }
            Console.WriteLine($"Cool threshold: {coolTreshold}");
            Console.WriteLine($"{matches.Count} emojis found in the text. The cool ones are:");
            foreach (string emoji in coolEmojies)
            {
                Console.WriteLine(emoji);
            }
        }
        private static ulong FindCoolTreshold(MatchCollection matches)
        {
            ulong coolTreshold = 1;
            foreach (Match match in matches)
            {
                foreach (var item in match.Groups[1].Value)
                {
                    coolTreshold *= ulong.Parse(item.ToString());
                }
            }
            return coolTreshold;

        }
        private static int AsciiSumOfEmojies(string emoji)
        {
            int sum = 0;

            foreach (var item in emoji)
            {
                sum += item;
            }
            return sum;
        }
    }
}
