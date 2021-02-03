using System;

namespace _02.VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int vowels = CountVowels(text);
            Console.WriteLine(vowels);
        }
        static int CountVowels(string text)
        {
            int counter = 0;
            for (int i = 0; i < text.Length; i++)
            {
                string currentLetter = text[i].ToString().ToLower();
                switch (currentLetter)
                {
                    case "a":
                    case "o":
                    case "u":
                    case "e":
                    case "i":
                    case "y":
                        counter++;
                        break;
                }
            }
            return counter;
        }
    }
}
