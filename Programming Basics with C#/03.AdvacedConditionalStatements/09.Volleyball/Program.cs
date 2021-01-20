using System;

namespace Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            string year = Console.ReadLine();
            int hollidays = int.Parse(Console.ReadLine());
            int weekends = int.Parse(Console.ReadLine());

            double weekendsinSofia = 48 - weekends;
            double weekendsinSofiaForPlay = weekendsinSofia * 3.00 / 4.00;
            double holidaySofia = hollidays * 2.0 / 3.0;

            double plays = holidaySofia + weekendsinSofiaForPlay + weekends;

            if (year == "leap")
            {
                plays = plays + (plays * 0.15);
                Console.WriteLine($"{Math.Floor(plays)}");
            }

            else
            {
                Console.WriteLine($"{Math.Floor(plays)}");
            }
        }
    }
}
