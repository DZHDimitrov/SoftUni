using System;
using System.Linq;

namespace FunctionalProgramming
{

    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Reverse().ToArray();
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(string.Join(" ", array.Where(x => x % number != 0)));
        }
    }
}
