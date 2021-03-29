using System;
using System.Linq;

namespace FunctionalProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Func<int[], int> func = x => x.Length;
            Console.WriteLine(func(array));
            func = x => x.Sum();
            Console.WriteLine(func(array));

        }

    }
}
