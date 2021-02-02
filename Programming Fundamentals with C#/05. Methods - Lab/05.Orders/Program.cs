using System;

namespace _03.Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            Bill(product, quantity);

        }
        static void Bill(string product, int quantity)
        {
            switch (product)
            {
                case "coffee":
                    Console.WriteLine($"{1.50 * quantity:F2}");
                    break;
                case "water":
                    Console.WriteLine($"{1.00 * quantity:F2}");
                    break;
                case "coke":
                    Console.WriteLine($"{1.40 * quantity:F2}");
                    break;
                case "snacks":
                    Console.WriteLine($"{2.00 * quantity:F2}");
                    break;
                default:
                    break;
            }
        }
    }
}
