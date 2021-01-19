using System;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            double w = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            w = w * 100;
            h = h * 100 - 100;

            double workPlaceW = Math.Floor(h / 70);
            double workPlaceH = Math.Floor(w / 120);
            double allWorkPlaces = workPlaceW * workPlaceH - 3;
            Console.WriteLine(allWorkPlaces);
        }
    }
}
