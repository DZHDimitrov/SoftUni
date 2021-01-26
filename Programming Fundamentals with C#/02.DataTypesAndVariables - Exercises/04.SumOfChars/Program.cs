using System;
using System.Linq;

namespace CSharpAdvanced___2
{
    class Program
    {
        static void Main(string[] args)
        {
            int chars = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 0; i < chars; i++)
            {
                char currentChar = char.Parse(Console.ReadLine());
                sum += currentChar;
            }
            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}
