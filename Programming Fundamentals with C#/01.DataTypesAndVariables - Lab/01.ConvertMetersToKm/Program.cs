using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            int meters = int.Parse(Console.ReadLine());
            decimal km = meters * 1.00M / 1000;
            Console.WriteLine($"{km:F2}");
        }
    }
}
