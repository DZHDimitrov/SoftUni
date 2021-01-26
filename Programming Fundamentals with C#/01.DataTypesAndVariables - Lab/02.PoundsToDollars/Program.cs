using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal pounds = decimal.Parse(Console.ReadLine());
            double dollar = 1.31;

            Console.WriteLine($"{pounds * (decimal)dollar:F3}");
        }
    }
}
