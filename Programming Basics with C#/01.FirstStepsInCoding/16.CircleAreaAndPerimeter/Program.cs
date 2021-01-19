using System;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            double r = double.Parse(Console.ReadLine());

            double circle = Math.PI * Math.Pow(r, 2);
            double circle1 = 2 * Math.PI * r;

            Console.WriteLine($"{circle:F2}");
            Console.WriteLine($"{circle1:F2}");

        }
    }
}