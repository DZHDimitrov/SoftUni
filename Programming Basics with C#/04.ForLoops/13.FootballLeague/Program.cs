using System;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());
            int fans = int.Parse(Console.ReadLine());
            int sectorA = 0;
            int sectorB = 0;
            int sectorV = 0;
            int sectorG = 0;

            for (int i = 1; i <= fans; i++)
            {
                string input = Console.ReadLine();

                switch (input)
                {
                    case "A":
                        sectorA++;
                        break;
                    case "B":
                        sectorB++;
                        break;
                    case "V":
                        sectorV++;
                        break;
                    case "G":
                        sectorG++;
                        break;
                }
            }
            Console.WriteLine($"{sectorA * 1.00 / fans * 100:F2}%");
            Console.WriteLine($"{sectorB * 1.00 / fans * 100:F2}%");
            Console.WriteLine($"{sectorV * 1.00 / fans * 100:F2}%");
            Console.WriteLine($"{sectorG * 1.00 / fans * 100:F2}%");
            Console.WriteLine($"{fans * 1.00 / capacity * 100:F2}%");
        }
    }
}