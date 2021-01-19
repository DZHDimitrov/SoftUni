using System;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceVeg = double.Parse(Console.ReadLine());
            double priceFruit = double.Parse(Console.ReadLine());
            int vegQuantity = int.Parse(Console.ReadLine());
            int fruitQuantity = int.Parse(Console.ReadLine());

            double result = priceFruit * fruitQuantity + priceVeg * vegQuantity;
            result = result / 1.94;

            Console.WriteLine($"{result:F2}");
        }
    }
}
