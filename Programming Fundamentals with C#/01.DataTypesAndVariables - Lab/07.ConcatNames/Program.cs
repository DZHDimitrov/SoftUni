using System;

namespace CSharpAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            string otherName = Console.ReadLine();
            string delimiter = Console.ReadLine();

            Console.WriteLine($"{name}" + $"{delimiter}" + $"{otherName}");

        }
    }
}