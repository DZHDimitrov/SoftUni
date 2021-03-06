using System;
using System.Text;

namespace _04.TextFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine().Split(", ");

            string text = Console.ReadLine();
            for (int i = 0; i < bannedWords.Length; i++)
            {
                if (text.Contains(bannedWords[i]))
                {
                    text = text.Replace(bannedWords[i], GetAestriksForWord(bannedWords[i]));
                }
            }
            Console.WriteLine(text);
        }
        private static string GetAestriksForWord(string word)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < word.Length; i++)
            {
                sb.Append('*');
            }
            return sb.ToString();
        }
    }
}
