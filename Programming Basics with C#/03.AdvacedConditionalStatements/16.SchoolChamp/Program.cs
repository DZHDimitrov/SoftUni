using System;
using System.Linq;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            string typeOfGroup = Console.ReadLine();
            int students = int.Parse(Console.ReadLine());
            int nights = int.Parse(Console.ReadLine());
            string sport = "";
            double price = 0;

            switch (season)
            {
                case "Winter":
                    switch (typeOfGroup)
                    {
                        case "boys":
                            price = 9.60;
                            sport = "Judo";
                            break;
                        case "girls":
                            price = 9.60;
                            sport = "Gymnastics";
                            break;
                        case "mixed":
                            price = 10;
                            sport = "Ski";
                            break;
                    }
                    break;
                case "Spring":
                    switch (typeOfGroup)
                    {
                        case "boys":
                            price = 7.20;
                            sport = "Tennis";
                            break;
                        case "girls":
                            price = 7.20;
                            sport = "Athletics";
                            break;
                        case "mixed":
                            price = 9.50;
                            sport = "Cycling";
                            break;
                    }
                    break;
                case "Summer":
                    switch (typeOfGroup)
                    {
                        case "boys":
                            price = 15;
                            sport = "Football";
                            break;
                        case "girls":
                            price = 15;
                            sport = "Volleyball";
                            break;
                        case "mixed":
                            price = 20;
                            sport = "Swimming";
                            break;
                    }
                    break;
            }
            double totalPrice = price * nights * students;

            if (students >= 50)
            {
                totalPrice -= totalPrice * 0.50;
            }
            else if (students >= 20 && students < 50)
            {
                totalPrice -= totalPrice * 0.15;
            }
            else if (students >= 10 && students < 20)
            {
                totalPrice -= totalPrice * 0.05;
            }

            Console.WriteLine($"{sport} {totalPrice:F2} lv.");
        }
    }
}