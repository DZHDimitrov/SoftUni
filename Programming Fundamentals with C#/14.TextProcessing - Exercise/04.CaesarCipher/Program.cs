using System;
using System.Text;

namespace _04.CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                string currentText = ((char)(text[i]+3)).ToString();
                sb.Append(currentText);
            }
            text = sb.ToString();
            Console.WriteLine(text);
        }
    }
}
