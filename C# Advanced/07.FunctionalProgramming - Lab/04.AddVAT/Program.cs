using System;
using System.Linq;

namespace FunctionalProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal[] array = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .Select(x => x * 1.20M)
                .ToArray();

            foreach (var item in array)
            {
                Console.WriteLine($"{item:F2}");
            }
        }

    }
}
