using System;
using System.Linq;

namespace _05.WordFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split();

            array = array.Where(x => x.Length % 2 == 0).ToArray();

            Console.WriteLine(string.Join("\n", array));
        }
    }
}
