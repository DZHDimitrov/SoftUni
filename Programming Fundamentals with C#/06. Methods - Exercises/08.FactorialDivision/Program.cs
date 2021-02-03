using System;

namespace _08.FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());

            decimal firstFactorial = 1;
            decimal secondFactorial = 1;

            for (int i = 1; i <= first; i++)
            {
                firstFactorial *= i;
            }
            for (int i = 1; i <= second; i++)
            {
                 secondFactorial *= i;
            }
            decimal result = firstFactorial / secondFactorial;
            Console.WriteLine($"{result:f2}");
        }
    }
}
