using System;
using System.Linq;

namespace FunctionalProgramming
{

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();

            Console.WriteLine(string.Join("\n", names.Where(x => x.Length <= n)));
        }
    }
}
