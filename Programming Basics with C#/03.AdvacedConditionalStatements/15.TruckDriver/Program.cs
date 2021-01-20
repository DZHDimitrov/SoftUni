using System;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            double kms = double.Parse(Console.ReadLine());
            double priceForOne = 0;

            switch (season)
            {
                case "Spring":
                case "Autumn":
                    if (kms <= 5000)
                    {
                        priceForOne = 0.75;
                    }
                    else if (kms > 5000 && kms <= 10000)
                    {
                        priceForOne = 0.95;
                    }
                    else if (kms > 10000 && kms <= 20000)
                    {
                        priceForOne = 1.45;
                    }
                    break;
                case "Summer":
                    if (kms <= 5000)
                    {
                        priceForOne = 0.90;
                    }
                    else if (kms > 5000 && kms <= 10000)
                    {
                        priceForOne = 1.10;
                    }
                    else if (kms > 10000 && kms <= 20000)
                    {
                        priceForOne = 1.45;
                    }
                    break;
                case "Winter":
                    if (kms <= 5000)
                    {
                        priceForOne = 1.05;
                    }
                    else if (kms > 5000 && kms <= 10000)
                    {
                        priceForOne = 1.25;
                    }
                    else if (kms > 10000 && kms <= 20000)
                    {
                        priceForOne = 1.45;
                    }
                    break;
            }
            double totalMoney = (priceForOne * kms) * 4;
            totalMoney -= totalMoney * 0.10;
            Console.WriteLine($"{totalMoney:F2}");
        }
    }
}