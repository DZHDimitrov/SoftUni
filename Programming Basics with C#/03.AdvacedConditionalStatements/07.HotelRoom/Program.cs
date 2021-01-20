using System;

namespace HotelRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());

            if (month == "May" || month == "October")
            {
                double studioP = 50.00;
                double apP = 65.00;
                if (nights > 7 && nights <= 14)
                {
                    studioP -= studioP * 0.05;
                }
                else if (nights > 14)
                {
                    studioP -= studioP * 0.30;
                    apP -= apP * 0.10;
                }
                Console.WriteLine($"Apartment: {apP * nights:F2} lv.");
                Console.WriteLine($"Studio: {studioP * nights:F2} lv.");
            }

            else if (month == "June" || month == "September")
            {
                double studioP = 75.20;
                double apP = 68.70;
                if (nights > 14)
                {
                    studioP -= studioP * 0.20;
                    apP -= apP * 0.10;
                }
                Console.WriteLine($"Apartment: {apP * nights:F2} lv.");
                Console.WriteLine($"Studio: {studioP * nights:F2} lv.");
            }
            else if (month == "July" || month == "August")
            {
                double studioP = 76;
                double apP = 77;
                if (nights > 14)
                {
                    apP -= apP * 0.10;
                }
                Console.WriteLine($"Apartment: {apP * nights:F2} lv.");
                Console.WriteLine($"Studio: {studioP * nights:F2} lv.");
            }

        }
    }
}
