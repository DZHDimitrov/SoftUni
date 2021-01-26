using System;
using System.Collections.Generic;

namespace CSharpAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());
            int fourth = int.Parse(Console.ReadLine());

            double sum = first + second;
            sum /= third;
            sum *= fourth;
            Console.WriteLine(sum);
        }
    }
}