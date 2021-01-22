using System;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int money = int.Parse(Console.ReadLine());
            int sumMoney = 0;
            int moneyCash = 0;
            int moneyCard = 0;
            int counterCash = 0;
            int counterCard = 0;
            bool isFalse = true;
            int i = 1;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    isFalse = false;
                    break;
                }
                int currentNumber = int.Parse(input);
                if (i % 2 != 0 && currentNumber > 100)
                {
                    Console.WriteLine("Error in transaction!");
                }
                else if (i % 2 != 0 && currentNumber <= 100)
                {
                    sumMoney += currentNumber;
                    moneyCash += currentNumber;
                    counterCash++;
                    Console.WriteLine("Product sold!");
                }

                else if (i % 2 == 0 && currentNumber < 10)
                {
                    Console.WriteLine("Error in transaction!");
                }
                else if (i % 2 == 0 && currentNumber >= 10)
                {
                    sumMoney += currentNumber;
                    moneyCard += currentNumber;
                    counterCard++;
                    Console.WriteLine("Product sold!");
                }
                if (sumMoney >= money)
                {
                    Console.WriteLine($"Average CS: {(moneyCash * 1.00) / counterCash:F2}");
                    Console.WriteLine($"Average CC: {(moneyCard * 1.00) / counterCard:F2}");
                    break;
                }
                i++;
            }
            if (!isFalse)
            {
                Console.WriteLine("Failed to collect required money for charity.");
            }
        }
    }
}
