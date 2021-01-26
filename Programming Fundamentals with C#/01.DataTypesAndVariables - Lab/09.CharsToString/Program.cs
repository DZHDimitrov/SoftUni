using System;
using System.Numerics;

namespace CSharpAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            char symbol = char.Parse(Console.ReadLine());
            char symbol1 = char.Parse(Console.ReadLine());
            char symbol2 = char.Parse(Console.ReadLine());
            string text = symbol.ToString() + symbol1.ToString() + symbol2.ToString();
            Console.WriteLine(text);

        }
    }
}