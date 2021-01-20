using System;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int youngBikers = int.Parse(Console.ReadLine());
            int oldBikers = int.Parse(Console.ReadLine());
            string typeRoad = Console.ReadLine();
            double taxesYoung = 0;
            double taxesOld = 0;
            double currentTax1 = 0;
            double currentTax2 = 0;

            switch (typeRoad)
            {
                case "trail":
                    currentTax1 = 5.50;
                    currentTax2 = 7.00;
                    taxesYoung = youngBikers * currentTax1;
                    taxesOld = oldBikers * currentTax2;
                    break;
                case "cross-country":
                    currentTax1 = 8;
                    currentTax2 = 9.50;
                    if (youngBikers + oldBikers >= 50)
                    {
                        currentTax1 = currentTax1 - (currentTax1 * 0.25);
                        currentTax2 = currentTax2 - (currentTax2 * 0.25);
                    }
                    taxesYoung = youngBikers * currentTax1;
                    taxesOld = oldBikers * currentTax2;
                    break;
                case "downhill":
                    currentTax1 = 12.25;
                    currentTax2 = 13.75;
                    taxesYoung = youngBikers * currentTax1;
                    taxesOld = oldBikers * currentTax2;
                    break;
                case "road":
                    currentTax1 = 20;
                    currentTax2 = 21.50;
                    taxesYoung = youngBikers * currentTax1;
                    taxesOld = oldBikers * currentTax2;
                    break;
            }
            double sum = taxesYoung + taxesOld;
            double netSum = sum - (sum * 0.05);
            Console.WriteLine($"{netSum:F2}");

        }
    }
}
