using System;
using System.Text;

namespace _3._Floating_Equality
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            int number = int.Parse(Console.ReadLine());
            int numberOfLetters = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLetters; i++)
            {
                char currentLetter = char.Parse(Console.ReadLine());
                int currentLetterNumber = currentLetter + number;
                sb.Append((char)currentLetterNumber);
            }

            Console.WriteLine(sb.ToString());
        }
    }
}