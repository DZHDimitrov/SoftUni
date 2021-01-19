using System;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            double bothSideSize = (x * y) * 2;
            double windows = (1.5 * 1.5) * 2;
            double netBothSideSize = bothSideSize - windows;

            double backAndFrontSide = (x * x) * 2;
            double door = 1.2 * 2;
            double backAndFrontSideNet = backAndFrontSide - door;

            double sumHouse = netBothSideSize + backAndFrontSideNet;

            double firstSideRoof = 2 * (x * y);
            double secondSideRoof = 2 * (x * h / 2);
            double roofSize = firstSideRoof + secondSideRoof;

            double greenPaint = sumHouse / 3.4;
            double redPaint = roofSize / 4.3;

            Console.WriteLine($"{greenPaint:F2}");
            Console.WriteLine($"{redPaint:F2}");
        }
    }
}