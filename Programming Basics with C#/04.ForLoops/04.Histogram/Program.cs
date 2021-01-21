using System;

namespace Watch
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());
            double p1 = 0;
            double p2 = 0;
            double p3 = 0;
            double p4 = 0;
            double p5 = 0;

            for (int i = 1; i <= numbers; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());


                if (currentNumber < 200)
                {
                    p1 += 1;
                }
                else if (currentNumber >= 200 && currentNumber <= 399)
                {
                    p2 += 1;
                }
                else if (currentNumber >= 400 && currentNumber <= 599)
                {
                    p3 += 1;
                }
                else if (currentNumber >= 600 && currentNumber <= 799)
                {
                    p4 += 1;
                }
                else if (currentNumber >= 800)
                {
                    p5 += 1;
                }
            }
            Console.WriteLine($"{p1 / numbers * 100:F2}%");
            Console.WriteLine($"{p2 / numbers * 100:F2}%");
            Console.WriteLine($"{p3 / numbers * 100:F2}%");
            Console.WriteLine($"{p4 / numbers * 100:F2}%");
            Console.WriteLine($"{p5 / numbers * 100:F2}%");
        }
    }
}
