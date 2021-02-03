using System;

namespace _07.NxN_Matrix_
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            PrintOutput(input);
        }
        static void PrintOutput(string text)
        {
            if (text.Length % 2 == 0)
            {
                Console.WriteLine($"{text[text.Length / 2 - 1]}{text[text.Length / 2]}");
            }
            else if (text.Length % 2 != 0)
            {
                Console.WriteLine(text[text.Length / 2]);
            }
        }
    }
}
