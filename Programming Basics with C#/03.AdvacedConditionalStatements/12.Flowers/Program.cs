using System;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int hrisantems = int.Parse(Console.ReadLine());
            int roses = int.Parse(Console.ReadLine());
            int tulips = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string holiday = Console.ReadLine();
            double rosesP = 0;
            double hrisantemsP = 0;
            double tulipsP = 0;

            switch (season)
            {
                case "Spring":
                case "Summer":
                    hrisantemsP = 2.00;
                    rosesP = 4.10;
                    tulipsP = 2.50;
                    break;
                case "Autumn":
                case "Winter":
                    hrisantemsP = 3.75;
                    rosesP = 4.50;
                    tulipsP = 4.15;
                    break;
            }
            double totalPrice = hrisantems * hrisantemsP + roses * rosesP + tulips * tulipsP;
            if (holiday == "Y")
            {
                totalPrice += totalPrice * 0.15;
            }

            if (tulips > 7 && season == "Spring")
            {
                totalPrice -= totalPrice * 0.05;
            }

            if (roses >= 10 && season == "Winter")
            {
                totalPrice -= totalPrice * 0.10;
            }

            if (roses + hrisantems + tulips > 20)
            {
                totalPrice -= totalPrice * 0.20;
            }
            totalPrice += 2;

            Console.WriteLine($"{totalPrice:F2}");
        }
    }
}