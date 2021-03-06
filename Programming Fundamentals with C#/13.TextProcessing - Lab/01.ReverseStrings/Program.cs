using System;
using System.Linq;

namespace _01.ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "end")
            {
                string word = input;
                Console.WriteLine($"{word} = {string.Join("",word.ToCharArray().Reverse().ToArray())}");
                input = Console.ReadLine();
            }
        }
    }
}
