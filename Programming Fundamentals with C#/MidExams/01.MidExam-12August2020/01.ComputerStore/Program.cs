using System;

namespace _01.ComputerStore
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double totalNetPrice = 0;
            double taxes = 0;
            while (input != "special" && input != "regular")
            {
                double currentPrice = double.Parse(input);
                if (currentPrice < 0)
                {
                    Console.WriteLine("Invalid price!");
                    input = Console.ReadLine();
                    continue;
                }
                taxes += currentPrice * 0.20;
                totalNetPrice += currentPrice;
                input = Console.ReadLine();
            }
            if (totalNetPrice == 0)
            {
                Console.WriteLine("Invalid order!");
                return;
            }
            Console.WriteLine("Congratulations you've just bought a new computer!");
            double totalPrice = totalNetPrice + taxes;
            if (input == "special")
            {
                totalPrice -= totalPrice * 0.10;
            }
            Console.WriteLine($"Price without taxes: {totalNetPrice:f2}$");
            Console.WriteLine($"Taxes: {taxes:f2}$");
            Console.WriteLine("-----------");
            Console.WriteLine($"Total price: {totalPrice:f2}$");
            Console.WriteLine();
        }
    }
}
