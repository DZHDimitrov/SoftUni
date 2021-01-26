using System;
using System.Numerics;

namespace CSharpAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            BigInteger population = BigInteger.Parse(Console.ReadLine());
            int area = int.Parse(Console.ReadLine());

            Console.WriteLine($"Town {name} has population of {population} and area {area} square km.");

        }
    }
}