using System;

namespace Watch
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double evenSum = 0;
            double evenMin = double.MaxValue;
            double evenMax = double.MinValue;
            double oddSum = 0;
            double oddMax = double.MinValue;
            double oddMin = double.MaxValue;

            for (int i = 1; i <= n; i++)
            {
                double currentNumber = double.Parse(Console.ReadLine());

                if (i % 2 == 0)
                {
                    evenSum += currentNumber;
                    if (currentNumber < evenMin)
                    {
                        evenMin = currentNumber;
                    }
                    if (currentNumber > evenMax)
                    {
                        evenMax = currentNumber;
                    }
                }
                else
                {
                    oddSum += currentNumber;
                    if (currentNumber < oddMin)
                    {
                        oddMin = currentNumber;
                    }
                    if (currentNumber > oddMax)
                    {
                        oddMax = currentNumber;
                    }
                }
            }
            Console.WriteLine($"OddSum={oddSum:F2},");
            if (oddMin != double.MaxValue)
            {
                Console.WriteLine($"OddMin={oddMin:F2},");
            }
            else
            {
                Console.WriteLine("OddMin=No,");
            }
            if (oddMax != double.MinValue)
            {
                Console.WriteLine($"OddMax={oddMax:F2},");
            }
            else
            {
                Console.WriteLine("OddMax=No,");
            }

            Console.WriteLine($"EvenSum={evenSum:F2},");

            if (evenMin != double.MaxValue)
            {
                Console.WriteLine($"EvenMin={evenMin:F2},");
            }
            else
            {
                Console.WriteLine("EvenMin=No,");
            }
            if (evenMax != double.MinValue)
            {
                Console.WriteLine($"EvenMax={evenMax:F2}");
            }
            else
            {
                Console.WriteLine("EvenMax=No");
            }
        }
    }
}
