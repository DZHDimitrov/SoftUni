using System;

namespace InvalidNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fishers = int.Parse(Console.ReadLine());
            double rent = 0;
            if (season == "Spring")
            {
                if (fishers <= 6)
                {
                    rent = 3000 - (3000 * 0.10);
                    if (fishers % 2 == 0)
                    {
                        rent = rent - (rent * 0.05);
                    }
                }
                else if (fishers >= 7 && fishers <= 11)
                {
                    rent = 3000 - (3000 * 0.15);
                    if (fishers % 2 == 0)
                    {
                        rent = rent - (rent * 0.05);
                    }
                }
                else if (fishers >= 12)
                {
                    rent = 3000 - (3000 * 0.25);
                    if (fishers % 2 == 0)
                    {
                        rent = rent - (rent * 0.05);
                    }
                }
            }

            else if (season == "Summer" || season == "Autumn")
            {
                if (fishers <= 6)
                {
                    rent = 4200 - (4200 * 0.10);
                    if (season == "Summer" && fishers % 2 == 0)
                    {
                        rent = rent - (rent * 0.05);
                    }
                }
                else if (fishers >= 7 && fishers <= 11)
                {
                    rent = 4200 - (4200 * 0.15);
                    if (season == "Summer" && fishers % 2 == 0)
                    {
                        rent = rent - (rent * 0.05);
                    }
                }
                else if (fishers >= 12)
                {
                    rent = 4200 - (4200 * 0.25);
                    if (fishers % 2 == 0)
                    {
                        rent = rent - (rent * 0.05);
                    }
                }
            }

            else if (season == "Winter")
            {
                if (fishers <= 6)
                {
                    rent = 2600 - (2600 * 0.10);
                    if (fishers % 2 == 0)
                    {
                        rent = rent - (rent * 0.05);
                    }
                }
                else if (fishers >= 7 && fishers <= 11)
                {
                    rent = 2600 - (2600 * 0.10);
                    if (fishers % 2 == 0)
                    {
                        rent = rent - (rent * 0.05);
                    }
                }
                else if (fishers >= 12)
                {
                    rent = 2600 - (2600 * 0.25);
                    if (fishers % 2 == 0)
                    {
                        rent = rent - (rent * 0.05);
                    }
                }
            }

            if (budget >= rent)
            {
                Console.WriteLine($"Yes! You have {budget - rent:F2} leva left.");
            }

            else if (budget < rent)
            {
                Console.WriteLine($"Not enough money! You need {rent - budget:F2} leva.");
            }

        }
    }
}