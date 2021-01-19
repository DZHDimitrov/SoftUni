using System;

namespace FinalEx
{
    class Program
    {
        static void Main(string[] args)
        {
            double height = double.Parse(Console.ReadLine());
            double side = double.Parse(Console.ReadLine());

            double result = side * height / 2;

            Console.WriteLine($"{result:F2}");
        }
    }
}
