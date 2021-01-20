using System;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            double result = 0;
            while (true)
            {
                double number = double.Parse(Console.ReadLine());
                if (number < 0)
                {
                    Console.WriteLine("Negative number!");
                    break;
                }
                result = number * 2;

                Console.WriteLine($"Result: {result:F2}");
            }
        }
    }
}