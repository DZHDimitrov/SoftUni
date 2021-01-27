using System;

namespace _01.DayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] week = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday", };

            int number = int.Parse(Console.ReadLine());

            switch (number)
            {
                case 1:
                    Console.WriteLine(week[0]);
                    break;
                case 2:
                    Console.WriteLine(week[1]);
                    break;
                case 3:
                    Console.WriteLine(week[2]);
                    break;
                case 4:
                    Console.WriteLine(week[3]);
                    break;
                case 5:
                    Console.WriteLine(week[4]);
                    break;
                case 6:
                    Console.WriteLine(week[5]);
                    break;
                case 7:
                    Console.WriteLine(week[6]);
                    break;
                default:
                    Console.WriteLine("Invalid day!");
                    break;
            }
        }
    }
}
