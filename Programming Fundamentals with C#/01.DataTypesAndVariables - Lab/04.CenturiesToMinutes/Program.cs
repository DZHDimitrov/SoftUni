using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace CSharpAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int years = number * 100;
            int days = (int)(years * 365.2422);
            int hours = days * 24;
            int minutes = hours * 60;
            Console.WriteLine($"{number} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes");
        }
    }
}
