using System;

namespace _03.Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            int area = Area(x, y);
            Console.WriteLine(area);
        }
        static int Area(int x, int y)
        {
            int area = x * y;
            return area;
        }
    }
}
