using System;
using System.Linq;

namespace FunctionalProgramming
{

    class Program
    {
        static void Main(string[] args)
        {
            Action<string> names = x => Console.WriteLine(x);

            string[] array = Console.ReadLine().Split();

            foreach (var item in array)
            {
                names(item);
            }
        }
    }
}
