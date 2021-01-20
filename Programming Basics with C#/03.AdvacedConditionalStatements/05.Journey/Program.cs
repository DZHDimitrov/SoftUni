using System;

namespace Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            double sumSpending = 0;

            if (budget <= 100)
            {
                if (season == "summer")
                {
                    sumSpending = budget * 0.30;
                    Console.WriteLine("Somewhere in Bulgaria");
                    Console.WriteLine($"Camp - {sumSpending:F2}");
                }
                else if (season == "winter")
                {
                    sumSpending = budget * 0.70;
                    Console.WriteLine("Somewhere in Bulgaria");
                    Console.WriteLine($"Hotel - {sumSpending:F2}");
                }
            }

            else if (budget > 100 && budget <= 1000)
            {
                if (season == "summer")
                {
                    sumSpending = budget * 0.40;
                    Console.WriteLine("Somewhere in Balkans");
                    Console.WriteLine($"Camp - {sumSpending:F2}");
                }
                else if (season == "winter")
                {
                    sumSpending = budget * 0.80;
                    Console.WriteLine("Somewhere in Balkans");
                    Console.WriteLine($"Hotel - {sumSpending:F2}");
                }
            }

            else if (budget > 1000)
            {
                if (season == "summer" || season == "winter")
                {
                    sumSpending = budget * 0.90;
                    Console.WriteLine("Somewhere in Europe");
                    Console.WriteLine($"Hotel - {sumSpending:F2}");
                }
            }
        }
    }
}
