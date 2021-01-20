using System;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string whatClass = "";
            string typeCar = "";
            double price = 0;

            if (budget <= 100)
            {
                whatClass = "Economy class";
                switch (season)
                {
                    case "Summer":
                        typeCar = "Cabrio";
                        price = budget * 0.35;
                        break;
                    case "Winter":
                        typeCar = "Jeep";
                        price = budget * 0.65;
                        break;
                }
            }
            else if (budget > 100 && budget <= 500)
            {
                whatClass = "Compact class";
                switch (season)
                {
                    case "Summer":
                        typeCar = "Cabrio";
                        price = budget * 0.45;
                        break;
                    case "Winter":
                        typeCar = "Jeep";
                        price = budget * 0.80;
                        break;
                }
            }
            else if (budget > 500)
            {
                whatClass = "Luxury class";
                switch (season)
                {
                    case "Summer":
                    case "Winter":
                        typeCar = "Jeep";
                        price = budget * 0.90;
                        break;
                }
            }
            Console.WriteLine($"{whatClass}");
            Console.WriteLine($"{typeCar} - {price:F2}");
        }
    }
}