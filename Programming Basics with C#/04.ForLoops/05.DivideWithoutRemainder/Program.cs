using System;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int p1 = 0;
            int p2 = 0;
            int p3 = 0;


            for (int i = 1; i <= number; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                if (currentNumber % 2 == 0)
                {
                    p1++;
                }
                if (currentNumber % 3 == 0)
                {
                    p2++;
                }
                if (currentNumber % 4 == 0)
                {
                    p3++;
                }
            }
            Console.WriteLine($"{p1 * 1.00 / number * 100:F2}%");
            Console.WriteLine($"{p2 * 1.00 / number * 100:F2}%");
            Console.WriteLine($"{p3 * 1.00 / number * 100:F2}%");
        }
    }
}
