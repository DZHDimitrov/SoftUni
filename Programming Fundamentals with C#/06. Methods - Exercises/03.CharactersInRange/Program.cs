using System;
using System.Collections.Generic;

namespace _03.CharactersInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());

            List<char> symbols = new List<char>();

            if (first > second)
            {
                for (int i = (int)second +1; i < first; i++)
                {
                    symbols.Add((char)i);
                }
            }
            else if (first < second)
            {
                for (int i = (int)first + 1; i < second; i++)
                {
                    symbols.Add((char)i);
                }
            }
            Console.WriteLine(string.Join(" ", symbols));           
        }
    }
}
