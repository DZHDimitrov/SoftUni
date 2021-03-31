using System;
using System.Linq;

namespace FunctionalProgramming
{

    class Program
    {
        static void Main(string[] args)
        {
            Action<string> names = Concatenate;
            string[] array = Console.ReadLine().Split();

            foreach (var item in array)
            {
                names(item);
            }


        }
        static void Concatenate(string name)
        {
            Console.WriteLine($"Sir {name}");
        }
    }
}
