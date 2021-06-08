using System;
using System.IO;
using System.Linq;

namespace _02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = File.ReadAllLines("../../../Files/text.txt");
            string[] punctuationMarks = { ",", "!", ".", "?", ":", ";", "-", "'" };

            for (int i = 0; i < arr.Length; i++)
            {
                string currentLine = arr[i];
                int letters = CountOfLetters(currentLine);
                int punctuations = CountOfPunctuationMarks(currentLine, punctuationMarks);
                Console.WriteLine($"{currentLine}" + $"({letters})/({punctuations})");
            }
        }

        public static int CountOfLetters(string currentLine)
        {
            int count = 0;
            for (int i = 0; i < currentLine.Length; i++)
            {
                if (Char.IsLetter(currentLine[i]))
                {
                    count++;
                }
            }
            return count;
        }
        public static int CountOfPunctuationMarks(string currentLine, string[] punctuationMarks)
        {
            int count = 0;

            for (int i = 0; i < currentLine.Length; i++)
            {
                if (punctuationMarks.Contains(currentLine[i].ToString()))
                {
                    count++;
                }
            }
            return count;
        }
    }
}
