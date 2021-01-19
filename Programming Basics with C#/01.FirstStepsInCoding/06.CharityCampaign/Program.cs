using System;

namespace ProgramingBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int people = int.Parse(Console.ReadLine());
            int cakes = int.Parse(Console.ReadLine());
            int waffles = int.Parse(Console.ReadLine());
            int pancakes = int.Parse(Console.ReadLine());

            double dailyrevenue = (cakes * 45 + waffles * 5.8 + pancakes * 3.2) * people;
            double result = dailyrevenue * days;
            double result2 = result - (result / 8);

            Console.WriteLine(result2);
        }
    }
}


