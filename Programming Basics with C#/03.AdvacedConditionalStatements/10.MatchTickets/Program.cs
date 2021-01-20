using System;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string category = Console.ReadLine();
            int people = int.Parse(Console.ReadLine());
            double ticketPrice = 0;
            double transport = 0;

            switch (category)
            {
                case "VIP":
                    ticketPrice = 499.99 * people;
                    break;
                case "Normal":
                    ticketPrice = 249.99 * people;
                    break;
            }

            if (people >= 1 && people <= 4)
            {
                transport = 0.75 * budget;
            }
            else if (people >= 5 && people <= 9)
            {
                transport = 0.60 * budget;
            }
            else if (people >= 10 && people <= 24)
            {
                transport = 0.50 * budget;
            }
            else if (people >= 25 && people <= 49)
            {
                transport = 0.40 * budget;
            }
            else if (people >= 50)
            {
                transport = 0.25 * budget;
            }

            if (ticketPrice + transport > budget)
            {
                Console.WriteLine($"Not enough money! You need {(ticketPrice + transport) - budget:F2} leva.");
            }
            else if (budget >= ticketPrice + transport)
            {
                Console.WriteLine($"Yes! You have {budget - (ticketPrice + transport):F2} leva left.");
            }

        }
    }
}
