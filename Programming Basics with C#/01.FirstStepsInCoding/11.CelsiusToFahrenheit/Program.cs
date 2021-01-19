using System;

namespace FinalEx
{
    class Program
    {
        static void Main(string[] args)
        {
            double C = double.Parse(Console.ReadLine());

            double F = (C / 5) * 9 + 32;
            Console.WriteLine($"{F:F2}");
        }
    }
}
