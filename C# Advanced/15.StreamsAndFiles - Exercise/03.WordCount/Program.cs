using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../Files/words.txt");
            var words = new Dictionary<string, int>();
            for (int i = 0; i < lines.Length; i++)
            {
                if (!words.ContainsKey(lines[i]))
                {
                    words.Add(lines[i].ToLower(), 0);
                }
            }

            string[] allText = File.ReadAllLines("../../../Files/text.txt");

            for (int i = 0; i < allText.Length; i++)
            {
                string[] currentLine = allText[i].Split(" ");
                for (int j = 0; j < currentLine.Length; j++)
                {
                    if (words.ContainsKey(currentLine[j].ToLower().Trim(new char[] { '.', '?', '!', '-', '\'', ' ',',' })))
                    {
                        words[currentLine[j].ToLower().Trim(new char[] { '.','?','!','-','\'',' ',','})]++;
                    }
                }
            }

            foreach (var item in words.OrderByDescending(x=> x.Value))
            {
                File.AppendAllText("../../../Files/actual.txt",$"{item.Key} - {item.Value}\n");
            }
        }
    }
}
