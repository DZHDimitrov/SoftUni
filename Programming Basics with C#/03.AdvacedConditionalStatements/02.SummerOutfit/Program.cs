using System;

namespace InvalidNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int temp = int.Parse(Console.ReadLine());
            string timeOfDay = Console.ReadLine();

            if (temp >= 10 && temp <= 18)
            {
                if (timeOfDay == "Morning")
                {
                    string outfit = "Sweatshirt";
                    string shoes = "Sneakers";
                    Console.WriteLine($"It's {temp} degrees, get your {outfit} and {shoes}.");
                }

                else if (timeOfDay == "Afternoon")
                {
                    string outfit = "Shirt";
                    string shoes = "Moccasins";
                    Console.WriteLine($"It's {temp} degrees, get your {outfit} and {shoes}.");
                }

                else if (timeOfDay == "Evening")
                {
                    string outfit = "Shirt";
                    string shoes = "Moccasins";
                    Console.WriteLine($"It's {temp} degrees, get your {outfit} and {shoes}.");
                }
            }
            else if (temp > 18 && temp <= 24)
            {
                if (timeOfDay == "Morning")
                {
                    string outfit = "Shirt";
                    string shoes = "Moccasins";
                    Console.WriteLine($"It's {temp} degrees, get your {outfit} and {shoes}.");
                }

                else if (timeOfDay == "Afternoon")
                {
                    string outfit = "T-Shirt";
                    string shoes = "Sandals";
                    Console.WriteLine($"It's {temp} degrees, get your {outfit} and {shoes}.");
                }

                else if (timeOfDay == "Evening")
                {
                    string outfit = "Shirt";
                    string shoes = "Moccasins";
                    Console.WriteLine($"It's {temp} degrees, get your {outfit} and {shoes}.");
                }
            }
            else if (temp >= 25)
            {
                if (timeOfDay == "Morning")
                {
                    string outfit = "T-Shirt";
                    string shoes = "Sandals";
                    Console.WriteLine($"It's {temp} degrees, get your {outfit} and {shoes}.");
                }

                else if (timeOfDay == "Afternoon")
                {
                    string outfit = "Swim Suit";
                    string shoes = "Barefoot";
                    Console.WriteLine($"It's {temp} degrees, get your {outfit} and {shoes}.");
                }

                else if (timeOfDay == "Evening")
                {
                    string outfit = "Shirt";
                    string shoes = "Moccasins";
                    Console.WriteLine($"It's {temp} degrees, get your {outfit} and {shoes}.");
                }
            }
        }
    }
}