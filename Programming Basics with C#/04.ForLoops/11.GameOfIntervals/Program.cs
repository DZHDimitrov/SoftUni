using System;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int entries = int.Parse(Console.ReadLine());
            double sumNumbers = 0;
            int zeroToNine = 0;
            int tenToNineteen = 0;
            int twentyToTwentyNine = 0;
            int thirtyToThirtyNine = 0;
            int fortyToFifty = 0;
            int invalids = 0;

            for (int i = 1; i <= entries; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                if (currentNumber < 0 || currentNumber > 50)
                {
                    sumNumbers /= 2;
                    invalids++;
                    continue;
                }

                if (currentNumber >= 0 && currentNumber <= 9)
                {
                    sumNumbers += currentNumber * 0.20;
                    zeroToNine++;
                }
                else if (currentNumber >= 10 && currentNumber <= 19)
                {
                    sumNumbers += currentNumber * 0.30;
                    tenToNineteen++;
                }
                else if (currentNumber >= 20 && currentNumber <= 29)
                {
                    sumNumbers += currentNumber * 0.40;
                    twentyToTwentyNine++;
                }
                else if (currentNumber >= 30 && currentNumber <= 39)
                {
                    sumNumbers += 50;
                    thirtyToThirtyNine++;
                }
                else if (currentNumber >= 40 && currentNumber <= 50)
                {
                    sumNumbers += 100;
                    fortyToFifty++;
                }
            }
            Console.WriteLine($"{sumNumbers:F2}");
            Console.WriteLine($"From 0 to 9: {zeroToNine * 1.00 / entries * 100:F2}%");
            Console.WriteLine($"From 10 to 19: {tenToNineteen * 1.00 / entries * 100:F2}%");
            Console.WriteLine($"From 20 to 29: {twentyToTwentyNine * 1.00 / entries * 100:F2}%");
            Console.WriteLine($"From 30 to 39: {thirtyToThirtyNine * 1.00 / entries * 100:F2}%");
            Console.WriteLine($"From 40 to 50: {fortyToFifty * 1.00 / entries * 100:F2}%");
            Console.WriteLine($"Invalid numbers: {invalids * 1.00 / entries * 100:F2}%");
        }
    }
}