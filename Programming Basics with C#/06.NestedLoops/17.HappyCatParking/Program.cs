using System;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());
            double totalSumOfBills = 0;

            for (int i = 1; i <= days; i++)
            {
                double bill = 0;
                for (int j = 1; j <= hours; j++)
                {
                    if (i % 2 == 0 && j % 2 != 0)
                    {
                        bill += 2.50;
                    }
                    else if (i % 2 != 0 && j % 2 == 0)
                    {
                        bill += 1.25;
                    }
                    else
                    {
                        bill += 1.00;
                    }
                }
                totalSumOfBills += bill;
                Console.WriteLine($"Day: {i} - {bill:F2} leva");
            }
            Console.WriteLine($"Total: {totalSumOfBills:F2} leva");
        }
    }
}