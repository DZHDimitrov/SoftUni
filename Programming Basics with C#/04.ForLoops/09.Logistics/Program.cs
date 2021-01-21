using System;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int price = 0;
            int bus = 0;
            int truck = 0;
            int train = 0;
            int allCargo = 0;
            int totalPrice = 0;

            for (int i = 1; i <= number; i++)
            {
                int cargo = int.Parse(Console.ReadLine());

                if (cargo <= 3)
                {
                    price = 200 * cargo;
                    bus += cargo;
                }
                else if (cargo >= 4 && cargo <= 11)
                {
                    price = 175 * cargo;
                    truck += cargo;
                }
                else if (cargo >= 12)
                {
                    price = 120 * cargo;
                    train += cargo;
                }

                totalPrice += price;
                allCargo += cargo;
            }
            Console.WriteLine($"{totalPrice * 1.00 / allCargo:F2}");
            Console.WriteLine($"{bus * 1.00 / allCargo * 100:F2}%");
            Console.WriteLine($"{truck * 1.00 / allCargo * 100:F2}%");
            Console.WriteLine($"{train * 1.00 / allCargo * 100:F2}%");
        }
    }
}