using System;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            double initialMoney = double.Parse(Console.ReadLine());
            int yearToLive = int.Parse(Console.ReadLine());
            int yearsOld = 18;

            for (int i = 1800; i <= yearToLive; i++)
            {
                if (i % 2 == 0)
                {
                    initialMoney -= 12000;
                }
                else
                {
                    initialMoney -= 12000 + 50 * yearsOld;
                }
                yearsOld++;
            }

            if (initialMoney >= 0)
            {
                Console.WriteLine($"Yes! He will live a carefree life and will have {initialMoney:F2} dollars left.");
            }
            else
            {
                Console.WriteLine($"He will need {Math.Abs(initialMoney):F2} dollars to survive.");
            }
        }

    }
}