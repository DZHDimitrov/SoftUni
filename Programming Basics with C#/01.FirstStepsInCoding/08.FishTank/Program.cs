using System;

namespace ProgramingBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double percentage = double.Parse(Console.ReadLine());

            double volumeincm = length * width * height;
            double volumeinleters = volumeincm * 0.001;
            double areawithsand = volumeinleters * (percentage / 100);
            double result = volumeinleters - areawithsand;

            Console.WriteLine(result);
        }
    }
}


