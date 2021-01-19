using System;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            double skumriqP = double.Parse(Console.ReadLine());
            double cacaP = double.Parse(Console.ReadLine());
            double palamudQuantity = double.Parse(Console.ReadLine());
            double safridQuantity = double.Parse(Console.ReadLine());
            double midiQuantity = double.Parse(Console.ReadLine());

            double palamudPrice = skumriqP + (skumriqP * 0.60);
            double safridPrice = cacaP + (cacaP * 0.80);
            double midiPrice = 7.50;

            double sum = palamudPrice * palamudQuantity + safridPrice * safridQuantity + midiPrice * midiQuantity;

            Console.WriteLine($"{sum:F2}");
        }
    }
}
