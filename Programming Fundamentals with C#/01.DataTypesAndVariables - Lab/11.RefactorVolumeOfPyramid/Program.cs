using System;
using System.Numerics;

namespace CSharpAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            Console.Write($"Length: ");
            double width = double.Parse(Console.ReadLine());
            Console.Write($"Width: ");
            double height = double.Parse(Console.ReadLine());
            Console.Write($"Height: ");
            double volume = ((length * width * height) * 1.00) / 3;
            Console.WriteLine($"Pyramid Volume: {volume:F2}");
        }
    }
}