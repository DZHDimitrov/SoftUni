using System;
using System.Linq;

namespace CSharpAdvanced___2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string bestModel = null;
            double biggestVolume = 0;

            for (int i = 0; i < n; i++)
            {
                string currentKeg = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());

                double volume = Math.PI * Math.Pow(radius, 2) * height;
                if (volume > biggestVolume)
                {
                    biggestVolume = volume;
                    bestModel = currentKeg;
                }
            }
            Console.WriteLine(bestModel);

        }
    }
}
